
namespace Entities.Concrete.Data
{
    public class EtkinlikGorevlileri:BaseEntity
    {
        public int PersonelId { get; set; }
        public string Yetki { get; set; }
        public int EtkinlikZiyaretId { get; set; }
    }
}
