﻿namespace SistemasWeb01.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Producto producto { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }

    }
}
