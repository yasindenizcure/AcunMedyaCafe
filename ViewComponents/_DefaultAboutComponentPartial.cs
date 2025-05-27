﻿using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _DefaultAboutComponentPartial: ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultAboutComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}

