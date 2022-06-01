using Bogus;
using Business;
using Entities.Concrete.Data;
using NUnit.Framework;
using System.Linq;

namespace OSGB_Test
{
    public class Tests
    {
        DataFaktory faktory = new DataFaktory();
        [Test]
        public void TestAdd()
        {
           
            var resultAdd = faktory.Unvans.Add(new Unvan() {UnvanAdi="Ýþ Güvenlik Uzmaný" });
             resultAdd = faktory.Unvans.Add(new Unvan() { UnvanAdi = "Hekim" });
             resultAdd = faktory.Unvans.Add(new Unvan() { UnvanAdi = "Müdür" });
             resultAdd = faktory.Unvans.Add(new Unvan() { UnvanAdi = "Sekreter" });
            Assert.True(resultAdd.Success);
        }



        
        public void TestUpdate()
        {
            var resultUnvan = faktory.Unvans.GetAllFilter("Sekreter").Data.FirstOrDefault();
            var resultUpdate = faktory.Unvans.Update(new Unvan()
            {
                Id = resultUnvan.Id,
                UnvanAdi = resultUnvan.UnvanAdi
            });
            Assert.True(resultUpdate.Success);

        }


    }
}