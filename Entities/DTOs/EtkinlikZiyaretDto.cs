using Entities.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EtkinlikZiyaretDto:BaseEntity
    {
        public decimal AylikUcret { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public string Adi { get; set; }
    }
}
