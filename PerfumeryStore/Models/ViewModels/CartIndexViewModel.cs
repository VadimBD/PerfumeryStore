﻿namespace PerfumeryStore.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = string.Empty;
    }
}
