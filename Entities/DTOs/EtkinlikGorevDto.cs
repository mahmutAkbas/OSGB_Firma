using Entities.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EtkinlikGorevDto:BaseEntity
    {
        public string Adi { get; set; }
        public DateTime Tarih { get; set; }
    }
}
