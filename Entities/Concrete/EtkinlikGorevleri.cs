using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    internal class EtkinlikGorevleri
    {
        public int ID { get; set; }
        public int etkinlikId { get; set; }
        public int islemId { get; set; }
        public string aciklama { get; set; }
        public DateTime tarih { get; set; }

    }
}
