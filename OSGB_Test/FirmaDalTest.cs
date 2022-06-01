using Bogus;
using Business;
using Entities.Concrete.Data;
using NUnit.Framework;

namespace OSGB_Test
{
    internal class FirmaDalTest
    {
        DataFaktory faktory = new DataFaktory();

        [Test]
        public void TestAdd()
        {
            var fData = new Faker<YurutucuFirma>("tr")
                .RuleFor(u => u.Adi, f => f.Company.CompanyName());
            var result = faktory.YurutucuFirmas.Add(new YurutucuFirma()
            {
                Adi = fData.Generate().Adi,
                KayitTarihi = System.DateTime.Now
            });
            result = faktory.YurutucuFirmas.Add(new YurutucuFirma()
            {
                Adi = fData.Generate().Adi,
                KayitTarihi = System.DateTime.Now
            });
            result = faktory.YurutucuFirmas.Add(new YurutucuFirma()
            {
                Adi = fData.Generate().Adi,
                KayitTarihi = System.DateTime.Now
            });
            Assert.True(result.Success);
        }
        [Test]
        public void TestGetAllFirma()
        {
            var result = faktory.YurutucuFirmas.GetAll();
            Assert.True(result.Data.Count == 3);
        }
    }
}
