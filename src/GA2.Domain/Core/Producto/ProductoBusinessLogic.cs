using AutoMapper;
using GA2.Application.Dto.Producto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Reglas de negocio para Producto
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class ProductoBusinessLogic : IProductoBusinessLogic
    {
        /// <summary>
        /// Propiedades privadas Core Negocio
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;
        private readonly ITokenClaims _tokenClaims;

        public ProductoBusinessLogic(IMapper mapper, IProductoRepository productoRepository, ITokenClaims tokenClaims)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
            _tokenClaims = tokenClaims;
        }
        /// <summary>
        /// Metodo logica de negocio para actualizar un producto
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response<ProductoDTO>> ActualizarProducto(ProductoDTO producto)
        {
            ProductoDTO nuevoProducto = producto;
            var productoExistente = this._mapper.Map<ProductoDTO>(await _productoRepository.ObtenerProductoByID(producto.PRD_NUMERO_CREDITO));
            if (productoExistente != null)
            {
                if (producto.PRD_ALIVIO_CUOTA_APLICA == producto.PRD_TASA_FRECH_APLICA) return new Response<ProductoDTO>
                { IsSuccess = false, ReturnMessage = "El Producto No Puede Tener Activos Dos Beneficios Al Mismo Tiempo" };
                else if (nuevoProducto.PRD_NUMERO_CREDITO != productoExistente.PRD_NUMERO_CREDITO) return new Response<ProductoDTO>
                { IsSuccess = false, ReturnMessage = "El Número De Producto No Es Modificable" };
                if (nuevoProducto.PRD_ESTADO != productoExistente.PRD_ESTADO) nuevoProducto.PRD_FECHA_ESTADO = DateTime.Now;
                else if (nuevoProducto.PRD_FECHA_ESTADO != productoExistente.PRD_FECHA_ESTADO) nuevoProducto.PRD_FECHA_ESTADO = productoExistente.PRD_FECHA_ESTADO;

                return new Response<ProductoDTO>
                {
                    Data = this._mapper.Map<ProductoDTO>(await _productoRepository.ActualizarProducto(
                    this._mapper.Map<Producto>(nuevoProducto)))
                };
            }
            else return new Response<ProductoDTO> { IsSuccess = false, ReturnMessage = "El Número De Producto No Existe" };
        }



        /// <summary>
        /// Metodo logica de negocio para crear un producto
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task<Response<ProductoDTO>> CrearProducto(ProductoDTO producto)
        {
            ProductoDTO productoCreado = producto;
            if (producto.PRD_ALIVIO_CUOTA_APLICA != producto.PRD_TASA_FRECH_APLICA) return new Response<ProductoDTO>
            {
                Data = this._mapper.Map<ProductoDTO>(await _productoRepository.CrearProducto(
                    this._mapper.Map<Producto>(productoCreado)))
            };
            else return new Response<ProductoDTO> { IsSuccess = false, ReturnMessage = "El Producto No Puede Tener Activos Dos Beneficios Al Mismo Tiempo" };
        }
        /// <summary>
        /// metodo logica de negocio para eliminar un producto
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response<ProductoDTO>> EliminarProducto(int id)
        {
            var productoExistente = this._mapper.Map<ProductoDTO>(await _productoRepository.ObtenerProductoByID(id));
            if (productoExistente != null)
            {
                productoExistente.PRD_ESTADO = "ELIMINADO";
                productoExistente.PRD_FECHA_ESTADO = DateTime.Now;
                var productoEliminado = this._mapper.Map<ProductoDTO>(await _productoRepository.EliminarProducto(
                    this._mapper.Map<Producto>(productoExistente)));

                return new Response<ProductoDTO> { Data = productoEliminado };
            }
            else return new Response<ProductoDTO> { IsSuccess = false, ReturnMessage = "El Número De Producto No Existe" };
        }
        /// <summary>
        /// Metodo logica de negocio para obtener un producto mediante su ID
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response<ProductoDTO>> ObtenerProductoByID(int id)
        {
            var productoObtenido = this._mapper.Map<ProductoDTO>(await _productoRepository.ObtenerProductoByID(id));
            if (productoObtenido != null) return new Response<ProductoDTO> { Data = productoObtenido };
            else return new Response<ProductoDTO> { IsSuccess = false, ReturnMessage = "El Número De Producto No Existe" };
        }
    }
}
