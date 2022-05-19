using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class YurutucuFirmaManager : IYurutucuFirmaService
    {
        IYurutucuFirmaDal _yurutucuFirmaDal;
        public YurutucuFirmaManager(IYurutucuFirmaDal yurutucuFirmaDal)
        {
            _yurutucuFirmaDal = yurutucuFirmaDal;
        }
        public IDataResult<int> Add(YurutucuFirma entity)
        {
            var result = _yurutucuFirmaDal.AddAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.YurutucuFirmaAddBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.YurutucuFirmaAddBasarisiz);
        }

        public IDataResult<int> Delete(YurutucuFirma entity)
        {
            var result = _yurutucuFirmaDal.DeleteAsync(entity.Id);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.YurutucuFirmaDeleteBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.YurutucuFirmaDeleteBasarisiz);
        }

        public IDataResult<List<YurutucuFirma>> GetAll()
        {
            var result = _yurutucuFirmaDal.GetAllAsync();
            if (result.IsCompleted && result.Result != null && result.Result.Count > 0)
            {
                return new SuccessDataResult<List<YurutucuFirma>>(result.Result);
            }
            return new ErrorDataResult<List<YurutucuFirma>>(result.Result);
        }

        public IDataResult<YurutucuFirma> GetById(int id)
        {
            var result = _yurutucuFirmaDal.GetByIdAsync(id);
            if (result.IsCompleted && result.Result != null)
            {
                return new SuccessDataResult<YurutucuFirma>(result.Result);
            }
            return new ErrorDataResult<YurutucuFirma>(result.Result);
        }

        public IDataResult<int> Update(YurutucuFirma entity)
        {
            var result = _yurutucuFirmaDal.UpdateAsync(entity);
            if (result.IsCompleted && result.Result > 0)
            {
                return new SuccessDataResult<int>(result.Result, ResponseMessages.YurutucuFirmaUpdateBasarili);
            }
            return new ErrorDataResult<int>(result.Result, ResponseMessages.YurutucuFirmaUpdateBasarisiz);
        }
    }
}
