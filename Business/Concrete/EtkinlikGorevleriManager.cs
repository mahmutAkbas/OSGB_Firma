using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EtkinlikGorevleriManager : IEtkinlikGorevleriService
    {
        IEtkinlikGorevleriDal _etkinlikGorevleriDal;
        public EtkinlikGorevleriManager(IEtkinlikGorevleriDal etkinlikGorevleriDal)
        {
            _etkinlikGorevleriDal = etkinlikGorevleriDal;
        }

        public IResult Add(EtkinlikGorevleri entity)
        {
            var result =  _etkinlikGorevleriDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.EtkinlikGoreviAddBasarili);
            }
            return new ErrorResult( ResponseMessages.EtkinlikGoreviAddBasarisiz);
        }

        public IResult Delete(EtkinlikGorevleri entity)
        {
            var result =  _etkinlikGorevleriDal.Delete(entity.Id);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.EtkinlikGoreviDeleteBasarili);
            }
            return new ErrorResult( ResponseMessages.EtkinlikGoreviDeleteBasarisiz);
        }

        public IDataResult<List<EtkinlikGorevleri>> GetAll()
        {
            var result =  _etkinlikGorevleriDal.GetAll();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikGorevleri>>(result);
            }
            return new ErrorDataResult<List<EtkinlikGorevleri>>(result);
        }

        public IDataResult<List<EtkinlikGorevleri>> GetAllFilter(EtkinlikGorevleri entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<EtkinlikGorevleri> GetById(int id)
        {
            var result = _etkinlikGorevleriDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<EtkinlikGorevleri>(result);
            }
            return new ErrorDataResult<EtkinlikGorevleri>(result);
        }

        public IResult Update(EtkinlikGorevleri entity)
        {
            var result =  _etkinlikGorevleriDal.Update(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.EtkinlikGoreviUpdateBasarili);
            }
            return new ErrorResult( ResponseMessages.EtkinlikGoreviUpdateBasarisiz);

        }
    }
}
