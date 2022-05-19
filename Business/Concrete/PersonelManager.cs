using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;
        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }
        public IDataResult<int> Add(Personel entity)
        {
            var result = _personelDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.PersonelAddBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.PersonelAddBasarisiz);
        }

        public IDataResult<int> Delete(Personel entity)
        {
            var result = _personelDal.DeleteAsync(entity.Id);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.PersonelDeleteBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.PersonelDeleteBasarisiz);
        }

        public IDataResult<List<Personel>> GetAll()
        {
            var result = _personelDal.GetAllAsync();
            if (result.IsCompleted && result.Result != null && result.Result.Count > 0)
            {
                return new SuccessDataResult<List<Personel>>(result.Result);
            }
            return new ErrorDataResult<List<Personel>>(result.Result);
        }

        public IDataResult<Personel> GetById(int id)
        {
            var result = _personelDal.GetByIdAsync(id);
            if (result.IsCompleted && result.Result != null)
            {
                return new SuccessDataResult<Personel>(result.Result);
            }
            return new ErrorDataResult<Personel>(result.Result);
        }

        public IDataResult<int> Update(Personel entity)
        {
            var result = _personelDal.UpdateAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.PersonelUpdateBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.PersonelUpdateBasarisiz);
        }
    }
}
