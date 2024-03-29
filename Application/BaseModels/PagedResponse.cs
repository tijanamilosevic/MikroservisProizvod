﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Application.BaseModels
{
    public class PagedResponse<TDto> : ILoggableObject
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => (CurrentPage > 1); //true ako je curent page >1
        public bool HasNext => (CurrentPage < TotalPages); //true ako je ispunjen ovaj uslov
        public IEnumerable<TDto> Data { get; set; }
    }
}
