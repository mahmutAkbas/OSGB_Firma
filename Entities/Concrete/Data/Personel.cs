using System;

namespace Entities.Concrete.Data
{
    public class Personel:BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Telefon { get; set; }
        public int UnvanId { get; set; }    
        public DateTime KayitTarihi { get; set; }
        public bool SilinmeDurumu { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}
