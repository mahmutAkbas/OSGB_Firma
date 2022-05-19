using Business;
using NUnit.Framework;

namespace OSGB_Test
{
    public class Tests
    {
        DataFaktory faktory = new DataFaktory();
   

      
        public void TestAdd()
        {
            /*  var resultAdd = faktory.Unvans.Add(new Entities.Concrete.Data.Unvan()
              {
                  UnvanAdi = "Is Uzaman�"
              });
              Assert.IsFalse(resultAdd.Success);*/
        }
        [Test]
        public void TestUpdate()
        {
            var resultUpdate = faktory.Unvans.Update(new Entities.Concrete.Data.Unvan()
            {
                Id = 25,
                UnvanAdi = "Is Uzaman�22"
            });
            Assert.IsTrue(resultUpdate.Success);
            var resultDelete = faktory.Unvans.Delete(new Entities.Concrete.Data.Unvan()
            {
                Id = 25,
                UnvanAdi = "Is Uzaman�"
            });
            Assert.IsTrue(resultDelete.Success);
        }


       
        public void TestDelete()
        {
          
        }

    }
}