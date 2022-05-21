using Entities.Concrete.Data;
using System;

namespace Entities.DTOs
{
    public class RandevuDto : BaseEntity
    {
        public string Aciklama { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public bool Onay { get; set; }
        public string Adi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int YurutucuFirmaId { get; set; }
    }
}
