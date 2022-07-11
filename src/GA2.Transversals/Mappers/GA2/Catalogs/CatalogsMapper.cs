using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;

namespace GA2.Transversals.Mappers
{
    public class CatalogsMapper : Profile
    {
        public CatalogsMapper()
        {
            CreateMap<Catalogo, CatalogoDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.CTL_ID))
                    .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.CTL_NOMBRE))
                    .ForMember(x => x.Expresion, map => map.MapFrom(dto => dto.CTL_EXPRESION))
                    .ForMember(x => x.EsEditable, map => map.MapFrom(dto => dto.CTL_EDITABLE))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.CTL_DESCRIPCION))
                    .ReverseMap();

            CreateMap<PersonasCargo, PersonasCargoDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ID_PEC))
                    .ForMember(x => x.IdPersonasCargo, map => map.MapFrom(dto => dto.PEC_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.PEC_DESCRIPCION))
                    .ReverseMap();

            CreateMap<NivelAcademico, NivelAcademicoDto>()
                    .ForMember(x => x.IdNivelAcademico, map => map.MapFrom(dto => dto.ID_NIVEL_ACADEMICO))
                    .ForMember(x => x.NivelAcademicoId, map => map.MapFrom(dto => dto.NIVEL_ACADEMICO_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.DESCRIPCION_NIVEL))
                    .ReverseMap();

            CreateMap<TipoViviendaPropia, TipoViviendaPropiaDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.VIP_ID))
                    .ForMember(x => x.IdViviendaPropia, map => map.MapFrom(dto => dto.VIP_ID_VIVIENDA))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.VIP_DESCRIPCION))
                    .ReverseMap();

            CreateMap<Estrato, EstratoDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ETR_ID))
                    .ForMember(x => x.IdEstrato, map => map.MapFrom(dto => dto.ETR_ESTRATO_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.ETR_DESCRIPCION))
                    .ReverseMap();

            CreateMap<TipoContrato, TipoContratoDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.TIC_ID))
                    .ForMember(x => x.IdTipoContrato, map => map.MapFrom(dto => dto.TIC_CONTRATO_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.TIC_DESCRIPCION))
                    .ReverseMap();

            // Model CatalogValue Dto CatalogoValor
            CreateMap<CatalogoValor, CatalogoValorDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.CAT_ID))
                    .ForMember(x => x.IdValor, map => map.MapFrom(dto => dto.CVL_ID))
                    .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.CVL_CODIGO))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.CVL_DESCRIPCION))
                    .ForMember(x => x.EsActivo, map => map.MapFrom(dto => dto.CVL_ACTIVO))
                    .ReverseMap();

            // Model CatalogValue Dto CatalogoValor
            CreateMap<CatalogoValor, SexoDto>()
                    .ForMember(x => x.IdCatalogo, map => map.MapFrom(dto => dto.CVL_ID))
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.CAT_ID))
                    .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.CVL_CODIGO))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.CVL_DESCRIPCION))
                    .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.CVL_ACTIVO))
                    .ReverseMap();

            // Model Category Dto Categoria
            CreateMap<Domain.Entities.Categoria, CategoriaDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.CTG_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.CTG_DESCRIPCION))
                    .ReverseMap();

            // Model City Dto Ciudad
            CreateMap<Ciudad, CiudadDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.DPC_ID))
                    .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.DPC_CODIGO))
                    .ForMember(x => x.IdDepartamento, map => map.MapFrom(dto => dto.DPD_ID))
                    .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.DPC_NOMBRE))
                    .ReverseMap();
            // Model Ciudad City Dto 
            CreateMap<CiudadDto, Ciudad>()
                    .ForMember(x => x.DPC_ID, map => map.MapFrom(dto => dto.Id))
                    .ForMember(x => x.DPC_CODIGO, map => map.MapFrom(dto => dto.Codigo))
                    .ForMember(x => x.DPD_ID, map => map.MapFrom(dto => dto.IdDepartamento))
                    .ForMember(x => x.DPC_NOMBRE, map => map.MapFrom(dto => dto.Nombre))
                    .ReverseMap();

            // Model Documento Tipo 
            CreateMap<DocumentoTipoDto, DocumentoTipo>()
                    .ForMember(x => x.TDC_ID, map => map.MapFrom(dto => dto.IdDocumento))
                    .ForMember(x => x.TDC_ABRV, map => map.MapFrom(dto => dto.AbreviaturaDocumento))
                    .ForMember(x => x.TDC_DECRIPCION, map => map.MapFrom(dto => dto.DescripcionDocumento))
                    .ForMember(x => x.TDC_ESTADO, map => map.MapFrom(dto => dto.EstadoDocumento))
                    .ReverseMap();


            // Model Country Dto Pais
            CreateMap<Domain.Entities.Pais, PaisDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.DPP_ID))
                    .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.DPP_CODIGO))
                    .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.DPP_NOMBRE))
                    .ForMember(x => x.IndicativoTelefono, map => map.MapFrom(dto => dto.DPP_INDICATIVOTEL))
                    .ReverseMap();

            // Model Department Dto Departamento
            CreateMap<Domain.Entities.Departamento, DepartamentoDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.DPD_ID))
                    .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.DPD_CODIGO))
                    .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.DPD_NOMBRE))
                    .ForMember(x => x.IndicativoTelefono, map => map.MapFrom(dto => dto.DPD_INDICATIVOTEL))
                    .ReverseMap();

            // Model ExecutingUnit Dto UnidadEjecutora
            CreateMap<UnidadEjecutora, UnidadEjecutoraDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.UEJ_ID))
                    .ForMember(x => x.TipoIdentificacion, map => map.MapFrom(dto => dto.TID_ID))
                    .ForMember(x => x.Identificacion, map => map.MapFrom(dto => dto.UEJ_IDENTIFICACION))
                    .ForMember(x => x.Nombre, map => map.MapFrom(dto => dto.UEJ_NOMBRE))
                    .ForMember(x => x.Sigla, map => map.MapFrom(dto => dto.UEJ_SIGLA))
                    .ForMember(x => x.Fecha, map => map.MapFrom(dto => dto.UEJ_FECHA))
                    .ForMember(x => x.Fuerza, map => map.MapFrom(dto => dto.FRZ_ID))
                    .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.UEJ_CODIGO))
                    .ForMember(x => x.TasaAporte, map => map.MapFrom(dto => dto.UEJ_TASA_APORTE))
                    .ForMember(x => x.AreaNegocio, map => map.MapFrom(dto => dto.UEJ_AREA_NEGOCIO))
                    .ForMember(x => x.EsAval, map => map.MapFrom(dto => dto.UEJ_AVAL))
                    .ReverseMap();

            // Model Force Dto Fuerza
            CreateMap<Domain.Entities.Fuerzas, FuerzasDto>()
                        .ForMember(x => x.Id, map => map.MapFrom(dto => dto.FRZ_ID))
                        .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.FRZ_CODIGO))
                        .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.FRZ_DESCRIPCION))
                        .ForMember(x => x.Digito, map => map.MapFrom(dto => dto.FRZ_DIGITO))
                        .ForMember(x => x.EsSoldado, map => map.MapFrom(dto => dto.FRZ_SOLDADO))
                        .ReverseMap();

            // Model Grade Dto Grado
            CreateMap<Domain.Entities.Grado, GradoDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.GRD_ID))
                    .ForMember(x => x.Categoria, map => map.MapFrom(dto => dto.CTG_ID))
                    .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.GRD_CODIGO))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.GRD_DESCRIPCION))
                    .ForMember(x => x.EsActivo, map => map.MapFrom(dto => dto.GRD_ACTIVO))
                    .ForMember(x => x.EsCivil, map => map.MapFrom(dto => dto.GRD_CIVIL))
                    .ForMember(x => x.EsEspecial, map => map.MapFrom(dto => dto.GRD_ESPECIAL))
                    .ForMember(x => x.Fuerza, map => map.MapFrom(dto => dto.FRZ_ID))
                    .ForMember(x => x.Sigla, map => map.MapFrom(dto => dto.GRD_SIGLA)).ReverseMap();

            // Model IdentificationType Dto TipoIdentificacion
            CreateMap<TipoIdentificacion, TipoIdentificacionDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.TID_ID))
                    .ForMember(x => x.Codigo, map => map.MapFrom(dto => dto.TID_CODIGO))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.TID_DESCRIPCION))
                    .ForMember(x => x.Embargo, map => map.MapFrom(dto => dto.TID_EMBARGO))
                    .ForMember(x => x.ERP, map => map.MapFrom(dto => dto.TID_ERP))
                    .ForMember(x => x.EsActivo, map => map.MapFrom(dto => dto.TID_ACTIVO))
                    .ForMember(x => x.EsEmpresarial, map => map.MapFrom(dto => dto.TID_EMPRESARIAL))
                    .ForMember(x => x.Vigia, map => map.MapFrom(dto => dto.TID_VIGIA))
                    .ReverseMap();

            CreateMap<TipoIdentificacionDto, TipoIdentificacion>()
                    .ForMember(x => x.TID_ID, map => map.MapFrom(dto => dto.Id))
                    .ForMember(x => x.TID_CODIGO, map => map.MapFrom(dto => dto.Codigo))
                    .ForMember(x => x.TID_DESCRIPCION, map => map.MapFrom(dto => dto.Descripcion))
                    .ForMember(x => x.TID_EMBARGO, map => map.MapFrom(dto => dto.Embargo))
                    .ForMember(x => x.TID_ERP, map => map.MapFrom(dto => dto.ERP))
                    .ForMember(x => x.TID_ACTIVO, map => map.MapFrom(dto => dto.EsActivo))
                    .ForMember(x => x.TID_EMPRESARIAL, map => map.MapFrom(dto => dto.EsEmpresarial))
                    .ForMember(x => x.TID_VIGIA, map => map.MapFrom(dto => dto.Vigia))
                    .ReverseMap();

            // Model LivingPlace Dto TipoVivienda
            CreateMap<TipoVivienda, TipoViviendaDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.TVV_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.TVV_DESCRIPCION))
                    .ForMember(x => x.EsActiva, map => map.MapFrom(dto => dto.TVV_ACTIVA))
                    .ForMember(x => x.EsPromocionada, map => map.MapFrom(dto => dto.TVV_PROMOCIONADA))
                    .ReverseMap();

            //Estado Civil
            CreateMap<CatalogoValor, EstadoCivilDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.CVL_CODIGO))
                .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.CVL_DESCRIPCION))
                .ReverseMap();

            CreateMap<ActividadEconomicaDto, ActividadEconomica>()
             .ForMember(x => x.ACC_ID, map => map.MapFrom(dto => dto.Id))
             .ForMember(x => x.ACC_DESCRIPCION, map => map.MapFrom(dto => dto.Descripcion))
             .ForMember(x => x.ACC_CODIGO_CIUU, map => map.MapFrom(dto => dto.CodigoCiiu))
             .ForMember(x => x.ACC_ESTADO, map => map.MapFrom(dto => dto.Estado))
             .ForMember(x => x.ACC_CREADO_POR, map => map.MapFrom(dto => dto.CreadoPor))
             .ForMember(x => x.ACC_FECHA_CREACION, map => map.MapFrom(dto => dto.FechaCreacion))
             .ForMember(x => x.ACC_ACTUALIZADO_POR, map => map.MapFrom(dto => dto.ActualizadoPor))
             .ForMember(x => x.ACC_FECHA_ACTUALIZA, map => map.MapFrom(dto => dto.FechaActualizado))
             .ReverseMap();

            CreateMap<ActividadEconomica, ActividadEconomicaDto>()
             .ForMember(x => x.Id, map => map.MapFrom(dto => dto.ACC_ID))
             .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.ACC_DESCRIPCION))
             .ForMember(x => x.CodigoCiiu, map => map.MapFrom(dto => dto.ACC_CODIGO_CIUU))
             .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ACC_ESTADO))
             .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.ACC_CREADO_POR))
             .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.ACC_FECHA_CREACION))
             .ForMember(x => x.ActualizadoPor, map => map.MapFrom(dto => dto.ACC_ACTUALIZADO_POR))
             .ForMember(x => x.FechaActualizado, map => map.MapFrom(dto => dto.ACC_FECHA_ACTUALIZA))
             .ReverseMap();

            CreateMap<Profesion, ProfesionDto>()
           .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PRF_ID))
           .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.PRF_DESCRIPCION))
           .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PRF_ESTADO))
           .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.PRF_CREADO_POR))
           .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.PRF_FECHA_CREACION))
           .ForMember(x => x.ActualizadoPor, map => map.MapFrom(dto => dto.PRF_ACTUALIZADO_POR))
           .ForMember(x => x.FechaActualizacion, map => map.MapFrom(dto => dto.PRF_FECHA_ACTUALIZA))
           .ReverseMap();

            CreateMap<ProfesionDto, Profesion>()
            .ForMember(x => x.PRF_ID, map => map.MapFrom(dto => dto.Id))
            .ForMember(x => x.PRF_DESCRIPCION, map => map.MapFrom(dto => dto.Descripcion))
            .ForMember(x => x.PRF_ESTADO, map => map.MapFrom(dto => dto.Estado))
            .ForMember(x => x.PRF_CREADO_POR, map => map.MapFrom(dto => dto.CreadoPor))
            .ForMember(x => x.PRF_FECHA_CREACION, map => map.MapFrom(dto => dto.FechaCreacion))
            .ForMember(x => x.PRF_ACTUALIZADO_POR, map => map.MapFrom(dto => dto.ActualizadoPor))
            .ForMember(x => x.PRF_FECHA_ACTUALIZA, map => map.MapFrom(dto => dto.FechaActualizacion))
            .ReverseMap();

            CreateMap<TipoCreditoDto, TipoCredito>()
            .ForMember(x => x.TCR_ID, map => map.MapFrom(dto => dto.TCR_ID))
            .ForMember(x => x.TCR_DESCRIPCION, map => map.MapFrom(dto => dto.TCR_DESCRIPCION))
            .ForMember(x => x.TCR_ID_PADRE, map => map.MapFrom(dto => dto.TCR_ID_PADRE))
            .ForMember(x => x.TCR_NIVEL, map => map.MapFrom(dto => dto.TCR_NIVEL))
            .ForMember(x => x.TCR_CREADO_POR, map => map.MapFrom(dto => dto.TCR_CREADO_POR))
            .ForMember(x => x.TCR_FECHA_CREACION, map => map.MapFrom(dto => dto.TCR_FECHA_CREACION))
            .ForMember(x => x.TCR_MODIFICADO_POR, map => map.MapFrom(dto => dto.TCR_MODIFICADO_POR))
            .ForMember(x => x.TCR_FECHA_MODIFICACION, map => map.MapFrom(dto => dto.TCR_FECHA_MODIFICACION))
            .ReverseMap();

            CreateMap<TiViviendaDto, TiVivienda>()
            .ForMember(x => x.TIV_VIVIENDA_ID, map => map.MapFrom(dto => dto.TIV_VIVIENDA_ID))
            .ForMember(x => x.TIV_VIVIENDA_DESCRIPCION, map => map.MapFrom(dto => dto.TIV_VIVIENDA_DESCRIPCION))
            .ReverseMap();

            CreateMap<EstadoViviendaDto, EstadoVivienda>()
            .ForMember(x => x.ESV_ID, map => map.MapFrom(dto => dto.ESV_ID))
            .ForMember(x => x.ESV_DESCRIPCION, map => map.MapFrom(dto => dto.ESV_DESCRIPCION))
            .ReverseMap();

            CreateMap<EstadoActividad, EstadoActividadDto>()
                .ForMember(source => source.Id, map => map.MapFrom(destino => destino.ESA_ID))
                .ForMember(source => source.Descripcion, map => map.MapFrom(destino => destino.ESA_DESCRIPCION))
                .ForMember(source => source.Estado, map => map.MapFrom(destino => destino.ESA_ESTADO))
                .ForMember(source => source.CreadoPor, map => map.MapFrom(destino => destino.ESA_CREADO_POR))
                .ForMember(source => source.FechaCreacion, map => map.MapFrom(destino => destino.ESA_FECHA_CREACION))
                .ForMember(source => source.ModificadoPor, map => map.MapFrom(destino => destino.ESA_MODIFICADO_POR))
                .ForMember(source => source.FechaModificacion, map => map.MapFrom(destino => destino.ESA_FECHA_MODIFICACION))
                .ReverseMap();

            CreateMap<Abecedario, AbecedarioDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.LTR_ID))
                .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.LTR_LETRA))
                .ForMember(x => x.Activa, map => map.MapFrom(dto => dto.LTR_ACTIVIDAD))
                .ReverseMap();

            CreateMap<Bis, BisDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.BS_ID))
                .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.BS_BIS))
                .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.BS_ACTIVO))
                .ReverseMap();

            CreateMap<Cardinalidad, CardinalidadDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.CRD_ID))
                .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.CRD_DESCRIPCION))
                .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.CRD_ACTIVO))
                .ReverseMap();

            CreateMap<TipoCalle, TipoCalleDto>()
                .ForMember(x => x.Id, map => map.MapFrom(dto => dto.TPC_ID))
                .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.TPC_DESCRIPCION))
                .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.TPC_ACTIVO))
                .ReverseMap();

            CreateMap<TipoTelefono, TipoTelefonoDto>()
                .ForMember(x => x.IdTipoTelefono, map => map.MapFrom(dto => dto.TPT_ID))
                .ForMember(x => x.DescripcionTipoTelefono, map => map.MapFrom(dto => dto.TPT_DESCRIPCION))
                .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.TPT_ACTIVO))
                .ReverseMap();

            CreateMap<TipoCorreo, TipoCorreoDto>()
                .ForMember(x => x.IdTipoCorreo, map => map.MapFrom(dto => dto.TCE_ID))
                .ForMember(x => x.DescripcionTipoCorreo, map => map.MapFrom(dto => dto.TCE_DESCRIPCION))
                .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.TCE_ACTIVO))
                .ReverseMap();

            CreateMap<TipoMoneda, TipoMonedaDto>()
                .ForMember(x => x.IdMoneda, map => map.MapFrom(dto => dto.MND_ID))
                .ForMember(x => x.DescripcionMoneda, map => map.MapFrom(dto => dto.MND_DESCRIPCION))
                .ForMember(x => x.CodigoMoneda, map => map.MapFrom(dto => dto.MND_CODIGO))
                .ReverseMap();

            // Model ConceptoNominaDto ConceptoNomina
            CreateMap<ConceptoNomina, ConceptoNominaDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.CNN_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.CNN_DESCRIPCION))
                    .ForMember(x => x.Sigla, map => map.MapFrom(dto => dto.CNN_SIGLA))
                    .ForMember(x => x.Salario, map => map.MapFrom(dto => dto.CNN_SALARIO))
                    .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.CNN_ESTADO))
                    .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.CNN_CREADO_POR))
                    .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.CNN_FECHA_CREACION))
                    .ForMember(x => x.ModificadoPor, map => map.MapFrom(dto => dto.CNN_MODIFICADO_POR))
                    .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.CNN_FECHA_MODIFICACION))
                    .ForMember(x => x.IdCategoria, map => map.MapFrom(dto => dto.CTG_ID)).ReverseMap();

            CreateMap<DominiosCorreo, DominiosCorreoDto>()
                    .ForMember(x => x.Dominio, map => map.MapFrom(dto => dto.DMN_DOMINIO))
                    .ForMember(x => x.TipoCorreo, map => map.MapFrom(dto => dto.TPC_TIPO_CORREO))
                    .ReverseMap();

            CreateMap<TipoDireccion, TipoDireccionDto>()
                    .ForMember(x => x.TipoDireccionId, map => map.MapFrom(dto => dto.TPD_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.TPD_DESCRIPCION))
                    .ReverseMap();

            CreateMap<TipoAbono, TipoAbonoDto>()
                    .ForMember(x => x.IdTipoAbono, map => map.MapFrom(dto => dto.TPA_ID))
                    .ForMember(x => x.DescripcionTipoAbono, map => map.MapFrom(dto => dto.TPA_DESCRIPCION))
                    .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.TPA_ACTIVO))
                    .ReverseMap();

            CreateMap<TipoSubsidio, TipoSubsidioDto>()
                    .ForMember(x => x.IdTipoSubsudio, map => map.MapFrom(dto => dto.TPS_ACTIVO))
                    .ForMember(x => x.DescripcionTipoSubsidio, map => map.MapFrom(dto => dto.TPS_DESCRIPCION))
                    .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.TPS_ACTIVO))
                    .ReverseMap();

            CreateMap<AbonoUnico, AbonoUnicoDto>()
                    .ForMember(x => x.IdAbonoUnico, map => map.MapFrom(dto => dto.ABU_ID))
                    .ForMember(x => x.DescripcionAbono, map => map.MapFrom(dto => dto.ABU_DESCRIPCION))
                    .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.ABU_ACTIVO))
                    .ReverseMap();

            CreateMap<TipoSolicitud, TipoSolicitudDto>()
                    .ForMember(x => x.IdTipoSolicitud, map => map.MapFrom(dto => dto.PCS_ID))
                    .ForMember(x => x.DescripcionTipoSolicitud, map => map.MapFrom(dto => dto.PCS_NOMBRE))
                    .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.PCS_ESTADO))
                    .ReverseMap();

            CreateMap<TipoModalidad, TipoModalidadDto>()
                    .ForMember(x => x.IdTipoModalidad, map => map.MapFrom(dto => dto.TIM_ID))
                    .ForMember(x => x.DescripcionTipoModalidad, map => map.MapFrom(dto => dto.TIM_DESCRIPCION))
                    .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.TIM_ACTIVO))
                    .ForMember(x => x.codigoModalidad, map => map.MapFrom(dto => dto.TIM_CODIGO))
                    .ReverseMap();

            // listar los grupos de inconsistencias (1 y 2 por ahora)
            CreateMap<GrupoInconsistencia, GrupoInconsistenciaDto>()
                    .ForMember(x => x.IdGrupo, map => map.MapFrom(dto => dto.GIN_ID))
                    .ForMember(x => x.Grupo, map => map.MapFrom(dto => dto.GIN_GRUPO))
                    .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.GIN_ESTADO))
                    .ReverseMap();

            // listar las inconsistencias
            CreateMap<TipoInconsistencia, TipoInconsistenciaDto>()
                    .ForMember(x => x.GrupoInconsistencia, map => map.MapFrom(dto => dto.GIN_GRUPO))
                    .ForMember(x => x.IdTipoInconsistencia, map => map.MapFrom(dto => dto.LIN_ID))
                    .ForMember(x => x.DescripcionInconsistencia, map => map.MapFrom(dto => dto.LIN_DESCRIPCION))
                    .ReverseMap();

            // listar las herramientas
            CreateMap<HerramientaInconsistencia, HerramientaInconsistenciaDto>()
                    .ForMember(x => x.IdHerramienta, map => map.MapFrom(dto => dto.HER_ID))
                    .ForMember(x => x.HerramientaDescripcion, map => map.MapFrom(dto => dto.HER_DESCRIPCION))
                    .ReverseMap();

            // listar los puntos de atención
            CreateMap<PuntosAtencionInconsistencia, PuntosAtencionInconsistenciaDto>()
                    .ForMember(x => x.IdPuntosAtencion, map => map.MapFrom(dto => dto.PTA_ID))
                    .ForMember(x => x.PuntosAtencion, map => map.MapFrom(dto => dto.PTA_PUNTO))
                    .ReverseMap();

            CreateMap<TipoSubModalidad, TipoSubModalidadDto>()
                    .ForMember(x => x.IdTipoSubModalidad, map => map.MapFrom(dto => dto.TPS_SUB_ID))
                    .ForMember(x => x.DescripcionTipoSubModalidad, map => map.MapFrom(dto => dto.TPS_SUB_DESCRIPCION))
                    .ForMember(x => x.Activo, map => map.MapFrom(dto => dto.TPS_SUB_ACTIVO))
                    .ReverseMap();

            CreateMap<EstadoCartera, EstadoCarteraDto>()
                    .ForMember(x => x.IdEstado, map => map.MapFrom(dto => dto.EST_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.EST_DESCRIPCION))
                    .ReverseMap();

            CreateMap<TipoCuenta, TipoCuentaDto>()
                    .ForMember(x => x.idTipoCuenta, map => map.MapFrom(dto => dto.TCT_ID))
                    .ForMember(x => x.descripcionTipoCuenta, map => map.MapFrom(dto => dto.TCT_DESCRIPCION))
                    .ForMember(x => x.prefijoTipoCuenta, map => map.MapFrom(dto => dto.TCT_PREFIJO))
                    .ForMember(x => x.categoriaTipoCuenta, map => map.MapFrom(dto => dto.CAT_TIPO_GENERAL_CUENTA))
                    .ForMember(x => x.aplicaInteres, map => map.MapFrom(dto => dto.TCT_APLICAN_INTERESES))
                    .ForMember(x => x.aplicaRendimientos, map => map.MapFrom(dto => dto.TCT_APLICAN_RENDIMIENTOS))
                    .ForMember(x => x.aplicaCuotas, map => map.MapFrom(dto => dto.TCT_APLICAN_CUOTAS))
                    .ForMember(x => x.activo, map => map.MapFrom(dto => dto.TCT_ACTIVA))
                    .ForMember(x => x.centroCostoTipoCuenta, map => map.MapFrom(dto => dto.TCT_CENTRO_COSTO))
                    .ReverseMap();

            CreateMap<TipoCuentaC, TipoCuentaCDto>()
                    .ForMember(x => x.IdTipoCuentaC, map => map.MapFrom(dto => dto.TCT_ID))
                    .ForMember(x => x.DescripcionTipoCuentaC, map => map.MapFrom(dto => dto.TCT_DESCRIPCION))
                    .ForMember(x => x.PrefijoCuentaC, map => map.MapFrom(dto => dto.TCT_PREFIJO))
                    .ForMember(x => x.TipoGeneralCuentaC, map => map.MapFrom(dto => dto.CAT_TIPO_GENERAL_CUENTA))
                    .ForMember(x => x.AplicanInteresesCuentaC, map => map.MapFrom(dto => dto.TCT_APLICAN_INTERESES))
                    .ForMember(x => x.AplicanRendimientosCuentaC, map => map.MapFrom(dto => dto.TCT_APLICAN_RENDIMIENTOS))
                    .ForMember(x => x.AplicanCuotasCuentaC, map => map.MapFrom(dto => dto.TCT_APLICAN_CUOTAS))
                    .ForMember(x => x.ActivaCuentaC, map => map.MapFrom(dto => dto.TCT_ACTIVA))
                    .ForMember(x => x.CentroCostoCuenta, map => map.MapFrom(dto => dto.TCT_CENTRO_COSTO))
                    .ReverseMap();

            CreateMap<EntidadBancaria, EntidadBancariaDto>()
                   .ForMember(x => x.idEntidadBancaria, map => map.MapFrom(dto => dto.ENT_ID))
                   .ForMember(x => x.nombreRazonSocial, map => map.MapFrom(dto => dto.ENT_NOMBRE_RAZON_SOCIAL))
                   .ForMember(x => x.codigoBanco, map => map.MapFrom(dto => dto.ENT_CODIGO_BANCO))
                   .ForMember(x => x.estado, map => map.MapFrom(dto => dto.ENT_ESTADO))
                   .ForMember(x => x.creadoPor, map => map.MapFrom(dto => dto.ENT_CREATEDOPOR))
                   .ForMember(x => x.fechaCreacion, map => map.MapFrom(dto => dto.ENT_FECHACREACION))
                   .ForMember(x => x.modificadoPor, map => map.MapFrom(dto => dto.ENT_MODIFICADOPOR))
                   .ForMember(x => x.fechaModificacion, map => map.MapFrom(dto => dto.ENT_FECHAMODIFICACION))
                   .ReverseMap();

            CreateMap<Formato, FormatoDto>()
                   .ForMember(x => x.Id, map => map.MapFrom(dto => dto.FRT_ID))
                   .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.FRT_DESCRIPCION))
                   .ReverseMap();

            CreateMap<MedioDeEnvio, MedioDeEnvioDto>()
                   .ForMember(x => x.Id, map => map.MapFrom(dto => dto.MDE_ID))
                   .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.MDE_DESCRIPCION))
                   .ReverseMap();

            // Model EntidadEducativaDto EntidadEducativa
            CreateMap<EntidadEducativa, EntidadEducativaDto>()
                    .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                    .ForMember(x => x.TipoIdentificacion, map => map.MapFrom(dto => dto.ENE_TIPO_IDENTIFICACION))
                    .ForMember(x => x.Nit, map => map.MapFrom(dto => dto.ENE_NIT))
                    .ForMember(x => x.RazonSocial, map => map.MapFrom(dto => dto.ENE_NOMBRE_RAZON_SOCIAL))
                    .ForMember(x => x.CorreoElectronico, map => map.MapFrom(dto => dto.ENE_CORREO_ELECTRONICO))
                    .ForMember(x => x.Ciudad, map => map.MapFrom(dto => dto.ENE_DPC_ID))
                    .ForMember(x => x.Direccion, map => map.MapFrom(dto => dto.ENE_DIRECCION))
                    .ForMember(x => x.Telefono, map => map.MapFrom(dto => dto.ENE_TELEFONO))
                    .ForMember(x => x.Contacto, map => map.MapFrom(dto => dto.ENE_NOMBRE_CONTACTO))
                    .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ENE_ESTADO))
                    .ReverseMap();

            // Model SedeEntidadEducativaDto SedesEntidadEducativa
            CreateMap<SedeEntidadEducativa, SedeEntidadEducativaDto>()
                .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                .ForMember(x => x.CiudadId, map => map.MapFrom(dto => dto.SNE_SEDE_DPC_ID))
                .ForMember(x => x.IdSedeEntidad, map => map.MapFrom(dto => dto.SNE_SEDE_ID))
                .ForMember(x => x.NombreSede, map => map.MapFrom(dto => dto.SNE_SEDE_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.SNE_SEDE_ESTADO))
                .ReverseMap();

            //// Model EntidadEducativaDto EntidadEducativa
            CreateMap<EntidadEducativa, EntidadEducativaDto>()
                    .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                    .ForMember(x => x.TipoIdentificacion, map => map.MapFrom(dto => dto.ENE_TIPO_IDENTIFICACION))
                    .ForMember(x => x.Nit, map => map.MapFrom(dto => dto.ENE_NIT))
                    .ForMember(x => x.RazonSocial, map => map.MapFrom(dto => dto.ENE_NOMBRE_RAZON_SOCIAL))
                    .ForMember(x => x.CorreoElectronico, map => map.MapFrom(dto => dto.ENE_CORREO_ELECTRONICO))
                    .ForMember(x => x.Ciudad, map => map.MapFrom(dto => dto.ENE_DPC_ID))
                    .ForMember(x => x.Direccion, map => map.MapFrom(dto => dto.ENE_DIRECCION))
                    .ForMember(x => x.Telefono, map => map.MapFrom(dto => dto.ENE_TELEFONO))
                    .ForMember(x => x.Contacto, map => map.MapFrom(dto => dto.ENE_NOMBRE_CONTACTO))
                    .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ENE_ESTADO))
                    .ReverseMap();

            // Model ProgramaEducativoDto ProgramaEducativo
            CreateMap<ProgramaEducativo, ProgramaEducativoDto>()
                    .ForMember(x => x.Id, map => map.MapFrom(dto => dto.PGE_ID))
                    .ForMember(x => x.Descripcion, map => map.MapFrom(dto => dto.PGE_DESCRIPCION))
                    .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.PGE_ESTADO))
                    .ForMember(x => x.CreadoPor, map => map.MapFrom(dto => dto.PGE_CREATEDOPOR))
                    .ForMember(x => x.FechaCreacion, map => map.MapFrom(dto => dto.PGE_FECHACREACION))
                    .ForMember(x => x.ModificacionPor, map => map.MapFrom(dto => dto.PGE_MODIFICADOPOR))
                    .ForMember(x => x.FechaModificacion, map => map.MapFrom(dto => dto.PGE_FECHAMODIFICACION))
                    .ReverseMap();

            // Model ListarProgramaEducativoDto ListarProgramaEducativo
            CreateMap<ListarProgramaEducativo, ListarProgramaEducativoDto>()
                .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                .ForMember(x => x.RazonSocialEntidad, map => map.MapFrom(dto => dto.ENE_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.IdPrograma, map => map.MapFrom(dto => dto.PGE_ID))
                .ForMember(x => x.Programa, map => map.MapFrom(dto => dto.PGE_DESCRIPCION))
                .ForMember(x => x.NivelEducativoId, map => map.MapFrom(dto => dto.NVE_ID))
                .ForMember(x => x.NivelEducativo, map => map.MapFrom(dto => dto.NVE_DESCRIPCION))
                .ReverseMap();

            CreateMap<NivelEducativo, NivelEducativoDto>()
                    .ForMember(x => x.id, map => map.MapFrom(dto => dto.PRN_ID))
                    .ForMember(x => x.descripcion, map => map.MapFrom(dto => dto.NVE_DESCRIPCION))
                    .ReverseMap();

            CreateMap<EntidadSeguroEducativo, EntidadSeguroEducativoDto>()
                .ForMember(x => x.idEntidadSeguroEducativo, map => map.MapFrom(dto => dto.ESE_ID))
                .ForMember(x => x.numeroIdentificacion, map => map.MapFrom(dto => dto.ESE_NUMERO_IDENTIFICACION))
                .ForMember(x => x.nombreRazonSocial, map => map.MapFrom(dto => dto.ESE_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.tipoIdentificacion, map => map.MapFrom(dto => dto.TID_ID_FK))
                .ReverseMap();

            // Model CuentaBancariaEntidadEducativaDto CuentaBancariaEntidadEducativa
            CreateMap<CuentaBancariaEntidadEducativa, CuentaBancariaEntidadEducativaDto>()
                .ForMember(x => x.IdCuentaBancaria, map => map.MapFrom(dto => dto.ENE_CTA_BANCARIA))
                .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                .ForMember(x => x.Estado, map => map.MapFrom(dto => dto.ENE_CTA_ESTADO))
                .ForMember(x => x.RazonSocialEntidad, map => map.MapFrom(dto => dto.ENT_NOMBRE_RAZON_SOCIAL))
                .ForMember(x => x.IdEntidadBancaria, map => map.MapFrom(dto => dto.ENE_ENT_ID))
                .ForMember(x => x.NumeroCuenta, map => map.MapFrom(dto => dto.ENE_NUMERO_CTA))
                .ReverseMap();

            // Model BloqueoEntidadEducativaDto BloqueoEntidadEducativa
            CreateMap<BloqueoEntidadEducativa, BloqueoEntidadEducativaDto>()
                .ForMember(x => x.IdBloqueo, map => map.MapFrom(dto => dto.ENE_BLOQUEO))
                .ForMember(x => x.IdEntidad, map => map.MapFrom(dto => dto.ENE_ID))
                .ForMember(x => x.IdTipoOperacion, map => map.MapFrom(dto => dto.ENE_TIPO_OPERACION))
                .ForMember(x => x.IdCausalBloqueo, map => map.MapFrom(dto => dto.ENE_CAUSAL_BLOQUEO))
                .ForMember(x => x.FechaBloqueo, map => map.MapFrom(dto => dto.ENE_FECHA_BLOQUEO))
                .ForMember(x => x.FuncionarioBloqueo, map => map.MapFrom(dto => dto.ENE_FUNCIONARIO_BLOQUEO))
                .ReverseMap();

            CreateMap<TipoAfiliacion, TipoAfiliacionDto>()
                .ForMember(x => x.IdTipoAfiliacion, map => map.MapFrom(dto => dto.TPF_ID))
                .ForMember(x => x.DescripcionTipoAfiliacion, map => map.MapFrom(dto => dto.TPF_DESCRIPCION))
                .ReverseMap();

            CreateMap<EstadoAfiliacion, EstadoAfiliacionDto>()
                .ForMember(x => x.IdEstadoAfiliacion, map => map.MapFrom(dto => dto.EAF_ID))
                .ForMember(x => x.DescripcionEstadoAfiliacion, map => map.MapFrom(dto => dto.EAF_DESCRIPCION))
                .ReverseMap();

            CreateMap<CampoCalidad, CampoCalidadDto>()
                .ForMember(x => x.IdCampoCalidad, map => map.MapFrom(dto => dto.CLD_ID))
                .ForMember(x => x.DescripcionCampoCalidad, map => map.MapFrom(dto => dto.CLD_DESCRIPCION))
                .ReverseMap();

            CreateMap<TipoAfiliacionProcedente, TipoAfiliacionProcedenteDto>()
                .ForMember(x => x.IdTipoAfiliacionProcedente, map => map.MapFrom(dto => dto.TPF_ID))
                .ForMember(x => x.DescripcionTipoAfiliacionProcedente, map => map.MapFrom(dto => dto.TPF_DESCRIPCION))
                .ReverseMap();

            CreateMap<PorcentajeDescuento, PorcentajeDescuentoDto>()
                .ForMember(x => x.IdPorcentajeDescuento, map => map.MapFrom(dto => dto.PRC_ID))
                .ForMember(x => x.DescripcionPorcentajeDescuento, map => map.MapFrom(dto => dto.PRC_DESCRIPCION))
                 .ForMember(x => x.ProductoDescuento, map => map.MapFrom(dto => dto.PRC_PRODUCTO))
                .ReverseMap();

            CreateMap<TipoSolicitudNovedadMatricula, TipoSolicitudNovedadMatriculaDto>()
                .ForMember(x => x.IdTipoSolicitud, map => map.MapFrom(dto => dto.TSN_ID))
                .ForMember(x => x.DescripcionTipoSolicitud, map => map.MapFrom(dto => dto.TSN_DESCRIPCION))
                .ReverseMap();

            CreateMap<CausalBloqueo, CausalBloqueoDto>()
                .ForMember(x => x.IdCausalBloqueo, map => map.MapFrom(dto => dto.CAN_ID))
                .ForMember(x => x.DescripcionCausalBloqueo, map => map.MapFrom(dto => dto.DESCRIPCION))
                .ReverseMap();

            CreateMap<EstadoTareaSolicitud, EstadoTareaSolicitudDto>()
                .ForMember(source => source.Id, map => map.MapFrom(destino => destino.CVL_ID))
                .ForMember(source => source.Codigo, map => map.MapFrom(destino => destino.CVL_CODIGO))
                .ForMember(source => source.Descripcion, map => map.MapFrom(destino => destino.CVL_DESCRIPCION))
                .ForMember(source => source.Estado, map => map.MapFrom(destino => destino.CVL_ACTIVO))
                .ReverseMap();

            CreateMap<NivelAcademicoCatalogo, NivelAcademicoCatalogoDto>()
               .ForMember(source => source.Id, map => map.MapFrom(destino => destino.CVL_ID))
               .ForMember(source => source.Codigo, map => map.MapFrom(destino => destino.CVL_CODIGO))
               .ForMember(source => source.Descripcion, map => map.MapFrom(destino => destino.CVL_DESCRIPCION))
               .ForMember(source => source.Estado, map => map.MapFrom(destino => destino.CVL_ACTIVO))
               .ReverseMap();


            
        }
    }
}
