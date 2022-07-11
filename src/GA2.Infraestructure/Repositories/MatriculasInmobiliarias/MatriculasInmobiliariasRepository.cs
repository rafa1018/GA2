using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public class MatriculasInmobiliariasRepository : DapperGenerycRepository, IMatriculasInmobiliariasRepository
    {
        public MatriculasInmobiliariasRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<CrearMatricula> CrearMatriculaInmobiliaria(CrearMatricula crearMatricula)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_NUMERO_MATRICULA), crearMatricula.MAI_NUMERO_MATRICULA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_FECHA_REGISTRO), crearMatricula.MAI_FECHA_REGISTRO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_DIRECCION), crearMatricula.MAI_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.DPD_DEPARTAMENTO), crearMatricula.DPD_DEPARTAMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.DPC_NOMBRE_CIUDAD), crearMatricula.DPC_NOMBRE_CIUDAD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.PRP_TIPO_IDENTIFICACION), crearMatricula.PRP_TIPO_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.PRP_NUMERO_IDENTIFICACION), crearMatricula.PRP_NUMERO_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.PRP_NOMBRE_RAZON_SOCIAL), crearMatricula.PRP_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.CORREO), crearMatricula.CORREO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.TELEFONO), crearMatricula.TELEFONO);

            return await GetAsyncFirst<CrearMatricula>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<PropietariosMatriculasInmobiliarias> EditarHistorialPropietarios(PropietariosMatriculasInmobiliarias request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumHistorialPropietarios.PRP_ID), request.PRP_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumHistorialPropietarios.MAI_ID), request.MAI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumHistorialPropietarios.PRP_NOMBRE_RAZON_SOCIAL), request.PRP_NOMBRE_RAZON_SOCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumHistorialPropietarios.TID_ID), request.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumHistorialPropietarios.PRP_NUMERO_IDENTIFICACION), request.PRP_NUMERO_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumHistorialPropietarios.TELEFONO), request.TELEFONO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumHistorialPropietarios.CORREO), request.CORREO);

            return await GetAsyncFirst<PropietariosMatriculasInmobiliarias>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<MatriculaInmibiliaria> EditarInformacionBasicaMatricula(MatriculaInmibiliaria request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_NUMERO_MATRICULA), request.MAI_NUMERO_MATRICULA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_FECHA_REGISTRO), request.MAI_FECHA_REGISTRO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_DIRECCION), request.MAI_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.DPD_DEPARTAMENTO), request.DPD_ID_FK);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.DPC_NOMBRE_CIUDAD), request.DPC_ID_FK);

            return await GetAsyncFirst<MatriculaInmibiliaria>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<MatriculaInmibiliaria> EliminarMatriculaInmobiliaria(Guid idMatricula)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_ID), idMatricula);

            return await GetAsyncFirst<MatriculaInmibiliaria>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MatriculaInmibiliaria>> FiltroMatriculaInmobiliaria(string Numero_matricula, string numero_identifiucacion, int tipo_documento)
        {


            string numberMatricula = null;
            string numberPropietario = null;
            if (Numero_matricula != "") numberMatricula = Numero_matricula;
            if (numero_identifiucacion != "") numberPropietario = numero_identifiucacion;
 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_NUMERO_MATRICULA), numberMatricula);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.PRP_NUMERO_IDENTIFICACION), numberPropietario);

             parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.TID_ID), null);
           

             return await GetAsyncList<MatriculaInmibiliaria>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<HistotialNovedadesMatriculasInmobiliarias>> HistorialNovedadsMatriculaInmobiliariaById(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_ID), id);
            return await GetAsyncList<HistotialNovedadesMatriculasInmobiliarias>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PropietariosMatriculasInmobiliarias>> HistorialPropietariosMatriculaInmobiliariaById(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_ID), id);
            return await GetAsyncList<PropietariosMatriculasInmobiliarias>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<MatriculaInmibiliaria> InformacionBasicaMatriculaInmobiliariaById(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFiltroMatriculasInmobiliarias.MAI_ID), id);
            return await GetAsyncFirst<MatriculaInmibiliaria>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<NovedadesMatriculasInmobiliarias>> InsertNovedMatriculaInmobiliaria(NovedadesMatriculasInmobiliarias novedad)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNovedadMatriculasInmobiliarias.MAI_ID), novedad.MAI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNovedadMatriculasInmobiliarias.TOP_ID), novedad.TOP_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNovedadMatriculasInmobiliarias.CAN_ID), novedad.CAN_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNovedadMatriculasInmobiliarias.TSN_ID), novedad.TSN_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNovedadMatriculasInmobiliarias.NVM_CREATEDOPOR), null);
     
            return await GetAsyncList<NovedadesMatriculasInmobiliarias>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CausalNovedamatricula>> listarCausalNovedamatriculaById(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNovedadMatriculasInmobiliarias.TOP_ID), id);
            return await GetAsyncList<CausalNovedamatricula>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<OperacionesMatriculas>> listarOperacionesMatriculas()
        {
            return await GetAsyncList<OperacionesMatriculas>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

    }
}
