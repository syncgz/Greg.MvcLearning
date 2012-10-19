﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}