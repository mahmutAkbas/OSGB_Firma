using Business;
using NUnit.Framework;

namespace OSGB_Test
{
    public class Tests
    {
        DataFaktory faktory = new DataFaktory();


        [Test]
        public void TestAdd()
        {
            var resultAdd = faktory.RandevuFirmas.Add(new Entities.Concrete.Data.Randevu()
            {
              RandevuTarihi=System.DateTime.Now,
              Aciklama="Yürütücü firma",
              YurutucuFirmaId=1
            });
            Assert.True(resultAdd.Success);
        }
       

 
        [Test]
        public void TestUpdate()
        {
            var resultUpdate = faktory.RandevuFirmas.Update(new Entities.Concrete.Data.Randevu()
            {
                Id = 3,
                RandevuTarihi = System.DateTime.Now,
                Aciklama = "Yürütücü firma",
                YurutucuFirmaId=1,
                Onay=true
            });
            Assert.True(resultUpdate.Success);

        }


    }
}