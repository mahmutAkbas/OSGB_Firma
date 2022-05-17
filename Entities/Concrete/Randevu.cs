using System;

namespace Entities.Concrete
{
    public class Randevu
    {
        public int randevu_id { get; set; }
        public DateTime randevu_tarihi { get; set; }
        public int firma_id { get; set; }
        public bool randevu_durumu { get; set; }
        public string aciklama { get; set; }
    }
}
