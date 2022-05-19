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
    public class YurutucuFirmaManager : IYurutucuFirmaService
    {
        IYurutucuFirmaDal _yurutucuFirmaDal;
        public YurutucuFirmaManager(IYurutucuFirmaDal yurutucuFirmaDal)
        {
            _yurutucuFirmaDal = yurutucuFirmaDal;
        }

        public async Task<IDataResult<int>> Add(YurutucuFirma entity)
        {
            var result =await _yurutucuFirmaDal.AddAsync(entity);
            if (result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.YurutucuFirmaAddBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.YurutucuFirmaAddBasarisiz);
        }

        public async Task<IDataResult<int>> Delete(YurutucuFirma entity)
        {
            var result =await _yurutucuFirmaDal.DeleteAsync(entity.Id);
            if ( result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.YurutucuFirmaDeleteBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.YurutucuFirmaDeleteBasarisiz);
        }

        public async Task<IDataResult<List<YurutucuFirma>>> GetAll()
        {
            var result =await _yurutucuFirmaDal.GetAllAsync();
            if ( result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<YurutucuFirma>>(result);
            }
            return new ErrorDataResult<List<YurutucuFirma>>(result);
        }

        public async Task<IDataResult<YurutucuFirma>> GetById(int id)
        {
            var result =await _yurutucuFirmaDal.GetByIdAsync(id);
            if ( result != null)
            {
                return new SuccessDataResult<YurutucuFirma>(result);
            }
            return new ErrorDataResult<YurutucuFirma>(result);
        }

        public async Task<IDataResult<int>> Update(YurutucuFirma entity)
        {
            var result =await _yurutucuFirmaDal.UpdateAsync(entity);
            if ( result > 0)
            {
                return new SuccessDataResult<int>(result, ResponseMessages.YurutucuFirmaUpdateBasarili);
            }
            return new ErrorDataResult<int>(result, ResponseMessages.YurutucuFirmaUpdateBasarisiz);
        }
    }
}
