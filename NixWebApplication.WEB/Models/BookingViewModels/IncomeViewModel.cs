﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NixWebApplication.WEB.Models.BookingViewModels
{
    public class IncomeViewModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
