using System;

namespace Entities.Concrete
{
    public class Personel
    {
        public int personel_id { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string telefon   { get; set; }
        public string email { get; set; }
        public int unvan { get; set; }
        public bool aktiflik { get; set; }
        public DateTime kayit_tarihi { get; set; }
        public DateTime ayrilma_tarihi { get; set; }
        public bool gorev_durumu { get; set; }
}
}
