using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GA2.Infraestructure.Repositories
{
    public class CuentasClientesRepository : DapperGenerycRepository, ICuentasClientesRepository
    {
        public CuentasClientesRepository(IConfiguration configuration) : base(configuration){}

        public async Task<InfoDetalleCliente> ObtenerDetalleInfoCliente(InfoCliente cliente)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.TID_ID), cliente.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.FRZ_ID), cliente.FRZ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.GRD_ID), cliente.GRD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.CTG_ID), cliente.CTG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.UEJ_ID), cliente.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.TPF_ID), cliente.TPF_ID);

            

            return await GetAsyncFirst<InfoDetalleCliente>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<TipoCuentaC>> ObtenerTipoCuentaC()
        {
            return await GetAsyncList<TipoCuentaC>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CausalEstadoCuenta>> ObtenerCausalEstadoCuenta()
        {
            return await GetAsyncList<CausalEstadoCuenta>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PorcentajeDescuento>> ObtenerPorcentajesDescuento()
        {
            return await GetAsyncList<PorcentajeDescuento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

    }
}
