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
    public class EtkinlikGorevlileriManager : IEtkinlikGorevlileriService
    {
        IEtkinlikGorevlileriDal _etkinlikGorevlileriDal;
        public EtkinlikGorevlileriManager(IEtkinlikGorevlileriDal etkinlikGorevlileriDal)
        {
            _etkinlikGorevlileriDal = etkinlikGorevlileriDal;
        }
        public IResult Add(EtkinlikGorevlileri entity)
        {
            var result =  _etkinlikGorevlileriDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.EtkinlikGorevlileriAddBasarili);
            }
            return new ErrorResult( ResponseMessages.EtkinlikGorevlileriAddBasarisiz);
        }

        public IResult Delete(EtkinlikGorevlileri entity)
        {
            var result =  _etkinlikGorevlileriDal.Delete(entity.Id);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.EtkinlikGorevlileriAddBasarili);
            }
            return new ErrorResult( ResponseMessages.EtkinlikGorevlileriAddBasarisiz);
        }

        public IDataResult<List<EtkinlikGorevlileri>> GetAll()
        {
            var result =  _etkinlikGorevlileriDal.GetAll();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikGorevlileri>>(result);
            }
            return new ErrorDataResult<List<EtkinlikGorevlileri>>(result);
        }

        public IDataResult<List<EtkinlikGorevlileri>> GetAllFilter(EtkinlikGorevlileri entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<EtkinlikGorevlileri> GetById(int id)
        {
            var result =  _etkinlikGorevlileriDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<EtkinlikGorevlileri>(result);
            }
            return new ErrorDataResult<EtkinlikGorevlileri>(result);
        }

        public IResult Update(EtkinlikGorevlileri entity)
        {
            var result =  _etkinlikGorevlileriDal.Update(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.EtkinlikGorevlileriUpdateBasarili);
            }
            return new ErrorResult( ResponseMessages.EtkinlikGorevlileriUpdateBasarisiz);
        }
    }
}
