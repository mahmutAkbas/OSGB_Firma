using Entities.Concrete.Data;

namespace Entities.DTOs
{
    public class EtkinlikGorevliDto : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Yetki { get; set; }
    }
}
