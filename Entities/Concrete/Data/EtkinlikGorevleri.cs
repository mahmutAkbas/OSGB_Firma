﻿
using System;

namespace Entities.Concrete.Data
{
    public class EtkinlikGorevleri : BaseEntity
    {
        public int EtkinlikId { get; set; }
        public int IslemId { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}
