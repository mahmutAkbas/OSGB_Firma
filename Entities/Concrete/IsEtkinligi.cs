using System;

namespace Entities.Concrete
{
    public class IsEtkinligi
    {
        public int etkinlik_id { get; set; }
        public int hekim_id { get; set; }
        public int isguzm_id { get; set; }
        public DateTime kayit_tarihi { get; set; }
        public decimal brut_fiyat { get; set; }
        public decimal vergi { get; set; }
        public decimal kar { get; set; }
        public decimal net_fiyat { get; set; }
    }
}
