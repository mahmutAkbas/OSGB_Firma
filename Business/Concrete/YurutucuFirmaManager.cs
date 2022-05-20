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

        public IResult Add(YurutucuFirma entity)
        {
            var result = _yurutucuFirmaDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult( ResponseMessages.YurutucuFirmaAddBasarili);
            }
            return new ErrorResult( ResponseMessages.YurutucuFirmaAddBasarisiz);
        }

        public IResult Delete(YurutucuFirma entity)
        {
            var result = _yurutucuFirmaDal.Delete(entity.Id);
            if ( result > 0)
            {
                return new SuccessResult( ResponseMessages.YurutucuFirmaDeleteBasarili);
            }
            return new ErrorResult( ResponseMessages.YurutucuFirmaDeleteBasarisiz);
        }

        public IDataResult<List<YurutucuFirma>> GetAll()
        {
            var result = _yurutucuFirmaDal.GetAll();
            if ( result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<YurutucuFirma>>(result);
            }
            return new ErrorDataResult<List<YurutucuFirma>>(result);
        }

        public IDataResult<List<YurutucuFirma>> GetAllFilter(string adi)
        {
            var result = _yurutucuFirmaDal.GetAllFilter(adi);
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<YurutucuFirma>>(result);
            }
            return new ErrorDataResult<List<YurutucuFirma>>(result);
        }

        public IDataResult<YurutucuFirma> GetById(int id)
        {
            var result = _yurutucuFirmaDal.GetById(id);
            if ( result != null)
            {
                return new SuccessDataResult<YurutucuFirma>(result);
            }
            return new ErrorDataResult<YurutucuFirma>(result);
        }

        public IResult Update(YurutucuFirma entity)
        {
            var result = _yurutucuFirmaDal.Update(entity);
            if ( result > 0)
            {
                return new SuccessResult( ResponseMessages.YurutucuFirmaUpdateBasarili);
            }
            return new ErrorResult( ResponseMessages.YurutucuFirmaUpdateBasarisiz);
        }
    }
}
