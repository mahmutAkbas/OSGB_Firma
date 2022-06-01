using Bogus;
using Business;
using Entities.Concrete.Data;
using NUnit.Framework;
using System.Linq;

namespace OSGB_Test
{
    public class PersonelDalTest
    {

        DataFaktory faktory = new DataFaktory();

        [Test]
        public void TestAdd()
        {

            var fData = new Faker<Personel>("tr")
                .RuleFor(u => u.Adi, f => f.Name.FirstName())
                .RuleFor(u => u.Soyadi, f => f.Name.LastName())
                .RuleFor(u => u.Telefon, f => f.Phone.PhoneNumber("###########"))
                .RuleFor(u => u.UnvanId, f => f.Random.Int(1, 4));

            var resultAdd = faktory.Personels.Add(new Personel()
            {
                Adi=fData.Generate().Adi,
                Soyadi=fData.Generate().Soyadi,
                Telefon=fData.Generate().Telefon,
                KayitTarihi=System.DateTime.Now,
                SilinmeDurumu=false,
                UnvanId=fData.Generate().UnvanId

            });
             resultAdd = faktory.Personels.Add(new Personel()
            {
                Adi = fData.Generate().Adi,
                Soyadi = fData.Generate().Soyadi,
                Telefon = fData.Generate().Telefon,
                KayitTarihi = System.DateTime.Now,
                SilinmeDurumu = false,
                UnvanId = fData.Generate().UnvanId

            });
            resultAdd = faktory.Personels.Add(new Personel()
            {
                Adi = fData.Generate().Adi,
                Soyadi = fData.Generate().Soyadi,
                Telefon = fData.Generate().Telefon,
                KayitTarihi = System.DateTime.Now,
                SilinmeDurumu = false,
                UnvanId = fData.Generate().UnvanId

            });
            resultAdd = faktory.Personels.Add(new Personel()
            {
                Adi = fData.Generate().Adi,
                Soyadi = fData.Generate().Soyadi,
                Telefon = fData.Generate().Telefon,
                KayitTarihi = System.DateTime.Now,
                SilinmeDurumu = false,
                UnvanId = fData.Generate().UnvanId

            });
            Assert.True(resultAdd.Success);
        }
        [Test]
        public void TestUpdate()
        {
            var resultPersonel = faktory.Personels.GetById(3).Data;
            resultPersonel.Adi = "Halit";
            var resultUpdate = faktory.Personels.Update(resultPersonel);
            Assert.True(resultUpdate.Success);
        }

        [Test]
        public void TestSelect()
        {
            var result = faktory.Personels.GetAll();
            Assert.That(result.Success);
        }


    }
}