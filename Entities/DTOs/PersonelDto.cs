using Entities.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PersonelDto:BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Telefon { get; set; }
        public string UnvanAdi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool SilinmeDurumu { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public int UnvanId { get; set; }

        public override string ToString()
        {
            return $"{Adi} {Soyadi}";
        }
    }
}
