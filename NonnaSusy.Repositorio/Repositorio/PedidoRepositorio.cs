using NonnaSusy.DB.Data;
using NonnaSusy.DB.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace NonnaSusy.Repositorio.Repositorio
{
    public class PedidoRepositorio : Repositorio<Pedido>, IPedidoRepositorio
    {
        private readonly Context context;

        public PedidoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> InsertarPedido(/*var PedidoDTO*/)
        {
            //Mock para que permita la compilacion
            Pedido pedido = new Pedido();
            //var pedido = new Pedido
            //{
            //    ClienteID = PedidoDTO.ClienteID,
            //    FechaPedido = DateOnly.FromDateTime(DateTime.Now.Date + TimeSpan.FromDays(1)),
            //    Renglones = PedidoDTO.Renglones.Select(r => new RenglonDTO
            //    {
            //        ProductoID = r.ProductoID,
            //        Cantidad = r.Cantidad
            //    }).ToList()


            //};
            await context.Pedidos.AddAsync(pedido);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Pedido>> SelectListaPedidos()
        {
            return await context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Renglones)
                    .ThenInclude(r => r.Producto.NombreProducto)
                .ToListAsync();
        }
    }
}
