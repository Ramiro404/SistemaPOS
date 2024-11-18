﻿using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Aplication.DTOs
{
    public class FacturaDto
    {
        public Cliente Cliente { get; set; }
        public List<ProductoPedidoDto> Pedidos { get; set; }
        public Factura Factura { get; set; }
    }
}