using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    internal class Personel
    {
        public int ID { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string telefon { get; set; }
        public DateTime kayitTarihi { get; set; }
        public Boolean silinmeDurumu { get; set; }
        public DateTime silinmeTarihi { get; set; }
        public int unvanId { get; set; }

    }
}
