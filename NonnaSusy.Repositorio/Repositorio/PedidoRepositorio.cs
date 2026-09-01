using NonnaSusy.DB.Data;
using NonnaSusy.DB.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NonnaSusy.Shared.DTO;

namespace NonnaSusy.Repositorio.Repositorio
{
    public class PedidoRepositorio : Repositorio<Pedido>, IPedidoRepositorio
    {
        private readonly Context context;

        public PedidoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> InsertarPedido(Pedido pedido, List<Renglon> renglones)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    context.Pedidos.Add(pedido);

                    await context.SaveChangesAsync();

                    foreach (var renglon in renglones)
                    {
                        renglon.PedidoID = pedido.ID;
                        context.Renglones.Add(renglon);
                    }

                    await context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return pedido.ID;

                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<List<GetPedidoDTO>> SelectListaPedidos()
        {
            var pedidos = await context.Pedidos
                    .Include(p => p.Cliente)
                    .Include(p => p.Renglones)
                            .ThenInclude(r => r.Producto)
                    .ToListAsync();

            return pedidos.Select(p => new GetPedidoDTO
            {
                NombreCliente = p.Cliente.NombreCliente,
                FechaPedido = p.FechaPedido,
                RenglonesDTO = p.Renglones.Select(r => new GetRenglonDTO
                {
                    Cantidad = r.Cantidad,
                    ProductoNombre = r.Producto.NombreProducto // Aquí se obtiene el nombre del producto
                }).ToList()
            }).ToList();


        }
    }
}
