using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data.Producto;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Repositorio producto
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    /// </summary>
    public class ProductoRepository : DapperGenerycRepository, IProductoRepository
    {
        /// <summary>
        /// Constructor repositorio
        /// </summary>

        /// <param name="configuration"></param>
        public ProductoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Metodo Actualiza un producto
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task<Producto> ActualizarProducto(Producto producto)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_NUMERO_CREDITO), producto.PRD_NUMERO_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.TCR_ID), producto.TCR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_FECHA_ALTA), producto.PRD_FECHA_ALTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_ESTADO), producto.PRD_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_FECHA_ESTADO), producto.PRD_FECHA_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_FECHA_PAGO), producto.PRD_FECHA_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_DIAS_MORA), producto.PRD_DIAS_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_VALOR), producto.PRD_VALOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.TIV_VIVIENDA_ID), producto.TIV_VIVIENDA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.ESV_ESTADO_VIVIENDA), producto.ESV_ESTADO_VIVIENDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_CREDITO), producto.PRD_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_DEUDA), producto.PRD_DEUDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_MORA), producto.PRD_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_CUOTA_ANO), producto.PRD_CUOTA_ANO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_CUOTA_MES), producto.PRD_CUOTA_MES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_SEGURO_VIDA), producto.PRD_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_TASA_EFECTIVA_ANUAL), producto.PRD_TASA_EFECTIVA_ANUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_TASA_NOMINAL_MENSUAL), producto.PRD_TASA_NOMINAL_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_TASA_FRECH_APLICA), producto.PRD_TASA_FRECH_APLICA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_TASA_FRECH), producto.PRD_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_ALIVIO_CUOTA_APLICA), producto.PRD_ALIVIO_CUOTA_APLICA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_ALIVIO_CUOTA), producto.PRD_ALIVIO_CUOTA);
            return await GetAsyncFirst<Producto>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Metodo Crea un producto
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task<Producto> CrearProducto(Producto producto)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_NUMERO_CREDITO), producto.PRD_NUMERO_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.TCR_ID), producto.TCR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_FECHA_ALTA), producto.PRD_FECHA_ALTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_ESTADO), producto.PRD_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_FECHA_ESTADO), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_FECHA_PAGO), producto.PRD_FECHA_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_DIAS_MORA), producto.PRD_DIAS_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_VALOR), producto.PRD_VALOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.TIV_VIVIENDA_ID), producto.TIV_VIVIENDA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.ESV_ESTADO_VIVIENDA), producto.ESV_ESTADO_VIVIENDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_CREDITO), producto.PRD_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_DEUDA), producto.PRD_DEUDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_MORA), producto.PRD_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_CUOTA_ANO), producto.PRD_CUOTA_ANO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_CUOTA_MES), producto.PRD_CUOTA_MES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_SEGURO_VIDA), producto.PRD_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_SEGURO_TODO_RIESGO), producto.PRD_SEGURO_TODO_RIESGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_TASA_EFECTIVA_ANUAL), producto.PRD_TASA_EFECTIVA_ANUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_TASA_NOMINAL_MENSUAL), producto.PRD_TASA_NOMINAL_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_TASA_FRECH_APLICA), producto.PRD_TASA_FRECH_APLICA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_TASA_FRECH), producto.PRD_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_ALIVIO_CUOTA_APLICA), producto.PRD_ALIVIO_CUOTA_APLICA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_ALIVIO_CUOTA), producto.PRD_ALIVIO_CUOTA);


            return await GetAsyncFirst<Producto>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }


        /// <summary>
        /// Cambia el estado del producto a eliminado
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Producto> EliminarProducto(Producto producto)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_NUMERO_CREDITO), producto.PRD_NUMERO_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_ESTADO), producto.PRD_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_FECHA_ESTADO), producto.PRD_FECHA_ESTADO);
            return await GetAsyncFirst<Producto>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Obtiene un producto por el id del mismo
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Producto> ObtenerProductoByID(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductoParameters.PRD_NUMERO_CREDITO), id);

            return await GetAsyncFirst<Producto>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
