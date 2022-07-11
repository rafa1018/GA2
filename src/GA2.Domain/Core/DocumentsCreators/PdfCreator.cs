using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class PdfCreator : ProviderDocumentos
    {
        /// <summary>
        /// Genera pdf con solicitud de preaprobado
        /// </summary>
        /// <param name="SimulacionCliente"></param>
        /// <returns></returns>
        internal async Task<FileResult> GenerarConfirmacionPreAprobado(SimulacionClienteDto SimulacionCliente, FileStreamResult baseHtml, FileStreamResult baseCss)
        {
            Dictionary<string, string> Values = new Dictionary<string, string>();
            string Basedocument = await (new StreamReader( baseHtml.FileStream)).ReadToEndAsync();
            string Styles = await (new StreamReader(baseCss.FileStream)).ReadToEndAsync();

            Values.Add("PAgen", SimulacionCliente.numeroPreaprobado.ToString());
            Values.Add("PAfecha", DateTime.Now.ToString("dd/MM/yyyy"));
            Values.Add("PAnombre", SimulacionCliente.nombreCliente);
            Values.Add("PAnumeroDocumento", SimulacionCliente.numeroDocumento);
            Values.Add("PAdepartamento", SimulacionCliente.departamento);
            Values.Add("PAciudad", SimulacionCliente.ciudad);
            Values.Add("PAdireccion", SimulacionCliente.direccion);
            Values.Add("PAcorreo", SimulacionCliente.correoElectronico);
            Values.Add("PAtelFijo", SimulacionCliente.telefonoFijo);
            Values.Add("PAcelular", SimulacionCliente.telefonoCelular);
            Values.Add("PAfuerza", SimulacionCliente.fuerza);
            Values.Add("PAregimen", SimulacionCliente.regimen);
            Values.Add("PAcategoria", SimulacionCliente.categoria);
            Values.Add("PAcargo", SimulacionCliente.grado.ToString());
            if (SimulacionCliente.tipoCredito == 1) Values.Add("Crédito Hipotecario ( )", "Crédito Hipotecario (X)");
            else Values.Add("Leasing Habitacional ( )", "Leasing Habitacional (X)");
            Values.Add("PAvivienda", SimulacionCliente.smcTipoVivienda);
            if (SimulacionCliente.viviendaVIS == "No") Values.Add("PAviviendaVis", "NO VIS");
            else Values.Add("PAviviendaVis", "VIS");
            Values.Add("PAvalorVivienda", SimulacionCliente.valorVivienda.ToString("#,##0"));
            Values.Add("PAvalorPrestamo", SimulacionCliente.valorPrestamo.ToString("#,##0"));
            Values.Add("PAplazoM", SimulacionCliente.plazo.ToString());
            Values.Add("PAplazoA", SimulacionCliente.años.ToString());
            Values.Add("PAefectivaA", SimulacionCliente.valorTasaEA.ToString("#.#0"));
            Values.Add("PAnominalM", (SimulacionCliente.valorTasaMV).ToString(((SimulacionCliente.valorTasaMV * 100) < 1) ? "0.#0" : "#.#0"));
            Values.Add("PAcuotaSeguro", SimulacionCliente.valorCuota.ToString("#,##0"));
            Values.Add("PAcuotaSinSeguro", SimulacionCliente.valorCuotaSinSeg.ToString("#,##0"));

            var Password = SimulacionCliente.numeroDocumento;
            Password = Password[Math.Max(0, Password.Length - 4)..];

            return await CrearDocumento(Basedocument, Styles, TipoDocumentoArchivo.PDF, Guid.NewGuid().ToString(), Values, Password);
        }

        /// <summary>
        /// Genera pdf para datos solicitud Comite
        /// </summary>
        /// <param name="DatosSolicitud"></param>
        /// <returns></returns>
        internal async Task<FileResult> GenerarDatosSolicComite(DatosSolicitudComite DatosSolicitud, SimulacionCliente simulacion, HistorialCredito historial,
                                                                FileStreamResult baseFile, FileStreamResult baseCss)
        {

            var Basedocument = await (new StreamReader(baseFile.FileStream)).ReadToEndAsync();
            var Styles = await (new StreamReader(baseCss.FileStream)).ReadToEndAsync();
            Dictionary<string, string> Values = new Dictionary<string, string>();
            var conversorALetras = new NumerosALetras();


            //Añado valores a reemplazar en el documento
            Values.Add("<'fecha del sistema'>", $"{DateTime.Now.Day} de {conversorALetras.GetMonthInLetters(DateTime.Now).ToLower()} de {DateTime.Now.Year}");
            Values.Add("<numero de identificacion>", DatosSolicitud.SOB_NUMERO_DOCUMENTO.ToString());
            Values.Add("<apellidos y nombres>", DatosSolicitud.SOB_PRIMER_NOMBRE + " " + DatosSolicitud.SOB_SEGUNDO_NOMBRE + " " + DatosSolicitud.SOB_PRIMER_APELLIDO + " " + DatosSolicitud.SOB_SEGUNDO_APELLIDO);
            Values.Add("<edad calculada>", DatosSolicitud.EDAD.ToString());
            Values.Add("<estado vivil>", DatosSolicitud.ESTADO_CIVIL);
            Values.Add("<sexo>", DatosSolicitud.SEXO.ToString());
            Values.Add("<fecha nacimiento y lugar nacimiento>", $"{DatosSolicitud.SOB_FECHA_NACIMIENTO.Day} de {DatosSolicitud.SOB_FECHA_NACIMIENTO.Month} de {DatosSolicitud.SOB_FECHA_NACIMIENTO.Year}, {DatosSolicitud.CIUDAD_NACIMIENTO}");
            Values.Add("<dirección residencia>", $"{DatosSolicitud.SOB_DIRECCION_RESIDENCIA}, {DatosSolicitud.CIUDAD_RESIDENCIA}, {DatosSolicitud.DEPARTAMENTO_RESIDENCIA}");
            Values.Add("<teléfono celular>", DatosSolicitud.SOB_CELULAR);
            Values.Add("<teléfono fijo>", DatosSolicitud.SOB_TELEFONO_RESIDENCIA);
            Values.Add("<email>", DatosSolicitud.SOB_CORREO_PERSONAL);
            Values.Add("<nombre unidad ejecutora>", DatosSolicitud.FUERZA);
            Values.Add("<nombre categoría>", DatosSolicitud.CATEGORIA);
            Values.Add("<nombre grado>", DatosSolicitud.GRADO);
            Values.Add("<número cuotas aportadas ahorro obligatorio>", DatosSolicitud.NUMERO_CUOTAS.ToString());
            Values.Add("<info financiera.total ingreso>", DatosSolicitud.TOTAL_INGRESOS.ToString("#,##0"));
            Values.Add("<info financiera.total descuentos>", DatosSolicitud.TOTAL_EGRESOS.ToString("$#,##0"));
            Values.Add("<AQMGo.Score>", DatosSolicitud.SCORE_AQM);
            Values.Add("<Caja.Score>", DatosSolicitud.SCORE_CAJA);
            Values.Add("$CapacidadPago", decimal.Parse(DatosSolicitud.CAPACIDAD_PAGO_AQM).ToString("#,##0"));
            Values.Add("$HabitoPago", "HABITO PAGO");
            Values.Add("$DiasConsultado", (DateTime.Now - historial.CBC_FECHA_CONSULTA).TotalDays > 30 ? "No" : "Si");
            Values.Add("$TotalActivos", DatosSolicitud.TOTAL_ACTIVOS);
            Values.Add("$DescripcionTotalActivos", DatosSolicitud.DESCRIPCION_ACTIVOS);
            Values.Add("<solicitud.info economica. Total pasivos>", DatosSolicitud.TOTAL_PASIVOS);
            Values.Add("<descripcion_inmueble>", DatosSolicitud.NOMBRE_VIVIENDA);
            Values.Add("<direccion>", DatosSolicitud.SOP_DIRECCION_INMUEBLE);
            Values.Add("<ciudad>", DatosSolicitud.CIUDAD_INMUEBLE);
            Values.Add("<area_construida>", DatosSolicitud.SIT_METROS_CUADRADOS.ToString() + " M²");
            Values.Add("<tipo_vivienda>", DatosSolicitud.TIPO_VIVIENDA);
            Values.Add("<dvendedores>", DatosSolicitud.VENDEDORES);
            Values.Add("<antiguedad>", DatosSolicitud.ANO_CONSTRUCCION);
            Values.Add("<valor_evaluo>", DatosSolicitud.SIT_VALOR_AVALUO_COMERCIAL.ToString("$#,##0"));
            Values.Add("<valor_inmueble>", DatosSolicitud.SIT_VALOR_VENTA_INMUEBLE.ToString("$#,##0"));

            Values.Add("<te_direccion>", DatosSolicitud.SOP_DIRECCION_INMUEBLE);

            Values.Add("<estudio_titulos>", DatosSolicitud.SIJ_CONCEPTO_JURIDICO_FIN);

            Values.Add("<destudio_sarlaft>", "SARLAFT");

            Values.Add("<c_valor_inmueble>", DatosSolicitud.SIT_VALOR_VENTA_INMUEBLE.ToString("#,##0"));
            Values.Add("<c_monto_financiar>", DatosSolicitud.SOP_VALOR_CREDITO.ToString("#,##0"));
            Values.Add("<c_recursos_cuenta_individual>", decimal.Parse(DatosSolicitud.RECURSOS_CUENTA_INDIV).ToString("#,##0"));
            Values.Add("<c_recursos_propios_Afiliado>", decimal.Parse(DatosSolicitud.RECURSOS_PROPIOS).ToString("#,##0"));
            Values.Add("<c_aporte_afiliado>", DatosSolicitud.TOTAL_APORTES_AFILIADO.ToString("#,##0"));
            Values.Add("c meses", DatosSolicitud.PLAZO_FINANCIACION.ToString());
            Values.Add("<c_taza_fija>", simulacion.SMC_VALOR_TASA_EA.ToString("#.#0") + "%");
            Values.Add("<c_modalidad_pago>", DatosSolicitud.MODALIDAD_PAGO);
            Values.Add("<c_opcion_compra>", DatosSolicitud.OPCION_COMPRA.ToString("#,##0"));
            Values.Add("<c_canon_mensualidad>", DatosSolicitud.CANON_INICIAL.ToString("#,##0"));
            Values.Add("$NombreElabora", "NombreElabora");
            Values.Add("$NombreRevisa", "NombreRevisa");


            return await CrearDocumento(Basedocument, Styles, TipoDocumentoArchivo.PDF, Guid.NewGuid().ToString().ToUpper(), Values);
        }

        /// <summary>
        /// Genera pdf para cesion Leasing
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        internal async Task<FileResult> GenerarCesionLeasig(DatosSolicitudComite datosSolicitudComite, FileStreamResult baseHtml, FileStreamResult baseCss)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string Basedocument = await (new StreamReader(baseHtml.FileStream)).ReadToEndAsync();
            string Styles = await (new StreamReader(baseCss.FileStream)).ReadToEndAsync();
            var conversorALetras = new NumerosALetras();
            if (datosSolicitudComite != null)
            {
                var nombreCliente = string.Empty;
                if (datosSolicitudComite.SOB_PRIMER_NOMBRE != null && datosSolicitudComite.SOB_SEGUNDO_NOMBRE != null && datosSolicitudComite.SOB_PRIMER_APELLIDO != null && datosSolicitudComite.SOB_SEGUNDO_APELLIDO != null)
                {
                    nombreCliente = datosSolicitudComite.SOB_PRIMER_NOMBRE + " " + datosSolicitudComite.SOB_SEGUNDO_NOMBRE + " " + datosSolicitudComite.SOB_PRIMER_APELLIDO + " " + datosSolicitudComite.SOB_SEGUNDO_APELLIDO;
                }

                values.Add("SOB_NUMERO_DOCUMENTO", datosSolicitudComite.SOB_NUMERO_DOCUMENTO != 0 ? datosSolicitudComite.SOB_NUMERO_DOCUMENTO.ToString() : "");
                values.Add("NOMBRE_CLIENTE", nombreCliente);
                values.Add("DIAFIRMA", conversorALetras.GetDayInLetters(DateTime.Now));
                values.Add("MESFIRMA", conversorALetras.GetMonthInLetters(DateTime.Now));
                values.Add("ANIOFIRMA", conversorALetras.GetYearInLetters(DateTime.Now));
                //values.Add("DIACOMPRAVENTA", conversorALetras.GetDayInLetters(DateTime.Now));
                //values.Add("MESCOMPRAVENTA", conversorALetras.GetMonthInLetters(DateTime.Now));
                //values.Add("ANIOCOMPRAVENTA", conversorALetras.GetYearInLetters(DateTime.Now));
                values.Add("CIUDAD_EXPEDICION", datosSolicitudComite.CIUDAD_EXPEDICION != null ? datosSolicitudComite.CIUDAD_EXPEDICION : "");
                values.Add("SOP_NOMBRE_VENDEDOR", datosSolicitudComite.SOP_NOMBRE_VENDEDOR != null ? datosSolicitudComite.SOP_NOMBRE_VENDEDOR : "");
                values.Add("SOP_NUMERO_DOCUMENTO_VENDEDOR", datosSolicitudComite.SOP_NUMERO_DOCUMENTO_VENDEDOR != null ? datosSolicitudComite.SOP_NUMERO_DOCUMENTO_VENDEDOR : "");
                values.Add("CIUDAD_VENDEDOR", datosSolicitudComite.CIUDAD_VENDEDOR != null ? datosSolicitudComite.CIUDAD_VENDEDOR : "");
                values.Add("DETALLE_INMUEBLE ", datosSolicitudComite.DETALLE_INMUEBLE != null ? datosSolicitudComite.DETALLE_INMUEBLE : "");
                values.Add("CIUDAD_INMUEBLE", datosSolicitudComite.CIUDAD_INMUEBLE != null ? datosSolicitudComite.CIUDAD_INMUEBLE : "");
                values.Add("MATRICULA_INMUEBLE", datosSolicitudComite.MATRICULA_INMOBILIARIA != null ? datosSolicitudComite.MATRICULA_INMOBILIARIA : "");
                values.Add("VALOR_INMUEBLE_LETRAS", datosSolicitudComite.SIT_VALOR_VENTA_INMUEBLE != 0 ? conversorALetras.Convertir(datosSolicitudComite.SIT_VALOR_VENTA_INMUEBLE.ToString()) + " PESOS " : "0 PESOS");
                values.Add("SIT_VALOR_VENTA_INMUEBLE", datosSolicitudComite.SIT_VALOR_VENTA_INMUEBLE != 0 ? datosSolicitudComite.SIT_VALOR_VENTA_INMUEBLE.ToString() : "0");
                return await CrearDocumento(Basedocument, Styles, TipoDocumentoArchivo.PDF, Guid.NewGuid().ToString(), values, null);
            }

            return null;
        }

        /// <summary>
        /// Genera pdf para reparto
        /// </summary>
        /// <param name="DatosSolicitud"></param>
        /// <returns></returns>
        internal async Task<FileResult> GenerarReparto(DatosRepartoDto datosSolicitudComite, FileStreamResult baseHtml, FileStreamResult baseCss)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string Basedocument = await (new StreamReader(baseHtml.FileStream)).ReadToEndAsync();
            string Styles = await (new StreamReader(baseCss.FileStream)).ReadToEndAsync();

            return await CrearDocumento(Basedocument, Styles, TipoDocumentoArchivo.PDF, Guid.NewGuid().ToString().ToUpper(), null, null);

        }

        /// <summary>
        /// Genera pdf ficha Comite
        /// </summary>
        /// <param name="DatosSolicitud"></param>
        /// <returns></returns>
        internal async Task<FileResult> GenerarFichaComite(SolicitudActaComiteDto solicitud, FileStreamResult baseHtml, FileStreamResult baseCss)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string basedocument = await (new StreamReader(baseHtml.FileStream)).ReadToEndAsync();
            //string fig1base = File.ReadAllText(baseFilePath + "57b7195a-25cf-4841-9452-5d9a77741f4a.html");
            //string fig2base = File.ReadAllText(baseFilePath + "37c6c408-b789-49c3-a81f-dceb36d11cc8.html");
            string Styles = await (new StreamReader(baseCss.FileStream)).ReadToEndAsync();

            var comite = solicitud.DatosComite;
            var integrantes = solicitud.IntegrantesComite;

            var listaAsistentes = string.Empty;
            var listaInvitados = string.Empty;

            foreach (var integrante in integrantes.ToList())
            {
                if (integrante.tipo == "Asistente")
                {
                    listaAsistentes += $"<tr><td class='contenido'>• {integrante.nombre}</td> <td class='contenido'>{integrante.cargo}</td></tr>";
                }
                else
                {
                    listaInvitados += $"<tr><td class='contenido'>• {integrante.nombre}</td> <td class='contenido'>{integrante.cargo}</td></tr>";
                }
            }
            if (listaInvitados.Length == 0)
            {
                values.Add("INVITADOS:", "");
            }

            var ordenDia = new List<string>
            {
                "Verificación del cuórum.",
                "Presentación solicitudes de Leasing Habitacional para aprobación del Comité de Crédito.",
                "Cierre de Comité de Crédito."
            };

            //var ordenDia = solicitud.TemasComite;

            var listaOrdenDia = string.Empty;
            var enumerador = 0;
            var ordenDesarrollo = string.Empty;
            var contFiguras = 0;
            foreach (var orden in ordenDia)
            {
                enumerador++;
                listaOrdenDia += $"<tr><td class='contenido'>{enumerador}. {orden}</td></tr></br>";
                ordenDesarrollo += $"<p class='semi-title'><strong>{enumerador}. {orden}</strong></p>";
                ordenDesarrollo += $"<p class='contenido'>Descripcion {orden}</p>";
                if (orden == "Presentación solicitudes de Leasing Habitacional para aprobación del Comité de Crédito.")
                {
                    var informaciones = string.Empty;
                    var subenumerador = 0;
                    var subindice = 0;

                    foreach (var registro in solicitud.DatosSolicitud)
                    {
                        subenumerador++;
                        subindice++;
                        //informaciones += "<div style='page-break-before: always'></div>";
                        informaciones += $"<p class='contenido'><strong>{enumerador}.{subenumerador} {registro.grado} {registro.primerNombre + " " + registro.segundoNombre + " " + registro.primerApellido + " " + registro.segundoApellido}</strong></p>";
                        informaciones += $"<p class='contenido'>{enumerador}.{subenumerador}.{subindice} Informacion Financiera</p>";
                        //var figura1 = fig1base;
                        contFiguras++;
                        informaciones += $"<p class='contenido' style='align-text:center'>Figura {contFiguras}</p>";
                        Dictionary<string, string> valoresCambio1 = new Dictionary<string, string>();
                        valoresCambio1.Add("$cedula", registro.numeroDocumento.ToString());
                        valoresCambio1.Add("$institucion", registro.fuerza);
                        valoresCambio1.Add("$cargo", registro.categoria + "-" + registro.grado);
                        valoresCambio1.Add("$numeroCuotas", registro.numeroCuotas.ToString());
                        valoresCambio1.Add("$edad", registro.edad.ToString());
                        valoresCambio1.Add("$estadoCivil", registro.estadoCivil);
                        valoresCambio1.Add("$ciudadResidencia", registro.ciudadResidencia);
                        valoresCambio1.Add("$lugarTrabajo", registro.ciudadOficina);
                        valoresCambio1.Add("$salario", registro.salarioBasico.ToString());
                        valoresCambio1.Add("$sinCuota", registro.NivelEndeudamientoAQM.ToString());
                        valoresCambio1.Add("$conCuota", registro.NivelEndeudamientoCuotaAQM.ToString());
                        valoresCambio1.Add("$habitopago", registro.HabitoPago);
                        valoresCambio1.Add("$valorCredito", registro.valorCredito.ToString());
                        valoresCambio1.Add("$plazoMeses", registro.plazoFinanciacion.ToString());
                        valoresCambio1.Add("$plazoAnios", (registro.plazoFinanciacion / 12).ToString());
                        valoresCambio1.Add("$canonMensual", "0");
                        valoresCambio1.Add("$opcionCompra", "0");
                        valoresCambio1.Add("$cuentaIndividual", "0");
                        valoresCambio1.Add("$recursosPropios", "0");
                        valoresCambio1.Add("$porcFinan", registro.porcFinanciacion.ToString("0.##"));
                        valoresCambio1.Add("$ubicacion", registro.ciudadInmueble);
                        valoresCambio1.Add("$tipoVivienda", registro.tipoVivienda);
                        valoresCambio1.Add("$avaluoComercial", registro.avaluoComercial.ToString());
                        valoresCambio1.Add("$avaluoCatastral", registro.avaluoCatastral.ToString());
                        valoresCambio1.Add("$venta", registro.ventaInmueble.ToString());

                        //foreach (var valor in valoresCambio1)
                        //{
                        //    figura1 = figura1.Replace(valor.Key, valor.Value);
                        //}
                        //informaciones += figura1;
                        informaciones += $"<p class='contenido' style='align-text:center'><strong>Resultado:</strong> comentario resultado</p>";
                        informaciones += $"<p class='contenido' style='align-text:center'>Fuente: Área de Crédito y Cartera, Caja Promotora de Vivienda Militar y de Policía, {registro.fechaCreacion.Year}</p>";

                        informaciones += $"<p class='contenido'>{enumerador}.{subenumerador}.{subindice++} Informacion Tecnica del Inmueble</p>";
                        contFiguras++;
                        informaciones += $"<p class='contenido' style='align-text:center'>Figura {contFiguras}</p>";
                        //var figura2 = fig2base;
                        Dictionary<string, string> valoresCambio2 = new Dictionary<string, string>();
                        valoresCambio2.Add("$ciudadMunicipio", registro.ciudadInmueble + "/" + registro.departamentoInmueble);
                        valoresCambio2.Add("$conjunto", "-");
                        valoresCambio2.Add("$direccion", registro.direccionInmueble);
                        valoresCambio2.Add("$area", registro.Area.ToString());
                        valoresCambio2.Add("$valorm", registro.ValorMetroCuadrado.ToString());
                        valoresCambio2.Add("$valorsector", "-");
                        valoresCambio2.Add("$tipoVivienda", registro.tipoVivienda);
                        valoresCambio2.Add("$estrato", registro.Estrato);
                        valoresCambio2.Add("$aniosConst", registro.anoConstruccion);
                        valoresCambio2.Add("$edadTradicion", registro.EdadJuridica);
                        valoresCambio2.Add("$tipoParqueadero", registro.tipoParqueadero);
                        valoresCambio2.Add("$avaluo", registro.avaluoComercial.ToString());
                        valoresCambio2.Add("$titulos", registro.conceptoJuridico);

                        //foreach (var valor in valoresCambio2)
                        //{
                        //    figura2 = figura2.Replace(valor.Key, valor.Value);
                        //}

                        //informaciones += figura2;
                        informaciones += $"<p class='contenido' style='align-text:center'><strong>Resultado:</strong> comentario resultado</p>";
                        informaciones += $"<p class='contenido' style='align-text:center'>Fuente: Área de Crédito y Cartera, Caja Promotora de Vivienda Militar y de Policía, {registro.fechaCreacion.Year}</p>";

                    }
                    ordenDesarrollo += informaciones;




                }
            }

            values.Add("$fechaAprobacion", DateTime.Now.ToString("dd-MM-yyyy"));
            values.Add("$version", "013");
            values.Add("$numeroComite", comite[0].NumeroComite.ToString());
            values.Add("$año", DateTime.Parse(comite[0].Fecha.Split(" ")[0], new CultureInfo("en-CA")).Year.ToString());
            values.Add("$fecha", DateTime.Parse(comite[0].Fecha.Split(" ")[0], new CultureInfo("en-CA")).ToShortDateString());
            values.Add("$lugar", comite[0].Lugar);
            values.Add("$horaInicio", comite[0].HoraInicio);
            values.Add("$horaFin", comite[0].HoraFinalizacion);

            values.Add("$ESPACIO PARA ASISTENTES", listaAsistentes);
            values.Add("$ESPACIO PARA INVITADOS", listaInvitados);

            values.Add("$ordenDia", listaOrdenDia);
            values.Add("$DESARROLLO", ordenDesarrollo);

            string firmas = string.Empty;/* "<div style='page-break-before: always'></div>";*/
            firmas += "<p class='contenido'> Una vez revisado el orden del día y sin observaciones de los asistentes se da cierre al Comité de Crédito.</p><br/><br/><br/><br/>";
            foreach (var asistente in integrantes.ToList())
            {
                if (asistente.tipo == "Asistente")
                {
                    firmas += $"<p class='contenido' style='text-align:center'><strong>{asistente.nombre}</strong></p><p class='contenido' style='text-align:center'>{asistente.cargo}</p><br/><br/>";
                }

            }
            basedocument += "<br/>" + firmas;

            return await CrearDocumento(basedocument, Styles, TipoDocumentoArchivo.PDF, Guid.NewGuid().ToString().ToUpper(), values, null, "S", "");

        }

        internal async Task<FileResult> GenerarFichaRiesgo(DatosSolicitudComite respuesta, SimulacionCliente simulacion, HistorialCredito historial, SimulacionDatosPersonales datos, ConsultaSolicitudCredito solicitud)
        {
            string BaseFilePath = @"C:\\Contenido\\Templates Credito\\2c7ce518-b480-4452-a2c4-29ef7b38d1c7\\";
            Dictionary<string, string> Values = new Dictionary<string, string>();
            string basedocument = File.ReadAllText(BaseFilePath + @"552ddaf2-9cd8-4c34-b70b-f833a09a28c6.html");
            string styles = File.ReadAllText(BaseFilePath + @"ccb522a9-2cb0-4c89-8363-b8b3959b0b5b.css");
            var conversorALetras = new NumerosALetras();
            var tipoDocumento = string.Empty;
            switch (solicitud.TID_ID)
            {
                case 1:
                    tipoDocumento = "CEDULA DE CIUDADANIA";
                    break;
                default:
                    tipoDocumento = "";
                    break;

            }


            var Cial = JsonConvert.DeserializeObject<Root>(historial.CBC_HISTORIAL_CREDITO);

            Values.Add("$FechaSistema", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            Values.Add("$FechaProceso", simulacion.SMC_FECHA_SIMULACION.ToString("dd/MM/yyyy"));
            Values.Add("$NumeroSolicitud", respuesta.SOC_NUMERO_SOLICITUD.ToString());
            Values.Add("$TipoIdentificacion", tipoDocumento);
            Values.Add("$NumeroIdentificacion", datos.SDP_NUMERO_DOCUMENTO);
            Values.Add("$Nombres", datos.SDP_NOMBRES_APELLIDOS);
            Values.Add("$Ingresos", respuesta.TOTAL_INGRESOS.ToString("$#,##0"));
            Values.Add("$Egresos", respuesta.TOTAL_EGRESOS.ToString("$#,##0"));
            Values.Add("$CuotasAportadas", datos.SDP_CUOTAS.ToString());
            Values.Add("$MontoSolicitado", respuesta.SOP_VALOR_CREDITO.ToString("$#,##0"));
            Values.Add("$ValorCuota", simulacion.SMC_VALOR_CUOTA.ToString("$#,##0"));
            Values.Add("$PlazoCredito", respuesta.PLAZO_FINANCIACION.ToString());
            Values.Add("$CapacidadPagoDesprendible", "desprendible");
            Values.Add("$CapacidadPago", "sin desprendible");
            Values.Add("$Resultado", respuesta.SOC_DECISION_BURO);
            Values.Add("$LineaCredito", solicitud.TCR_ID == 2 ? "HIPOTECARIO" : "LEASING HABITACIONAL");
            Values.Add("$ProbabilidadIncumplimiento", "probabilidadincumplimiento");
            Values.Add("$PorcentajePE", "pe");
            Values.Add("$Elaboro", "");
            Values.Add("$Reviso", "");

            return await CrearDocumento(basedocument, styles, TipoDocumentoArchivo.PDF, Guid.NewGuid().ToString().ToUpper(), Values);

        }

        internal async Task<FileResult> GenerarPagareCartaInstrucciones(RespuestaCreditoBasicaDto requestBasico, RespuestaSolicitudCreditoProductoDto requestProducto,
                                                                        FileStreamResult basePagare, FileStreamResult baseCss, FileStreamResult header, 
                                                                        FileStreamResult footer)
        {
            var smReaderBase = new StreamReader(basePagare.FileStream);
            var smReaderCss = new StreamReader(baseCss.FileStream);
            var smReaderheader = new StreamReader(header.FileStream);
            var smReaderfooter = new StreamReader(footer.FileStream);
            string BaseFile = await smReaderBase.ReadToEndAsync();
            string CssFile = await smReaderCss.ReadToEndAsync();
            string headerString = await smReaderheader.ReadToEndAsync();
            string footerString = await smReaderfooter.ReadToEndAsync();
            Dictionary<string, string> Values = new Dictionary<string, string>();
            var conversorALetras = new NumerosALetras();


            Values.Add("$numero_pagare", $"00001");
            Values.Add("$nombres_completos", $"{requestBasico.SOB_PRIMER_NOMBRE} {requestBasico.SOB_SEGUNDO_NOMBRE} {requestBasico.SOB_PRIMER_APELLIDO} {requestBasico.SOB_SEGUNDO_APELLIDO}");
            Values.Add("$fecha_suscripcion", $"{DateTime.Now.ToString("dd-MM-yyyy")}");
            Values.Add("$monto_leasing", $"{requestProducto.SOP_VALOR_CREDITO}");
            Values.Add("$plazo", $"{requestProducto.SOP_PLAZO_FINANCIACION}");
            Values.Add("$tasa_financiacion", $"");//ToDo
            Values.Add("$ciudad", $"Bogota D.C.");
            Values.Add("$numero_canones", $"");//ToDo
            Values.Add("$valor_canon", $"");//ToDo
            Values.Add("$fecha_pago_primer", $"");//ToDo
            Values.Add("$lugar_creacion", $"");//ToDo
            Values.Add("$diaNum", $"{DateTime.Now.Day}");
            Values.Add("$dia", $"{conversorALetras.GetDayInLetters(DateTime.Now)}");
            Values.Add("$mesNum", $"{DateTime.Now.Month}");
            Values.Add("$mes", $"{conversorALetras.GetMonthInLetters(DateTime.Now)}");
            Values.Add("$añoNum", $"{DateTime.Now.Year}");
            Values.Add("$año", $"{conversorALetras.GetYearInLetters(DateTime.Now)}");



            return await CrearDocumento(BaseFile, CssFile, TipoDocumentoArchivo.PDF, Guid.NewGuid().ToString(), Values,
                                             null, headerString, footerString);
        }

        /// <summary>
        /// Genera pdf para Historial comercial
        /// </summary>
        /// <param name="DatosSolicitud"></param>
        /// <returns></returns>
        internal async Task<FileResult> GenerarHistorialComercial(Root Root, FileStreamResult basefile, FileStreamResult baseCss, FileStreamResult baseCuentasVigentes, FileStreamResult baseObligacionesExtinguidas, FileStreamResult baseObligacionesVigentes, FileStreamResult baseInformacionConsolidadaTrimestreI, FileStreamResult baseInformacionDetalladaTrimestreI, FileStreamResult baseInformacionConsolidadaTrimestreII, FileStreamResult baseInformacionDetalladaTrimestreII, FileStreamResult baseInformacionConsolidadaTrimestreIII, FileStreamResult baseInformacionDetalladaTrimestreIII)
        {
            Dictionary<string, string> Values = new Dictionary<string, string>();
            string Basedocument = await (new StreamReader(basefile.FileStream)).ReadToEndAsync();
            string Styles = await (new StreamReader(baseCss.FileStream)).ReadToEndAsync();


            //Añado valores a reemplazar en el documento
            #region Resultado Consulta Informacion Comercial
            Values.Add("fecha-hora", Root.Response.Tercero.Fecha + " " + Root.Response.Tercero.Hora);
            Values.Add("tipoDocumento", Root.Response.Tercero.TipoIdentificacion);
            Values.Add("numIdentificacion", Root.Response.Tercero.NumeroIdentificacion);
            Values.Add("nombreApellido", Root.Response.Tercero.NombreTitular);
            Values.Add("estadoDocumento", Root.Response.Tercero.Estado);
            Values.Add("fechaExpedicion", Root.Response.Tercero.FechaExpedicion);
            Values.Add("actividadEconomica", Root.Response.Tercero.NombreCiiu != string.Empty ? Root.Response.Tercero.NombreCiiu : "-");
            Values.Add("lugarExpedicion", Root.Response.Tercero.LugarExpedicion);
            Values.Add("rangoEdad", Root.Response.Tercero.RangoEdad);
            Values.Add("fecha", Root.Response.Tercero.Fecha);
            Values.Add("hora", Root.Response.Tercero.Hora);
            Values.Add("usuario", Root.Response.Tercero.Entidad);
            Values.Add("informeNumero", Root.Response.Tercero.NumeroInforme);
            #endregion
            #region Resumen Endeudamiento Obligaciones
            var ResumenEndeudamientoObligaciones = Root.Response.Tercero.Consolidado.ResumenPrincipal.Registro[1];

            Values.Add("REOTOCANT", ResumenEndeudamientoObligaciones.NumeroObligaciones != "0" ? ResumenEndeudamientoObligaciones.NumeroObligaciones : "-");
            Values.Add("REOTOST", ResumenEndeudamientoObligaciones.TotalSaldo != "0" ? ResumenEndeudamientoObligaciones.TotalSaldo : "-");
            Values.Add("REOTOPADE", ResumenEndeudamientoObligaciones.ParticipacionDeuda != "0" ? ResumenEndeudamientoObligaciones.ParticipacionDeuda : "-");
            Values.Add("REOODCANT", ResumenEndeudamientoObligaciones.CuotaObligacionesDia != "0" ? ResumenEndeudamientoObligaciones.CuotaObligacionesDia : "-");
            Values.Add("REOODST", ResumenEndeudamientoObligaciones.SaldoObligacionesDia != "0" ? ResumenEndeudamientoObligaciones.SaldoObligacionesDia : "-");
            Values.Add("REOODCUOT", ResumenEndeudamientoObligaciones.CuotaObligacionesDia != "0" ? ResumenEndeudamientoObligaciones.CuotaObligacionesDia : "-");
            Values.Add("REOOMCANT", ResumenEndeudamientoObligaciones.CantidadObligacionesMora != "0" ? ResumenEndeudamientoObligaciones.CantidadObligacionesMora : "-");
            Values.Add("REOOMST", ResumenEndeudamientoObligaciones.SaldoObligacionesMora != "0" ? ResumenEndeudamientoObligaciones.SaldoObligacionesMora : "-");
            Values.Add("REOOMCUOT", ResumenEndeudamientoObligaciones.CuotaObligacionesMora != "0" ? ResumenEndeudamientoObligaciones.CuotaObligacionesMora : "-");
            Values.Add("REOOMVM", "-");
            #endregion
            #region Subtotal Principal

            var SubtotalPrincipal = Root.Response.Tercero.Consolidado.ResumenPrincipal.Registro[0];

            Values.Add("STPTCANT", SubtotalPrincipal.NumeroObligaciones != "0" ? SubtotalPrincipal.NumeroObligaciones : "-");
            Values.Add("STPTST", SubtotalPrincipal.TotalSaldo != "0" ? SubtotalPrincipal.TotalSaldo : "-");
            Values.Add("STPTPADE", SubtotalPrincipal.ParticipacionDeuda != "0" ? SubtotalPrincipal.ParticipacionDeuda : "-");
            Values.Add("STPODCANT", SubtotalPrincipal.NumeroObligacionesDia != "0" ? SubtotalPrincipal.NumeroObligacionesDia : "-");
            Values.Add("STPODST", SubtotalPrincipal.SaldoObligacionesDia != "0" ? SubtotalPrincipal.SaldoObligacionesDia : "-");
            Values.Add("STPODCUOT", SubtotalPrincipal.CuotaObligacionesDia != "0" ? SubtotalPrincipal.CuotaObligacionesDia : "-");
            Values.Add("STPOMCANT", SubtotalPrincipal.CantidadObligacionesMora != "0" ? SubtotalPrincipal.CantidadObligacionesMora : "-");
            Values.Add("STPOMST", SubtotalPrincipal.SaldoObligacionesMora != "0" ? SubtotalPrincipal.SaldoObligacionesMora : "-");
            Values.Add("STPOMCUOT", SubtotalPrincipal.CuotaObligacionesMora != "0" ? SubtotalPrincipal.CuotaObligacionesMora : "-");
            Values.Add("STPOMVM", "-");
            #endregion
            #region Resumen Total obligaciones
            var ResumenTotalObligaciones = Root.Response.Tercero.Consolidado.Registro;

            Values.Add("RETOBTCANT", ResumenTotalObligaciones.NumeroObligaciones != "0" ? ResumenTotalObligaciones.NumeroObligaciones : "-");
            Values.Add("RETOBTST", ResumenTotalObligaciones.TotalSaldo != "0" ? ResumenTotalObligaciones.TotalSaldo : "-");
            Values.Add("RETOBTPADE", ResumenTotalObligaciones.ParticipacionDeuda != "0" ? ResumenTotalObligaciones.ParticipacionDeuda : "-");
            Values.Add("RETOBODCANT", ResumenTotalObligaciones.NumeroObligacionesDia != "0" ? ResumenTotalObligaciones.NumeroObligacionesDia : "-");
            Values.Add("RETOBODST", ResumenTotalObligaciones.SaldoObligacionesDia != "0" ? ResumenTotalObligaciones.SaldoObligacionesDia : "-");
            Values.Add("RETOBODCUOT", ResumenTotalObligaciones.CuotaObligacionesDia != "0" ? ResumenTotalObligaciones.CuotaObligacionesDia : "-");
            Values.Add("RETOBOMCANT", ResumenTotalObligaciones.CantidadObligacionesMora != "0" ? ResumenTotalObligaciones.CantidadObligacionesMora : "-");
            Values.Add("RETOBOMST", ResumenTotalObligaciones.SaldoObligacionesMora != "0" ? ResumenTotalObligaciones.SaldoObligacionesMora : "-");
            Values.Add("RETOBOMCUOT", ResumenTotalObligaciones.CuotaObligacionesMora != "0" ? ResumenTotalObligaciones.CuotaObligacionesMora : "-");
            Values.Add("RETOBOMVM", "-");
            #endregion
            #region Informacion de Cuentas
            var InformacionCuentasVigentes = Root.Response.Tercero.CuentasVigentes.Obligacion;
            string CuentasVigentes = string.Empty;
            string BaseCuentasVigentes = await (new StreamReader(baseCuentasVigentes.FileStream)).ReadToEndAsync();

            for (int x = InformacionCuentasVigentes.Count - 1; x >= 0; x--)
            {
                string Cuenta = BaseCuentasVigentes;
                Cuenta = Cuenta.Replace("fechaCorte", InformacionCuentasVigentes[x].FechaCorte != string.Empty ? InformacionCuentasVigentes[x].FechaCorte : "N.A.");
                Cuenta = Cuenta.Replace("tipoContrato", InformacionCuentasVigentes[x].TipoContrato != string.Empty ? InformacionCuentasVigentes[x].TipoContrato.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("cuenta", InformacionCuentasVigentes[x].NumeroObligacion != string.Empty ? InformacionCuentasVigentes[x].NumeroObligacion.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("estado", InformacionCuentasVigentes[x].EstadoObligacion != string.Empty ? InformacionCuentasVigentes[x].EstadoObligacion.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("tipoEntidad", InformacionCuentasVigentes[x].TipoEntidad != string.Empty ? InformacionCuentasVigentes[x].TipoEntidad.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("entidad", InformacionCuentasVigentes[x].NombreEntidad != string.Empty ? InformacionCuentasVigentes[x].NombreEntidad.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("ciudad", InformacionCuentasVigentes[x].Ciudad != string.Empty ? InformacionCuentasVigentes[x].Ciudad.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("sucursal", InformacionCuentasVigentes[x].Sucursal != string.Empty ? InformacionCuentasVigentes[x].Sucursal.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("fechaApertura", InformacionCuentasVigentes[x].FechaApertura != string.Empty ? InformacionCuentasVigentes[x].FechaApertura.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("cupoSobregiro", InformacionCuentasVigentes[x].ValorInicial != string.Empty ? InformacionCuentasVigentes[x].ValorInicial.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("diasAutor", InformacionCuentasVigentes[x].DiasCartera != string.Empty ? InformacionCuentasVigentes[x].DiasCartera.ToString() : "N.A.");
                Cuenta = Cuenta.Replace("fechaPermanencia", InformacionCuentasVigentes[x].FechaPermanencia != string.Empty ? InformacionCuentasVigentes[x].FechaPermanencia.ToString() : "-");
                Cuenta = Cuenta.Replace("CDUM", InformacionCuentasVigentes[x].ChequesDevueltos != string.Empty ? InformacionCuentasVigentes[x].ChequesDevueltos : "N.A.");
                CuentasVigentes += Cuenta;
            }


            Values.Add("<td>ESPACIO PARA INFORMACION CUENTAS</td>", CuentasVigentes);
            #endregion
            #region Informacion Obligaciones
            var ObligacionesDia = Root.Response.Tercero.SectorFinancieroAlDia.Obligacion;

            var ObligacionesExtingidas = Root.Response.Tercero.SectorFinancieroExtinguidas.Obligacion;

            string BaseObligacionesExtinguidas = await (new StreamReader(baseObligacionesExtinguidas.FileStream)).ReadToEndAsync();
            string ObligacionesNoVigentes = string.Empty;

            string BaseObligacionesVigentes = await (new StreamReader(baseObligacionesVigentes.FileStream)).ReadToEndAsync();
            string ObligacionesVigentes = string.Empty;

            for (int x = 0; x <= ObligacionesDia.Count - 1; x++)
            {
                string Obligacion = BaseObligacionesVigentes;
                Obligacion = Obligacion.Replace("fechaCorte", ObligacionesDia[x].FechaCorte != string.Empty ? ObligacionesDia[x].FechaCorte : "-");
                Obligacion = Obligacion.Replace("moda", ObligacionesDia[x].ModalidadCredito != string.Empty ? ObligacionesDia[x].ModalidadCredito : "-");
                Obligacion = Obligacion.Replace("noObligacion", ObligacionesDia[x].NumeroObligacion != string.Empty ? ObligacionesDia[x].NumeroObligacion : "-");
                Obligacion = Obligacion.Replace("tipoEntidad", ObligacionesDia[x].TipoEntidad != string.Empty ? ObligacionesDia[x].TipoEntidad : "-");
                Obligacion = Obligacion.Replace("nombreEntidad", ObligacionesDia[x].NombreEntidad != string.Empty ? ObligacionesDia[x].NombreEntidad : "-");
                Obligacion = Obligacion.Replace("ciudad", ObligacionesDia[x].Ciudad != string.Empty ? ObligacionesDia[x].Ciudad : "-");
                Obligacion = Obligacion.Replace("cal", ObligacionesDia[x].Calidad != string.Empty ? ObligacionesDia[x].Calidad : "-");
                Obligacion = Obligacion.Replace("mrc", ObligacionesDia[x].MarcaTarjeta ?? "-");
                Obligacion = Obligacion.Replace("tipoGar", ObligacionesDia[x].TipoGarantia != string.Empty ? ObligacionesDia[x].TipoGarantia : "-");
                Obligacion = Obligacion.Replace("fInicio", ObligacionesDia[x].FechaApertura != string.Empty ? ObligacionesDia[x].FechaApertura : "-");
                Obligacion = Obligacion.Replace("pac", ObligacionesDia[x].NumeroCuotasPactadas != "0" ? ObligacionesDia[x].NumeroCuotasPactadas : "-");
                Obligacion = Obligacion.Replace("pag", ObligacionesDia[x].CuotasCanceladas != "0" ? ObligacionesDia[x].CuotasCanceladas : "-");
                Obligacion = Obligacion.Replace("mor", ObligacionesDia[x].NumeroCuotasMora != "0" ? ObligacionesDia[x].NumeroCuotasMora : "-");
                Obligacion = Obligacion.Replace("cupoAprob", ObligacionesDia[x].ValorInicial != string.Empty ? ObligacionesDia[x].ValorInicial : "-");
                Obligacion = Obligacion.Replace("pMinimo", ObligacionesDia[x].ValorCuota != string.Empty ? ObligacionesDia[x].ValorCuota : "-");
                Obligacion = Obligacion.Replace("sitOblig", ObligacionesDia[x].EstadoObligacion != string.Empty ? ObligacionesDia[x].EstadoObligacion : "-");
                Obligacion = Obligacion.Replace("natuRees", ObligacionesDia[x].NaturalezaReestructuracion != string.Empty ? ObligacionesDia[x].NaturalezaReestructuracion : "-");
                Obligacion = Obligacion.Replace("noRee", ObligacionesDia[x].NumeroReestructuraciones != string.Empty ? ObligacionesDia[x].NumeroReestructuraciones : "-");
                Obligacion = Obligacion.Replace("tipPag", ObligacionesDia[x].TipoPago != string.Empty ? ObligacionesDia[x].TipoPago : "-");
                Obligacion = Obligacion.Replace("fPago", ObligacionesDia[x].FechaPago != string.Empty ? ObligacionesDia[x].FechaPago : "-");
                Obligacion = Obligacion.Replace("tipoCont", ObligacionesDia[x].TipoContrato != string.Empty ? ObligacionesDia[x].TipoContrato : "-");
                Obligacion = Obligacion.Replace("pade", ObligacionesDia[x].ParticipacionDeuda != string.Empty ? ObligacionesDia[x].ParticipacionDeuda : "-");
                Obligacion = Obligacion.Replace("lcre", ObligacionesDia[x].LineaCredito != string.Empty ? ObligacionesDia[x].LineaCredito : "-");
                Obligacion = Obligacion.Replace("estContr", ObligacionesDia[x].EstadoContrato != string.Empty ? ObligacionesDia[x].EstadoContrato : "-");
                Obligacion = Obligacion.Replace("clf", ObligacionesDia[x].Calificacion != string.Empty ? ObligacionesDia[x].Calificacion : "-");
                Obligacion = Obligacion.Replace("origenCartera", ObligacionesDia[x].EntidadOriginadoraCartera != string.Empty ? ObligacionesDia[x].EntidadOriginadoraCartera : "-");
                Obligacion = Obligacion.Replace("sucursal", ObligacionesDia[x].Sucursal != string.Empty ? ObligacionesDia[x].Sucursal : "-");
                Obligacion = Obligacion.Replace("estTitu", ObligacionesDia[x].EstadoTitular != string.Empty ? ObligacionesDia[x].EstadoTitular : "-");
                Obligacion = Obligacion.Replace("cls", ObligacionesDia[x].ClaseTarjeta ?? "-");
                Obligacion = Obligacion.Replace("cobGar", ObligacionesDia[x].CubrimientoGarantia != "0" ? ObligacionesDia[x].CubrimientoGarantia : "-");
                Obligacion = Obligacion.Replace("fTerm", ObligacionesDia[x].FechaTerminacion != string.Empty ? ObligacionesDia[x].FechaTerminacion : "-");
                Obligacion = Obligacion.Replace("per", ObligacionesDia[x].Periodicidad != string.Empty ? ObligacionesDia[x].Periodicidad : "-");
                Obligacion = Obligacion.Replace("cupoUtili", ObligacionesDia[x].SaldoObligacion != string.Empty ? ObligacionesDia[x].SaldoObligacion : "-");
                Obligacion = Obligacion.Replace("valorMora", ObligacionesDia[x].ValorMora != "0" ? ObligacionesDia[x].ValorMora : "-");
                Obligacion = Obligacion.Replace("rees", ObligacionesDia[x].Reestructurado != string.Empty ? ObligacionesDia[x].Reestructurado : "-");
                Obligacion = Obligacion.Replace("MorMax", ObligacionesDia[x].MoraMaxima != string.Empty ? ObligacionesDia[x].MoraMaxima : "-");
                Obligacion = Obligacion.Replace("modExt", ObligacionesDia[x].ModoExtincion != string.Empty ? ObligacionesDia[x].ModoExtincion : "-");
                Obligacion = Obligacion.Replace("fPerman", ObligacionesDia[x].FechaPermanencia != string.Empty ? ObligacionesDia[x].FechaPermanencia : "-");
                var ComportamientosList = ObligacionesDia[x].Comportamientos.Split("|").ToList();
                ComportamientosList.Remove("");
                var ComportamientosArr = ComportamientosList.ToArray();
                for (int y = 0; y < ComportamientosArr.Length - 1; y++)
                {
                    string N = "N" + (y).ToString() + "<";
                    string Reemplazo = ComportamientosArr[y] + "<";
                    Obligacion = Obligacion.Replace(N, Reemplazo);
                }
                ObligacionesVigentes += Obligacion;
            }

            for (int x = ObligacionesExtingidas.Count - 1; x >= 0; x--)
            {
                string Obligacion = BaseObligacionesExtinguidas;
                Obligacion = Obligacion.Replace("fechaCorte", ObligacionesExtingidas[x].FechaCorte != string.Empty ? ObligacionesExtingidas[x].FechaCorte : "-");
                Obligacion = Obligacion.Replace("moda", ObligacionesExtingidas[x].ModalidadCredito != string.Empty ? ObligacionesExtingidas[x].ModalidadCredito : "-");
                Obligacion = Obligacion.Replace("noObligacion", ObligacionesExtingidas[x].NumeroObligacion != string.Empty ? ObligacionesExtingidas[x].NumeroObligacion : "-");
                Obligacion = Obligacion.Replace("tipoEntidad", ObligacionesExtingidas[x].TipoEntidad != string.Empty ? ObligacionesExtingidas[x].TipoEntidad : "-");
                Obligacion = Obligacion.Replace("nombreEntidad", ObligacionesExtingidas[x].NombreEntidad != string.Empty ? ObligacionesExtingidas[x].NombreEntidad : "-");
                Obligacion = Obligacion.Replace("ciudad", ObligacionesExtingidas[x].Ciudad != string.Empty ? ObligacionesExtingidas[x].Ciudad : "-");
                Obligacion = Obligacion.Replace("cal", ObligacionesExtingidas[x].Calidad != string.Empty ? ObligacionesExtingidas[x].Calidad : "-");
                Obligacion = Obligacion.Replace("mrc", ObligacionesExtingidas[x].MarcaTarjeta ?? "-");
                Obligacion = Obligacion.Replace("tipoGar", ObligacionesExtingidas[x].TipoGarantia != string.Empty ? ObligacionesExtingidas[x].TipoGarantia : "-");
                Obligacion = Obligacion.Replace("fInicio", ObligacionesExtingidas[x].FechaApertura != string.Empty ? ObligacionesExtingidas[x].FechaApertura : "-");
                Obligacion = Obligacion.Replace("pac", ObligacionesExtingidas[x].NumeroCuotasPactadas != "0" ? ObligacionesExtingidas[x].NumeroCuotasPactadas : "-");
                Obligacion = Obligacion.Replace("pag", ObligacionesExtingidas[x].CuotasCanceladas != "0" ? ObligacionesExtingidas[x].CuotasCanceladas : "-");
                Obligacion = Obligacion.Replace("mor", ObligacionesExtingidas[x].NumeroCuotasMora != "0" ? ObligacionesExtingidas[x].NumeroCuotasMora : "-");
                Obligacion = Obligacion.Replace("cupoAprob", ObligacionesExtingidas[x].ValorInicial != string.Empty ? ObligacionesExtingidas[x].ValorInicial : "-");
                Obligacion = Obligacion.Replace("pMinimo", ObligacionesExtingidas[x].ValorCuota != string.Empty ? ObligacionesExtingidas[x].ValorCuota : "-");
                Obligacion = Obligacion.Replace("sitOblig", ObligacionesExtingidas[x].EstadoObligacion != string.Empty ? ObligacionesExtingidas[x].EstadoObligacion : "-");
                Obligacion = Obligacion.Replace("natuRees", ObligacionesExtingidas[x].NaturalezaReestructuracion != string.Empty ? ObligacionesExtingidas[x].NaturalezaReestructuracion : "-");
                Obligacion = Obligacion.Replace("noRee", ObligacionesExtingidas[x].NumeroReestructuraciones != string.Empty ? ObligacionesExtingidas[x].NumeroReestructuraciones : "-");
                Obligacion = Obligacion.Replace("tipPag", ObligacionesExtingidas[x].TipoPago != string.Empty ? ObligacionesExtingidas[x].TipoPago : "-");
                Obligacion = Obligacion.Replace("fPago", ObligacionesExtingidas[x].FechaPago != string.Empty ? ObligacionesExtingidas[x].FechaPago : "-");
                Obligacion = Obligacion.Replace("tipoCont", ObligacionesExtingidas[x].TipoContrato != string.Empty ? ObligacionesExtingidas[x].TipoContrato : "-");
                Obligacion = Obligacion.Replace("pade", ObligacionesExtingidas[x].ParticipacionDeuda != string.Empty ? ObligacionesExtingidas[x].ParticipacionDeuda : "-");
                Obligacion = Obligacion.Replace("lcre", ObligacionesExtingidas[x].LineaCredito != string.Empty ? ObligacionesExtingidas[x].LineaCredito : "-");
                Obligacion = Obligacion.Replace("estContr", ObligacionesExtingidas[x].EstadoContrato != string.Empty ? ObligacionesExtingidas[x].EstadoContrato : "-");
                Obligacion = Obligacion.Replace("clf", ObligacionesExtingidas[x].Calificacion != string.Empty ? ObligacionesExtingidas[x].Calificacion : "-");
                Obligacion = Obligacion.Replace("origenCartera", ObligacionesExtingidas[x].EntidadOriginadoraCartera != string.Empty ? ObligacionesExtingidas[x].EntidadOriginadoraCartera : "-");
                Obligacion = Obligacion.Replace("sucursal", ObligacionesExtingidas[x].Sucursal != string.Empty ? ObligacionesExtingidas[x].Sucursal : "-");
                Obligacion = Obligacion.Replace("estTitu", ObligacionesExtingidas[x].EstadoTitular != string.Empty ? ObligacionesExtingidas[x].EstadoTitular : "-");
                Obligacion = Obligacion.Replace("cls", ObligacionesExtingidas[x].ClaseTarjeta ?? "-");
                Obligacion = Obligacion.Replace("cobGar", ObligacionesExtingidas[x].CubrimientoGarantia != "0" ? ObligacionesExtingidas[x].CubrimientoGarantia : "-");
                Obligacion = Obligacion.Replace("fTerm", ObligacionesExtingidas[x].FechaTerminacion != string.Empty ? ObligacionesExtingidas[x].FechaTerminacion : "-");
                Obligacion = Obligacion.Replace("per", ObligacionesExtingidas[x].Periodicidad != string.Empty ? ObligacionesExtingidas[x].Periodicidad : "-");
                Obligacion = Obligacion.Replace("cupoUtili", ObligacionesExtingidas[x].SaldoObligacion != string.Empty ? ObligacionesExtingidas[x].SaldoObligacion : "-");
                Obligacion = Obligacion.Replace("valorMora", ObligacionesExtingidas[x].ValorMora != "0" ? ObligacionesExtingidas[x].ValorMora : "-");
                Obligacion = Obligacion.Replace("rees", ObligacionesExtingidas[x].Reestructurado != string.Empty ? ObligacionesExtingidas[x].Reestructurado : "-");
                Obligacion = Obligacion.Replace("MorMax", ObligacionesExtingidas[x].MoraMaxima != string.Empty ? ObligacionesExtingidas[x].MoraMaxima : "-");
                Obligacion = Obligacion.Replace("modExt", ObligacionesExtingidas[x].ModoExtincion != string.Empty ? ObligacionesExtingidas[x].ModoExtincion : "-");
                Obligacion = Obligacion.Replace("fPerman", ObligacionesExtingidas[x].FechaPermanencia != string.Empty ? ObligacionesExtingidas[x].FechaPermanencia : "-");
                var ComportamientosList = ObligacionesExtingidas[x].Comportamientos.Split("|").ToList();
                ComportamientosList.Remove("");
                var ComportamientosArr = ComportamientosList.ToArray();
                for (int y = 0; y < ComportamientosArr.Length - 1; y++)
                {
                    string N = "N" + (y).ToString() + "<";
                    string Reemplazo = ComportamientosArr[y] + "<";
                    Obligacion = Obligacion.Replace(N, Reemplazo);
                }
                ObligacionesNoVigentes += Obligacion;
            }

            Values.Add("<td>CAMPO PARA OBLIGACIONES VIGENTES Y AL DIA</td>", ObligacionesVigentes);
            Values.Add("<td>CAMPO PARA OBLIGACIONES EXTINGUIDAS</td>", ObligacionesNoVigentes);
            #endregion
            #region Informacion Consolidada Trimestre I
            string BaseInformacionConsolidadaTrimestreI = await (new StreamReader(baseInformacionConsolidadaTrimestreI.FileStream)).ReadToEndAsync();
            var EndeudamientoConsolidadoI = Root.Response.Tercero.Endeudamiento.EndeudamientoTrimI;

            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("calificacion3", EndeudamientoConsolidadoI.Endeudamiento71[2].Calificacion);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nTipoMoneda", EndeudamientoConsolidadoI.Endeudamiento71[2].TipoModena);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nDeudasCial", EndeudamientoConsolidadoI.Endeudamiento71[2].NumeroOperacionesComercial);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nDeudasCons", EndeudamientoConsolidadoI.Endeudamiento71[2].NumeroOperacionesConsumo);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nDeudasVivi", EndeudamientoConsolidadoI.Endeudamiento71[2].NumeroOperacionesVivienda);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nDeudasMcr", EndeudamientoConsolidadoI.Endeudamiento71[2].NumeroOperacionesMicrocredito);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nValorCial", EndeudamientoConsolidadoI.Endeudamiento71[2].ValorDeudaComercial);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nValorsCons", EndeudamientoConsolidadoI.Endeudamiento71[2].ValorDeudaConsumo);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nValorVivi", EndeudamientoConsolidadoI.Endeudamiento71[2].ValorDeudaVivienda);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nValorMcr", EndeudamientoConsolidadoI.Endeudamiento71[2].ValorDeudaMicrocredito);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nTotal", EndeudamientoConsolidadoI.Endeudamiento71[2].Total);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nPade", EndeudamientoConsolidadoI.Endeudamiento71[2].ParticipacionTotalDeudas);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nCubrimientoCial", EndeudamientoConsolidadoI.Endeudamiento71[2].CubrimientoGarantiaComercial);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nCubrimientoCons", EndeudamientoConsolidadoI.Endeudamiento71[2].CubrimientoGarantiaConsumo);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nCubrimientoVivi", EndeudamientoConsolidadoI.Endeudamiento71[2].CubrimientoGarantiaVivienda);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("nCubrimientoMcr", "-");

            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("calificacion2", EndeudamientoConsolidadoI.Endeudamiento71[1].Calificacion);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tTipoMoneda", EndeudamientoConsolidadoI.Endeudamiento71[1].TipoModena);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tDeudasCial", EndeudamientoConsolidadoI.Endeudamiento71[1].NumeroOperacionesComercial);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tDeudasCons", EndeudamientoConsolidadoI.Endeudamiento71[1].NumeroOperacionesConsumo);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tDeudasVivi", EndeudamientoConsolidadoI.Endeudamiento71[1].NumeroOperacionesVivienda);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tDeudasMcr", EndeudamientoConsolidadoI.Endeudamiento71[1].NumeroOperacionesMicrocredito);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tValorCial", EndeudamientoConsolidadoI.Endeudamiento71[1].ValorDeudaComercial);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tValorsCons", EndeudamientoConsolidadoI.Endeudamiento71[1].ValorDeudaConsumo);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tValorVivi", EndeudamientoConsolidadoI.Endeudamiento71[1].ValorDeudaVivienda);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tValorMcr", EndeudamientoConsolidadoI.Endeudamiento71[1].ValorDeudaMicrocredito);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tTotal", EndeudamientoConsolidadoI.Endeudamiento71[1].Total);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tPade", EndeudamientoConsolidadoI.Endeudamiento71[1].ParticipacionTotalDeudas);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tCubrimientoCial", EndeudamientoConsolidadoI.Endeudamiento71[1].CubrimientoGarantiaComercial);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tCubrimientoCons", EndeudamientoConsolidadoI.Endeudamiento71[1].CubrimientoGarantiaConsumo);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tCubrimientoVivi", EndeudamientoConsolidadoI.Endeudamiento71[1].CubrimientoGarantiaVivienda);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("tCubrimientoMcr", "-");

            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("calificacion1", EndeudamientoConsolidadoI.Endeudamiento71[0].Calificacion);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aTipoMoneda", EndeudamientoConsolidadoI.Endeudamiento71[0].TipoModena);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aDeudasCial", EndeudamientoConsolidadoI.Endeudamiento71[0].NumeroOperacionesComercial);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aDeudasCons", EndeudamientoConsolidadoI.Endeudamiento71[0].NumeroOperacionesConsumo);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aDeudasVivi", EndeudamientoConsolidadoI.Endeudamiento71[0].NumeroOperacionesVivienda);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aDeudasMcr", EndeudamientoConsolidadoI.Endeudamiento71[0].NumeroOperacionesMicrocredito);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aValorCial", EndeudamientoConsolidadoI.Endeudamiento71[0].ValorDeudaComercial);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aValorsCons", EndeudamientoConsolidadoI.Endeudamiento71[0].ValorDeudaConsumo);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aValorVivi", EndeudamientoConsolidadoI.Endeudamiento71[0].ValorDeudaVivienda);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aValorMcr", EndeudamientoConsolidadoI.Endeudamiento71[0].ValorDeudaMicrocredito);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aTotal", EndeudamientoConsolidadoI.Endeudamiento71[0].Total);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aPade", EndeudamientoConsolidadoI.Endeudamiento71[0].ParticipacionTotalDeudas);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aCubrimientoCial", EndeudamientoConsolidadoI.Endeudamiento71[0].CubrimientoGarantiaComercial);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aCubrimientoCons", EndeudamientoConsolidadoI.Endeudamiento71[0].CubrimientoGarantiaConsumo);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aCubrimientoVivi", EndeudamientoConsolidadoI.Endeudamiento71[0].CubrimientoGarantiaVivienda);
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("aCubrimientoMcr", "-");

            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("mlNumero", EndeudamientoConsolidadoI.Endeudamiento72[2].NumeroContingencias != string.Empty ? EndeudamientoConsolidadoI.Endeudamiento72[2].NumeroContingencias : "-");
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("mlValor", decimal.Parse(EndeudamientoConsolidadoI.Endeudamiento72[2].ValorContingencias) > 0 ? EndeudamientoConsolidadoI.Endeudamiento72[2].ValorContingencias : "-");
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("mlCuota", decimal.Parse(EndeudamientoConsolidadoI.Endeudamiento72[2].CuotaEsperada) > 0 ? EndeudamientoConsolidadoI.Endeudamiento72[2].CuotaEsperada : "-");
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("mlCumplimiento", decimal.Parse(EndeudamientoConsolidadoI.Endeudamiento72[2].CumplimientoCuota) > 0 ? EndeudamientoConsolidadoI.Endeudamiento72[2].CumplimientoCuota : "-");

            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("meNumero", EndeudamientoConsolidadoI.Endeudamiento72[1].NumeroContingencias != string.Empty ? EndeudamientoConsolidadoI.Endeudamiento72[2].NumeroContingencias : "-");
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("meValor", decimal.Parse(EndeudamientoConsolidadoI.Endeudamiento72[1].ValorContingencias) > 0 ? EndeudamientoConsolidadoI.Endeudamiento72[2].ValorContingencias : "-");
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("meCuota", decimal.Parse(EndeudamientoConsolidadoI.Endeudamiento72[1].CuotaEsperada) > 0 ? EndeudamientoConsolidadoI.Endeudamiento72[2].CuotaEsperada : "-");
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("meCumplimiento", EndeudamientoConsolidadoI.Endeudamiento72[1].CumplimientoCuota != string.Empty ? EndeudamientoConsolidadoI.Endeudamiento72[2].CumplimientoCuota : "-");

            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("totNumero", EndeudamientoConsolidadoI.Endeudamiento72[0].NumeroContingencias != string.Empty ? EndeudamientoConsolidadoI.Endeudamiento72[2].NumeroContingencias : "-");
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("totValor", decimal.Parse(EndeudamientoConsolidadoI.Endeudamiento72[0].ValorContingencias) > 0 ? EndeudamientoConsolidadoI.Endeudamiento72[2].ValorContingencias : "-");
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("totCuota", decimal.Parse(EndeudamientoConsolidadoI.Endeudamiento72[0].CuotaEsperada) > 0 ? EndeudamientoConsolidadoI.Endeudamiento72[2].CuotaEsperada : "-");
            BaseInformacionConsolidadaTrimestreI = BaseInformacionConsolidadaTrimestreI.Replace("totCumplimiento", decimal.Parse(EndeudamientoConsolidadoI.Endeudamiento72[0].CumplimientoCuota) > 0 ? EndeudamientoConsolidadoI.Endeudamiento72[2].CumplimientoCuota : "-");


            Values.Add("ICTIF", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.FechaTrimestreI);
            Values.Add("ICTIN", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.NumeroEntidadesTrimestreI);
            Values.Add("<td>ESPACIO PARA INFORMACION CONSOLIDADA TRIMESTRE I</td>", BaseInformacionConsolidadaTrimestreI);
            #endregion
            #region Informacion Detallada Trimestre I
            string BaseInformacionDetalladaTrimestreI = await (new StreamReader(baseInformacionDetalladaTrimestreI.FileStream)).ReadToEndAsync();
            var EndeudamientoDetalladoI = Root.Response.Tercero.Endeudamiento.EndeudamientoTrimI.Endeudamiento73;
            string EndeudamientosTrimI = string.Empty;

            foreach (var Endeudamiento in EndeudamientoDetalladoI)
            {
                string CampoEndeudamiento = string.Empty;
                CampoEndeudamiento = BaseInformacionDetalladaTrimestreI;
                CampoEndeudamiento = CampoEndeudamiento.Replace("tipoEnt", Endeudamiento.TipoEntidad != string.Empty ? Endeudamiento.TipoEntidad : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("nombreEnt", Endeudamiento.NombreEntidad != string.Empty ? Endeudamiento.NombreEntidad : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("tipoEnt", Endeudamiento.TipoEntidadOriginadoraCartera != string.Empty ? Endeudamiento.TipoEntidadOriginadoraCartera : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("nombreEntCartera", Endeudamiento.EntidadOriginadoraCartera != string.Empty ? Endeudamiento.EntidadOriginadoraCartera : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("tipoFid", Endeudamiento.TipoFideicomiso != string.Empty ? Endeudamiento.TipoFideicomiso : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("noFideico", Endeudamiento.NumeroFideicomiso != string.Empty ? Endeudamiento.NumeroFideicomiso : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("modaCred", Endeudamiento.ModalidadCredito != string.Empty ? Endeudamiento.ModalidadCredito : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("calf", Endeudamiento.Calificacion != string.Empty ? Endeudamiento.Calificacion : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("tipoMon", Endeudamiento.TipoMoneda != string.Empty ? Endeudamiento.TipoMoneda : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("noDeu", Endeudamiento.NumeroOperadores != string.Empty ? Endeudamiento.NumeroOperadores : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("valorDeudas", Endeudamiento.ValorDeuda != string.Empty ? Endeudamiento.ValorDeuda : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("pade", Endeudamiento.ParticipacionTotalDeudas != string.Empty ? Endeudamiento.ParticipacionTotalDeudas : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("%gar", Endeudamiento.CubrimientoGarantia != ".0" || Endeudamiento.CubrimientoGarantia != string.Empty ? Endeudamiento.CubrimientoGarantia : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("tipoGar", Endeudamiento.TipoGarantia != string.Empty ? Endeudamiento.TipoGarantia : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("fechaAvaluo", Endeudamiento.FechaUltimoAvaluo != string.Empty ? Endeudamiento.FechaUltimoAvaluo : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("cuotaEsperada", Endeudamiento.CuotaEsperada != string.Empty ? Endeudamiento.CuotaEsperada : "-");
                CampoEndeudamiento = CampoEndeudamiento.Replace("%cumpl", Root.Response.Tercero.Endeudamiento.EndeudamientoTrimI.Endeudamiento72[2].CumplimientoCuota != string.Empty ||
                                                                                                        Root.Response.Tercero.Endeudamiento.EndeudamientoTrimI.Endeudamiento72[2].CumplimientoCuota != string.Empty ? Root.Response.Tercero.Endeudamiento.EndeudamientoTrimI.Endeudamiento72[2].CumplimientoCuota : "-");
                EndeudamientosTrimI += CampoEndeudamiento;
            }
            Values.Add("IDTIF", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.FechaTrimestreI);
            Values.Add("IDTIN", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.NumeroEntidadesTrimestreI);
            Values.Add("<td>ESPACIO PARA INFORMACION DETALLADA TRIMESTRE I</td>", EndeudamientosTrimI);
            #endregion
            #region Informacion Consolidada Trimestre II
            string BaseInformacionConsolidadaTrimestreII = await (new StreamReader(baseInformacionConsolidadaTrimestreII.FileStream)).ReadToEndAsync();
            var EndeudamientoConsolidadoII = Root.Response.Tercero.Endeudamiento.EndeudamientoTrimII;

            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("calificacion3", EndeudamientoConsolidadoII.Endeudamiento81[2].Calificacion);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nTipoMoneda", EndeudamientoConsolidadoII.Endeudamiento81[2].TipoModena);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nDeudasCial", EndeudamientoConsolidadoII.Endeudamiento81[2].NumeroOperacionesComercial);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nDeudasCons", EndeudamientoConsolidadoII.Endeudamiento81[2].NumeroOperacionesConsumo);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nDeudasVivi", EndeudamientoConsolidadoII.Endeudamiento81[2].NumeroOperacionesVivienda);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nDeudasMcr", EndeudamientoConsolidadoII.Endeudamiento81[2].NumeroOperacionesMicrocredito);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nValorCial", EndeudamientoConsolidadoII.Endeudamiento81[2].ValorDeudaComercial);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nValorsCons", EndeudamientoConsolidadoII.Endeudamiento81[2].ValorDeudaConsumo);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nValorVivi", EndeudamientoConsolidadoII.Endeudamiento81[2].ValorDeudaVivienda);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nValorMcr", EndeudamientoConsolidadoII.Endeudamiento81[2].ValorDeudaMicrocredito);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nTotal", EndeudamientoConsolidadoII.Endeudamiento81[2].Total);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nPade", EndeudamientoConsolidadoII.Endeudamiento81[2].ParticipacionTotalDeudas);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nCubrimientoCial", EndeudamientoConsolidadoII.Endeudamiento81[2].CubrimientoGarantiaComercial);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nCubrimientoCons", EndeudamientoConsolidadoII.Endeudamiento81[2].CubrimientoGarantiaConsumo);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nCubrimientoVivi", EndeudamientoConsolidadoII.Endeudamiento81[2].CubrimientoGarantiaVivienda);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("nCubrimientoMcr", "-");

            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("calificacion2", EndeudamientoConsolidadoII.Endeudamiento81[1].Calificacion);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tTipoMoneda", EndeudamientoConsolidadoII.Endeudamiento81[1].TipoModena);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tDeudasCial", EndeudamientoConsolidadoII.Endeudamiento81[1].NumeroOperacionesComercial);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tDeudasCons", EndeudamientoConsolidadoII.Endeudamiento81[1].NumeroOperacionesConsumo);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tDeudasVivi", EndeudamientoConsolidadoII.Endeudamiento81[1].NumeroOperacionesVivienda);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tDeudasMcr", EndeudamientoConsolidadoII.Endeudamiento81[1].NumeroOperacionesMicrocredito);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tValorCial", EndeudamientoConsolidadoII.Endeudamiento81[1].ValorDeudaComercial);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tValorsCons", EndeudamientoConsolidadoII.Endeudamiento81[1].ValorDeudaConsumo);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tValorVivi", EndeudamientoConsolidadoII.Endeudamiento81[1].ValorDeudaVivienda);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tValorMcr", EndeudamientoConsolidadoII.Endeudamiento81[1].ValorDeudaMicrocredito);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tTotal", EndeudamientoConsolidadoII.Endeudamiento81[1].Total);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tPade", EndeudamientoConsolidadoII.Endeudamiento81[1].ParticipacionTotalDeudas);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tCubrimientoCial", EndeudamientoConsolidadoII.Endeudamiento81[1].CubrimientoGarantiaComercial);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tCubrimientoCons", EndeudamientoConsolidadoII.Endeudamiento81[1].CubrimientoGarantiaConsumo);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tCubrimientoVivi", EndeudamientoConsolidadoII.Endeudamiento81[1].CubrimientoGarantiaVivienda);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("tCubrimientoMcr", "-");

            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("calificacion1", EndeudamientoConsolidadoII.Endeudamiento81[0].Calificacion);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aTipoMoneda", EndeudamientoConsolidadoII.Endeudamiento81[0].TipoModena);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aDeudasCial", EndeudamientoConsolidadoII.Endeudamiento81[0].NumeroOperacionesComercial);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aDeudasCons", EndeudamientoConsolidadoII.Endeudamiento81[0].NumeroOperacionesConsumo);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aDeudasVivi", EndeudamientoConsolidadoII.Endeudamiento81[0].NumeroOperacionesVivienda);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aDeudasMcr", EndeudamientoConsolidadoII.Endeudamiento81[0].NumeroOperacionesMicrocredito);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aValorCial", EndeudamientoConsolidadoII.Endeudamiento81[0].ValorDeudaComercial);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aValorsCons", EndeudamientoConsolidadoII.Endeudamiento81[0].ValorDeudaConsumo);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aValorVivi", EndeudamientoConsolidadoII.Endeudamiento81[0].ValorDeudaVivienda);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aValorMcr", EndeudamientoConsolidadoII.Endeudamiento81[0].ValorDeudaMicrocredito);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aTotal", EndeudamientoConsolidadoII.Endeudamiento81[0].Total);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aPade", EndeudamientoConsolidadoII.Endeudamiento81[0].ParticipacionTotalDeudas);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aCubrimientoCial", EndeudamientoConsolidadoII.Endeudamiento81[0].CubrimientoGarantiaComercial);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aCubrimientoCons", EndeudamientoConsolidadoII.Endeudamiento81[0].CubrimientoGarantiaConsumo);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aCubrimientoVivi", EndeudamientoConsolidadoII.Endeudamiento81[0].CubrimientoGarantiaVivienda);
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("aCubrimientoMcr", "-");

            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("mlNumero", EndeudamientoConsolidadoII.Endeudamiento82[2].NumeroContingencias != string.Empty ? EndeudamientoConsolidadoII.Endeudamiento82[2].NumeroContingencias : "-");
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("mlValor", decimal.Parse(EndeudamientoConsolidadoII.Endeudamiento82[2].ValorContingencias) > 0 ? EndeudamientoConsolidadoII.Endeudamiento82[2].ValorContingencias : "-");
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("mlCuota", decimal.Parse(EndeudamientoConsolidadoII.Endeudamiento82[2].CuotaEsperada) > 0 ? EndeudamientoConsolidadoII.Endeudamiento82[2].CuotaEsperada : "-");
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("mlCumplimiento", decimal.Parse(EndeudamientoConsolidadoII.Endeudamiento82[2].CumplimientoCuota) > 0 ? EndeudamientoConsolidadoII.Endeudamiento82[2].CumplimientoCuota : "-");

            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("meNumero", EndeudamientoConsolidadoII.Endeudamiento82[1].NumeroContingencias != string.Empty ? EndeudamientoConsolidadoII.Endeudamiento82[2].NumeroContingencias : "-");
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("meValor", decimal.Parse(EndeudamientoConsolidadoII.Endeudamiento82[1].ValorContingencias) > 0 ? EndeudamientoConsolidadoII.Endeudamiento82[2].ValorContingencias : "-");
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("meCuota", decimal.Parse(EndeudamientoConsolidadoII.Endeudamiento82[1].CuotaEsperada) > 0 ? EndeudamientoConsolidadoII.Endeudamiento82[2].CuotaEsperada : "-");
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("meCumplimiento", EndeudamientoConsolidadoII.Endeudamiento82[1].CumplimientoCuota != string.Empty ? EndeudamientoConsolidadoII.Endeudamiento82[2].CumplimientoCuota : "-");

            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("totNumero", EndeudamientoConsolidadoII.Endeudamiento82[0].NumeroContingencias != string.Empty ? EndeudamientoConsolidadoII.Endeudamiento82[2].NumeroContingencias : "-");
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("totValor", decimal.Parse(EndeudamientoConsolidadoII.Endeudamiento82[0].ValorContingencias) > 0 ? EndeudamientoConsolidadoII.Endeudamiento82[2].ValorContingencias : "-");
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("totCuota", decimal.Parse(EndeudamientoConsolidadoII.Endeudamiento82[0].CuotaEsperada) > 0 ? EndeudamientoConsolidadoII.Endeudamiento82[2].CuotaEsperada : "-");
            BaseInformacionConsolidadaTrimestreII = BaseInformacionConsolidadaTrimestreII.Replace("totCumplimiento", decimal.Parse(EndeudamientoConsolidadoII.Endeudamiento82[0].CumplimientoCuota) > 0 ? EndeudamientoConsolidadoII.Endeudamiento82[2].CumplimientoCuota : "-");


            Values.Add("ICTIIF", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.FechaTrimestreII);
            Values.Add("ICTIIN", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.NumeroEntidadesTrimestreII);
            Values.Add("<td>ESPACIO PARA INFORMACION CONSOLIDADA TRIMESTRE II</td>", BaseInformacionConsolidadaTrimestreII);
            #endregion
            #region Informacion Detallada Trimestre II
            string BaseInformacionDetalladaTrimestreII = await (new StreamReader(baseInformacionDetalladaTrimestreII.FileStream)).ReadToEndAsync();
            var EndeudamientoDetalladoII = Root.Response.Tercero.Endeudamiento.EndeudamientoTrimII.Endeudamiento83;
            string InformacionDetalladaTrimestreII = string.Empty;
            foreach (var Endeudamiento in EndeudamientoDetalladoII)
            {
                var InformeEndeudamientoII = BaseInformacionDetalladaTrimestreII;
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("tipoEnt", Endeudamiento.TipoEntidad != string.Empty ? Endeudamiento.TipoEntidad : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("nombreEnt", Endeudamiento.NombreEntidad != string.Empty ? Endeudamiento.NombreEntidad : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("tipoEnt", Endeudamiento.TipoEntidadOriginadoraCartera != string.Empty ? Endeudamiento.TipoEntidadOriginadoraCartera : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("nombreEntCartera", Endeudamiento.EntidadOriginadoraCartera != string.Empty ? Endeudamiento.EntidadOriginadoraCartera : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("tipoFid", Endeudamiento.TipoFideicomiso != string.Empty ? Endeudamiento.TipoFideicomiso : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("noFideico", Endeudamiento.NumeroFideicomiso != string.Empty ? Endeudamiento.NumeroFideicomiso : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("modaCred", Endeudamiento.ModalidadCredito != string.Empty ? Endeudamiento.ModalidadCredito : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("calf", Endeudamiento.Calificacion != string.Empty ? Endeudamiento.Calificacion : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("tipoMon", Endeudamiento.TipoMoneda != string.Empty ? Endeudamiento.TipoMoneda : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("noDeu", Endeudamiento.NumeroOperadores != string.Empty ? Endeudamiento.NumeroOperadores : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("valorDeudas", Endeudamiento.ValorDeuda != string.Empty ? Endeudamiento.ValorDeuda : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("pade", Endeudamiento.ParticipacionTotalDeudas != string.Empty ? Endeudamiento.ParticipacionTotalDeudas : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("%gar", Endeudamiento.CubrimientoGarantia != ".0" || Endeudamiento.CubrimientoGarantia != string.Empty ? Endeudamiento.CubrimientoGarantia : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("tipoGar", Endeudamiento.TipoGarantia != string.Empty ? Endeudamiento.TipoGarantia : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("fechaAvaluo", Endeudamiento.FechaUltimoAvaluo != string.Empty ? Endeudamiento.FechaUltimoAvaluo : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("cuotaEsperada", Endeudamiento.CuotaEsperada != string.Empty ? Endeudamiento.CuotaEsperada : "-");
                InformeEndeudamientoII = InformeEndeudamientoII.Replace("%cumpl", Root.Response.Tercero.Endeudamiento.EndeudamientoTrimII.Endeudamiento82[2].CumplimientoCuota != string.Empty ||
                                                                                                        Root.Response.Tercero.Endeudamiento.EndeudamientoTrimII.Endeudamiento82[2].CumplimientoCuota != string.Empty ? Root.Response.Tercero.Endeudamiento.EndeudamientoTrimII.Endeudamiento82[2].CumplimientoCuota : "-");
                InformacionDetalladaTrimestreII += InformeEndeudamientoII;
            }

            Values.Add("IDTIIF", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.FechaTrimestreII);
            Values.Add("IDTIIN", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.NumeroEntidadesTrimestreII);
            Values.Add("<td>ESPACIO PARA INFORMACION DETALLADA TRIMESTRE II</td>", InformacionDetalladaTrimestreII);
            #endregion
            #region Informacion Consolidada Trimestre III
            string BaseInformacionConsolidadaTrimestreIII = await (new StreamReader(baseInformacionConsolidadaTrimestreIII.FileStream)).ReadToEndAsync();
            var EndeudamientoConsolidadoIII = Root.Response.Tercero.Endeudamiento.EndeudamientoTrimIII;

            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("calificacion3", EndeudamientoConsolidadoIII.Endeudamiento91[2].Calificacion);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nTipoMoneda", EndeudamientoConsolidadoIII.Endeudamiento91[2].TipoModena);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nDeudasCial", EndeudamientoConsolidadoIII.Endeudamiento91[2].NumeroOperacionesComercial);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nDeudasCons", EndeudamientoConsolidadoIII.Endeudamiento91[2].NumeroOperacionesConsumo);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nDeudasVivi", EndeudamientoConsolidadoIII.Endeudamiento91[2].NumeroOperacionesVivienda);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nDeudasMcr", EndeudamientoConsolidadoIII.Endeudamiento91[2].NumeroOperacionesMicrocredito);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nValorCial", EndeudamientoConsolidadoIII.Endeudamiento91[2].ValorDeudaComercial);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nValorsCons", EndeudamientoConsolidadoIII.Endeudamiento91[2].ValorDeudaConsumo);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nValorVivi", EndeudamientoConsolidadoIII.Endeudamiento91[2].ValorDeudaVivienda);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nValorMcr", EndeudamientoConsolidadoIII.Endeudamiento91[2].ValorDeudaMicrocredito);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nTotal", EndeudamientoConsolidadoIII.Endeudamiento91[2].Total);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nPade", EndeudamientoConsolidadoIII.Endeudamiento91[2].ParticipacionTotalDeudas);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nCubrimientoCial", EndeudamientoConsolidadoIII.Endeudamiento91[2].CubrimientoGarantiaComercial);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nCubrimientoCons", EndeudamientoConsolidadoIII.Endeudamiento91[2].CubrimientoGarantiaConsumo);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nCubrimientoVivi", EndeudamientoConsolidadoIII.Endeudamiento91[2].CubrimientoGarantiaVivienda);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("nCubrimientoMcr", "-");

            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("calificacion2", EndeudamientoConsolidadoIII.Endeudamiento91[1].Calificacion);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tTipoMoneda", EndeudamientoConsolidadoIII.Endeudamiento91[1].TipoModena);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tDeudasCial", EndeudamientoConsolidadoIII.Endeudamiento91[1].NumeroOperacionesComercial);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tDeudasCons", EndeudamientoConsolidadoIII.Endeudamiento91[1].NumeroOperacionesConsumo);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tDeudasVivi", EndeudamientoConsolidadoIII.Endeudamiento91[1].NumeroOperacionesVivienda);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tDeudasMcr", EndeudamientoConsolidadoIII.Endeudamiento91[1].NumeroOperacionesMicrocredito);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tValorCial", EndeudamientoConsolidadoIII.Endeudamiento91[1].ValorDeudaComercial);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tValorsCons", EndeudamientoConsolidadoIII.Endeudamiento91[1].ValorDeudaConsumo);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tValorVivi", EndeudamientoConsolidadoIII.Endeudamiento91[1].ValorDeudaVivienda);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tValorMcr", EndeudamientoConsolidadoIII.Endeudamiento91[1].ValorDeudaMicrocredito);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tTotal", EndeudamientoConsolidadoIII.Endeudamiento91[1].Total);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tPade", EndeudamientoConsolidadoIII.Endeudamiento91[1].ParticipacionTotalDeudas);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tCubrimientoCial", EndeudamientoConsolidadoIII.Endeudamiento91[1].CubrimientoGarantiaComercial);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tCubrimientoCons", EndeudamientoConsolidadoIII.Endeudamiento91[1].CubrimientoGarantiaConsumo);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tCubrimientoVivi", EndeudamientoConsolidadoIII.Endeudamiento91[1].CubrimientoGarantiaVivienda);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("tCubrimientoMcr", "-");

            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("calificacion1", EndeudamientoConsolidadoIII.Endeudamiento91[0].Calificacion);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aTipoMoneda", EndeudamientoConsolidadoIII.Endeudamiento91[0].TipoModena);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aDeudasCial", EndeudamientoConsolidadoIII.Endeudamiento91[0].NumeroOperacionesComercial);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aDeudasCons", EndeudamientoConsolidadoIII.Endeudamiento91[0].NumeroOperacionesConsumo);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aDeudasVivi", EndeudamientoConsolidadoIII.Endeudamiento91[0].NumeroOperacionesVivienda);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aDeudasMcr", EndeudamientoConsolidadoIII.Endeudamiento91[0].NumeroOperacionesMicrocredito);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aValorCial", EndeudamientoConsolidadoIII.Endeudamiento91[0].ValorDeudaComercial);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aValorsCons", EndeudamientoConsolidadoIII.Endeudamiento91[0].ValorDeudaConsumo);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aValorVivi", EndeudamientoConsolidadoIII.Endeudamiento91[0].ValorDeudaVivienda);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aValorMcr", EndeudamientoConsolidadoIII.Endeudamiento91[0].ValorDeudaMicrocredito);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aTotal", EndeudamientoConsolidadoIII.Endeudamiento91[0].Total);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aPade", EndeudamientoConsolidadoIII.Endeudamiento91[0].ParticipacionTotalDeudas);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aCubrimientoCial", EndeudamientoConsolidadoIII.Endeudamiento91[0].CubrimientoGarantiaComercial);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aCubrimientoCons", EndeudamientoConsolidadoIII.Endeudamiento91[0].CubrimientoGarantiaConsumo);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aCubrimientoVivi", EndeudamientoConsolidadoIII.Endeudamiento91[0].CubrimientoGarantiaVivienda);
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("aCubrimientoMcr", "-");

            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("mlNumero", EndeudamientoConsolidadoIII.Endeudamiento92[2].NumeroContingencias != string.Empty ? EndeudamientoConsolidadoIII.Endeudamiento92[2].NumeroContingencias : "-");
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("mlValor", decimal.Parse(EndeudamientoConsolidadoIII.Endeudamiento92[2].ValorContingencias) > 0 ? EndeudamientoConsolidadoIII.Endeudamiento92[2].ValorContingencias : "-");
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("mlCuota", decimal.Parse(EndeudamientoConsolidadoIII.Endeudamiento92[2].CuotaEsperada) > 0 ? EndeudamientoConsolidadoIII.Endeudamiento92[2].CuotaEsperada : "-");
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("mlCumplimiento", decimal.Parse(EndeudamientoConsolidadoIII.Endeudamiento92[2].CumplimientoCuota) > 0 ? EndeudamientoConsolidadoIII.Endeudamiento92[2].CumplimientoCuota : "-");

            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("meNumero", EndeudamientoConsolidadoIII.Endeudamiento92[1].NumeroContingencias != string.Empty ? EndeudamientoConsolidadoIII.Endeudamiento92[2].NumeroContingencias : "-");
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("meValor", decimal.Parse(EndeudamientoConsolidadoIII.Endeudamiento92[1].ValorContingencias) > 0 ? EndeudamientoConsolidadoIII.Endeudamiento92[2].ValorContingencias : "-");
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("meCuota", decimal.Parse(EndeudamientoConsolidadoIII.Endeudamiento92[1].CuotaEsperada) > 0 ? EndeudamientoConsolidadoIII.Endeudamiento92[2].CuotaEsperada : "-");
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("meCumplimiento", EndeudamientoConsolidadoIII.Endeudamiento92[1].CumplimientoCuota != string.Empty ? EndeudamientoConsolidadoIII.Endeudamiento92[2].CumplimientoCuota : "-");

            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("totNumero", EndeudamientoConsolidadoIII.Endeudamiento92[0].NumeroContingencias != string.Empty ? EndeudamientoConsolidadoIII.Endeudamiento92[2].NumeroContingencias : "-");
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("totValor", decimal.Parse(EndeudamientoConsolidadoIII.Endeudamiento92[0].ValorContingencias) > 0 ? EndeudamientoConsolidadoIII.Endeudamiento92[2].ValorContingencias : "-");
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("totCuota", decimal.Parse(EndeudamientoConsolidadoIII.Endeudamiento92[0].CuotaEsperada) > 0 ? EndeudamientoConsolidadoIII.Endeudamiento92[2].CuotaEsperada : "-");
            BaseInformacionConsolidadaTrimestreIII = BaseInformacionConsolidadaTrimestreIII.Replace("totCumplimiento", decimal.Parse(EndeudamientoConsolidadoIII.Endeudamiento92[0].CumplimientoCuota) > 0 ? EndeudamientoConsolidadoIII.Endeudamiento92[2].CumplimientoCuota : "-");


            Values.Add("ICTIIIF", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.FechaTrimestreIII);
            Values.Add("ICTIIIN", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.NumeroEntidadesTrimestreIII);
            Values.Add("<td>ESPACIO PARA INFORMACION CONSOLIDADA TRIMESTRE III</td>", BaseInformacionConsolidadaTrimestreIII);
            #endregion
            #region Informacion Detallada Trimestre III
            string BaseInformacionDetalladaTrimestreIII = await (new StreamReader(baseInformacionDetalladaTrimestreIII.FileStream)).ReadToEndAsync();
            var EndeudamientoDetalladoIII = Root.Response.Tercero.Endeudamiento.EndeudamientoTrimIII.Endeudamiento93;
            string InformacionDetalladaTrimestreIII = string.Empty;
            foreach (var Endeudamiento in EndeudamientoDetalladoIII)
            {
                var EndeudamientosTrimestreIII = BaseInformacionDetalladaTrimestreIII;
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("tipoEnt", Endeudamiento.TipoEntidad != string.Empty ? Endeudamiento.TipoEntidad : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("nombreEnt", Endeudamiento.NombreEntidad != string.Empty ? Endeudamiento.NombreEntidad : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("tipoEnt", Endeudamiento.TipoEntidadOriginadoraCartera != string.Empty ? Endeudamiento.TipoEntidadOriginadoraCartera : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("nombreEntCartera", Endeudamiento.EntidadOriginadoraCartera != string.Empty ? Endeudamiento.EntidadOriginadoraCartera : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("tipoFid", Endeudamiento.TipoFideicomiso != string.Empty ? Endeudamiento.TipoFideicomiso : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("noFideico", Endeudamiento.NumeroFideicomiso != string.Empty ? Endeudamiento.NumeroFideicomiso : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("modaCred", Endeudamiento.ModalidadCredito != string.Empty ? Endeudamiento.ModalidadCredito : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("calf", Endeudamiento.Calificacion != string.Empty ? Endeudamiento.Calificacion : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("tipoMon", Endeudamiento.TipoMoneda != string.Empty ? Endeudamiento.TipoMoneda : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("noDeu", Endeudamiento.NumeroOperadores != string.Empty ? Endeudamiento.NumeroOperadores : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("valorDeudas", Endeudamiento.ValorDeuda != string.Empty ? Endeudamiento.ValorDeuda : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("pade", Endeudamiento.ParticipacionTotalDeudas != string.Empty ? Endeudamiento.ParticipacionTotalDeudas : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("%gar", Endeudamiento.CubrimientoGarantia != ".0" || Endeudamiento.CubrimientoGarantia != string.Empty ? Endeudamiento.CubrimientoGarantia : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("tipoGar", Endeudamiento.TipoGarantia != string.Empty ? Endeudamiento.TipoGarantia : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("fechaAvaluo", Endeudamiento.FechaUltimoAvaluo != string.Empty ? Endeudamiento.FechaUltimoAvaluo : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("cuotaEsperada", Endeudamiento.CuotaEsperada != string.Empty ? Endeudamiento.CuotaEsperada : "-");
                EndeudamientosTrimestreIII = EndeudamientosTrimestreIII.Replace("%cumpl", Endeudamiento.CumplimientoCuota != string.Empty ? Endeudamiento.CumplimientoCuota : "-");

                InformacionDetalladaTrimestreIII += EndeudamientosTrimestreIII;
            }
            Values.Add("IDTIIIF", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.FechaTrimestreIII);
            Values.Add("IDTIIIN", Root.Response.Tercero.Endeudamiento.EncabezadoEndeudamiento.NumeroEntidadesTrimestreIII);
            Values.Add("<td>ESPACIO PARA INFORMACION DETALLADA TRIMESTRE III</td>", InformacionDetalladaTrimestreIII);
            #endregion


            return await CrearDocumento(Basedocument, Styles, TipoDocumentoArchivo.PDF, Guid.NewGuid().ToString(), Values);
        }
    }
}
