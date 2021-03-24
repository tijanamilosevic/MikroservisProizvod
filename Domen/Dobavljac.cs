﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Dobavljac
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string PIB { get; set; }
        [Required]
        public string Naziv { get; set; }
        
        public string Napomena { get; set; } // moze null?

        public List<Proizvod> Proizvodi { get; set; }
    }
}
