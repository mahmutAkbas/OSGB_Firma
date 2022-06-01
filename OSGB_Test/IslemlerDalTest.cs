using Business;
using NUnit.Framework;

namespace OSGB_Test
{
    internal class IslemlerDalTest
    {
        DataFaktory faktory = new DataFaktory();

        [Test]
        public void TestAdd()
        {
            //, , ,  Raporu. 
            //, , Kişisel Koruyucu Donanımların Kendi Talimatlarına Göre Periyodik Denetimi,  Geçmiş Olmasının Sağlanması. 

            var result = faktory.Islemlers.Add(new Entities.Concrete.Data.Islemler()
            {
                Adi = "Çalışan Muayenesi",
                Tip = 0
            });
            result = faktory.Islemlers.Add(new Entities.Concrete.Data.Islemler()
            {
                Adi = "Aylık Sağlık Taraması",
                Tip = 0
            });
            result = faktory.Islemlers.Add(new Entities.Concrete.Data.Islemler()
            {
                Adi = "İşe Yeni Giriş Muayenesi",
                Tip = 0
            });
            Assert.True(result.Success);
        }
    }
}
