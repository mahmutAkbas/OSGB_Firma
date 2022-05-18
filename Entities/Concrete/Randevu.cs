using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    internal class Randevu
    {
        public int ID { get; set; }
        public int yurutucuFirmaId { get; set; }
        public DateTime randevuTarihi { get; set; }
        public Boolean onay { get; set; }

    }
}
