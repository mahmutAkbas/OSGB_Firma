using Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSGB_Test
{
    public class EtkinlikGorevleri
    {
        DataFaktory faktory = new DataFaktory();
      
        public void TestAdd()
        {
            var resultAdd = faktory.Unvans.Add(new Entities.Concrete.Data.Unvan()
            {
                UnvanAdi = "Is Uzamanı"
            });
            Assert.IsFalse(resultAdd.Success);
        }
     
        public void TestGetById()
        {
            var resultAdd = faktory.Unvans.Add(new Entities.Concrete.Data.Unvan()
            {
                UnvanAdi = "Is Uzamanı"
            });
            Assert.IsFalse(resultAdd.Success);
        }
     
        public void TestGetAll()
        {
            var resultAdd = faktory.Unvans.Add(new Entities.Concrete.Data.Unvan()
            {
                UnvanAdi = "Is Uzamanı"
            });
            Assert.IsFalse(resultAdd.Success);
        }

      
        public void TestUpdate()
        {
            var resultUpdate = faktory.Unvans.Update(new Entities.Concrete.Data.Unvan()
            {
                Id = 3,
                UnvanAdi = "Is Uzamanı111331"
            });
            Assert.IsTrue(resultUpdate.Success);
        }
      
        public void TestDelete()
        {
            var resultDelete = faktory.Unvans.Delete(new Entities.Concrete.Data.Unvan()
            {
                Id = 4,
                UnvanAdi = "Is Uzamanı"
            });
            Assert.IsTrue(resultDelete.Success);
        }
    }
}
