using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Dapper;
using FluentValidation;
using System.Globalization;

namespace Business
{
    public class DataFaktory
    {
        public DataFaktory()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");
            Unvans = new UnvanManager(new UnvanDal());
            Personels = new PersonelManager(new PersonelDal());
            YurutucuFirmas = new YurutucuFirmaManager(new YurutucuFirmaDal());
            RandevuFirmas = new RandevuManager(new RandevuDal());
            Islemlers = new IslemlerManager(new IslemlerDal());
            EtkinlikZiyarets = new EtkinlikZiyaretManager(new EtkinlikZiyaretDal());
            EtkinlikGorevlileri = new EtkinlikGorevlileriManager(new EtkinlikGorevliileriDal());
            EtkinlikGorevleri = new EtkinlikGorevleriManager(new EtkinlikGorevleriDal());
        }

        public IUnvanService Unvans { get; set; }
        public IPersonelService Personels { get; set; }
        public IYurutucuFirmaService YurutucuFirmas { get; set; }
        public IRandevuService RandevuFirmas { get; set; }
        public IIslemlerService Islemlers { get; set; }
        public IEtkinlikZiyaretService EtkinlikZiyarets { get; set; }
        public IEtkinlikGorevlileriService EtkinlikGorevlileri { get; set; }
        public IEtkinlikGorevleriService EtkinlikGorevleri { get; set; }

    }
}
