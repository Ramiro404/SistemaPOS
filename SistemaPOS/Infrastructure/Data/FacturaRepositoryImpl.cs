using Microsoft.EntityFrameworkCore;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Persistence;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting.Server;

namespace SistemaPOS.Infrastructure.Data
{
    public class FacturaRepositoryImpl : FacturaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly Decimal VALOR_IMPUESTOS = 0.16M;
        private readonly Decimal VALOR_DESCUENTO = 0;

        public FacturaRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task FacturarPedido(List<Pedido> pedidos)
        {
            //var productosPedido = await _context.Productos.Join(pedidos,
            //    pr => pr.Id,
            //    pe => pe.ProductoId,
            //    (producto, pedido) => producto
            //    ).ToListAsync();

            //if(productosPedido == null)
            //{
            //    throw new Exception("No hay ningun producto en el pedido");
            //}

            //int folio = await _context.Facturas.CountAsync();
            //folio = (folio == 0) ? 1 : (folio + 1);
            //var valoresTotales = from pr in productosPedido
            //                     join pe in pedidos on
            //                     pr.Id equals pe.ProductoId
            //                     select ( pr.ValorUnitario * pe.Cantidad );
            //Decimal valorTotal = valoresTotales.Sum();
            //Decimal valorImpuesto = VALOR_IMPUESTOS;
            //Factura factura = new Factura(folio.ToString(), valorTotal, valorImpuesto, VALOR_DESCUENTO);
            //_context.Facturas.Add(factura);
            //await _context.SaveChangesAsync();

            //foreach(var pe in pedidos)
            //{
            //    PedidoFactura pf = new PedidoFactura(pe.Id, factura.Id);
            //    _context.PedidosFactura.Add(pf);
            //    await _context.SaveChangesAsync();
            //}

        }

        public async Task<List<Factura>> ListarFacturaDeCliente(int clienteId) { 
            return await (from fa in _context.Facturas
                          join peFa in _context.PedidosFactura on fa.Id equals peFa.FacturaId
                          join pe in _context.Pedidos on peFa.PedidoId equals pe.Id
                          where pe.ClienteId == clienteId
                          select new Factura(
                              fa.Id,
                              fa.Folio,
                              fa.ValorTotal,
                              fa.ValorImpuestos,
                              fa.ValorDescuento,
                              fa.FechaCreacion
                              )).ToListAsync();
        }

        public async Task<string> ImprimirFactura(int facturaId)
        {
            var pedido = await (
                from pe in _context.Pedidos
                where pe.FacturaId == facturaId
                select pe).SingleOrDefaultAsync();

            if(pedido == null)
            {
                throw new Exception("Pedido no encontrado");
            }

            var pedidoDetalles = await (
                from pd in _context.PedidosDetalle
                where pd.PedidoId == pedido.Id
                select pd).ToListAsync();
            //var facturaDatos = await (from fa in _context.Facturas
            // join peFa in _context.PedidosFactura on fa.Id equals peFa.FacturaId
            // join pe in _context.Pedidos on peFa.PedidoId equals pe.Id
            // join cl in _context.Clientes on pe.ClienteId equals cl.Id
            // join pr in _context.Productos on pe.ProductoId equals pr.Id
            // where fa.Id == facturaId
            // select new FacturaImpresion
            // {
            //     factura= fa,
            //     cliente= cl,
            //     pedido= pe,
            //     producto= pr
            // }).ToListAsync();

            //if( facturaDatos.Count == 0) { throw new Exception("No se encontro la factura"); }
            Cliente cliente = await _context.Clientes.FindAsync(pedido.ClienteId);
            if(cliente == null)
            {
                throw new Exception("No se encontro el cliente");
            }
            var mem = new MemoryStream();


            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(doc, mem);
            doc.AddTitle("Factura");
            doc.AddAuthor("Ferreteria XYZ");
            doc.Open();

            doc.Add(new Paragraph("Factura Electronica"));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Cliente: " + cliente.NumeroDocumento));

            PdfPTable pdfPTable = new PdfPTable(8);
            pdfPTable.WidthPercentage = 100;

            PdfPCell clId = new PdfPCell(new Phrase("#", _standardFont));
            clId.BorderWidth = 0;
            clId.BorderWidthBottom = 0.75f;

            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clValorUnitario = new PdfPCell(new Phrase("Valor Unitario", _standardFont));
            clValorUnitario.BorderWidth = 0;
            clValorUnitario.BorderWidthBottom = 0.75f;

            PdfPCell clMedida = new PdfPCell(new Phrase("Medida", _standardFont));
            clMedida.BorderWidth = 0;
            clMedida.BorderWidthBottom = 0.75f;

            PdfPCell clUnidadMedida = new PdfPCell(new Phrase("Unida de Medida", _standardFont));
            clUnidadMedida.BorderWidth = 0;
            clUnidadMedida.BorderWidthBottom = 0.75f;

            PdfPCell clPeso = new PdfPCell(new Phrase("Peso", _standardFont));
            clPeso.BorderWidth = 0;
            clPeso.BorderWidthBottom = 0.75f;

            PdfPCell clCantidad = new PdfPCell(new Phrase("Cantidad", _standardFont));
            clCantidad.BorderWidth = 0;
            clCantidad.BorderWidthBottom = 0.75f;

            PdfPCell clValorTotal = new PdfPCell(new Phrase("ValorTotal", _standardFont));
            clValorTotal.BorderWidth = 0;
            clValorTotal.BorderWidthBottom = 0.75f;

            pdfPTable.AddCell(clId);
            pdfPTable.AddCell(clNombre);
            pdfPTable.AddCell(clValorUnitario);
            pdfPTable.AddCell(clMedida);
            pdfPTable.AddCell(clUnidadMedida);
            pdfPTable.AddCell(clPeso);
            pdfPTable.AddCell(clCantidad);
            pdfPTable.AddCell(clValorTotal);
            int contador = 1;
            foreach( var fd in pedidoDetalles)
            {
                var producto = await _context.Productos.Where(pr => pr.Id == fd.ProductoId).SingleAsync();
                clId = new PdfPCell(new Phrase(contador.ToString(), _standardFont));
                clNombre = new PdfPCell(new Phrase(producto.Nombre, _standardFont));
                clValorUnitario = new PdfPCell(new Phrase(producto.ValorUnitario.ToString(), _standardFont));
                clMedida = new PdfPCell(new Phrase(producto.Medida.ToString(), _standardFont));
                clUnidadMedida = new PdfPCell(new Phrase(producto.UnidadMedida, _standardFont));
                clPeso = new PdfPCell(new Phrase(producto.Peso.ToString(), _standardFont));
                clCantidad = new PdfPCell(new Phrase(fd.Cantidad.ToString(), _standardFont));
                clValorTotal = new PdfPCell(new Phrase("$" + (producto.ValorUnitario * fd.Cantidad), _standardFont));

                contador++;

                pdfPTable.AddCell(clId);
                pdfPTable.AddCell(clNombre);
                pdfPTable.AddCell(clValorUnitario);
                pdfPTable.AddCell(clMedida);
                pdfPTable.AddCell(clUnidadMedida);
                pdfPTable.AddCell(clPeso);
                pdfPTable.AddCell(clCantidad);
                pdfPTable.AddCell(clValorTotal);
            }

            doc.Add(pdfPTable);
            doc.Close();
            writer.Close();

            var pdf = mem.ToArray();
            return  Convert.ToBase64String(pdf);

            //if (facturaDatos.Cliente == null)
            //{
            //    throw new Exception("No se encontro la factura");
            //}
            //var productos = await (
            //    from pedido in _context.Pedidos 
            //    where pedido.ClienteId == facturaDatos.Cliente.Id
            //    select pedido).ToListAsync();

            //var productosIds = productos.Select(pr => pr.Id).ToList();


            //facturaDatos.Pedidos = new List<ProductoPedidoDto>(); 
            //facturaDatos.Pedidos = await (
            //    from producto in _context.Productos
            //    where productosIds.Contains(producto.Id)
            //    select producto);

        }

        public async Task FacturarPedido(int pedidoId)
        {
            var pedido = await _context.Pedidos.FindAsync(pedidoId);
            if(pedido == null)
            {
                throw new Exception("Pedido no encontrado");
            }
            var pedidosDetalle = await _context.PedidosDetalle.Where(pd => pd.PedidoId.Equals(pedido.Id)).ToListAsync();
            if(pedidosDetalle.Count() == 0)
            {
                throw new Exception("No hay preductos en el pedido");
            }
            Decimal total = 0;
            foreach(PedidoDetalle pd in pedidosDetalle)
            {
                var producto = await _context.Productos.FindAsync(pd.ProductoId);
                if(producto == null)
                {
                    throw new Exception("No se encontro el producto");
                }
                total += producto.ValorUnitario * pd.Cantidad;
            }
            int count  =  _context.Facturas.Count();
            count++;
            Factura factura = new Factura(
                count.ToString().PadLeft(7, '0'),
                total,
                VALOR_IMPUESTOS,
                VALOR_DESCUENTO
                );
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
            pedido.setFacturaId(factura.Id);
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<PedidoFacturadoDto>> ListarFacturas()
        {
            return await (
                from fa in _context.Facturas
                join pe in _context.Pedidos on fa.Id equals pe.FacturaId
                join cl in _context.Clientes on pe.ClienteId equals cl.Id
                select new PedidoFacturadoDto {
                    Id = fa.Id,
                    FechaFacturacion= fa.FechaCreacion,
                    NumeroDocumento= cl.NumeroDocumento
                }).ToListAsync();
        }


    }
}
