using Business.Abstract;
using Business.Constant;
using Business.Utilities.Result.Abstract;
using Business.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Data;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EtkinlikZiyaretManager : IEtkinlikZiyaretService
    {
        IEtkinlikZiyaretDal _etkinlikZiyaretDal;
        public EtkinlikZiyaretManager(IEtkinlikZiyaretDal etkinlikZiyaretDal)
        {
            _etkinlikZiyaretDal = etkinlikZiyaretDal;
        }
        public IResult Add(EtkinlikZiyaret entity)
        {
            var result = _etkinlikZiyaretDal.Add(entity);
            if (result > 0)
            {
                    return new SuccessResult(ResponseMessages.EtkinlikZiyaretiAddBasarili);
            }
            return new ErrorResult(ResponseMessages.EtkinlikZiyaretiAddBasarisiz);
        }

        public IDataResult<int> AddCustom(EtkinlikZiyaret entity)
        {
            var result = _etkinlikZiyaretDal.Add(entity);
            if (result > 0)
            {
                var resultId = _etkinlikZiyaretDal.GetByZiyaretId(entity.RandevuId);
                if (resultId > 0)
                    return new SuccessDataResult<int>(resultId, ResponseMessages.EtkinlikZiyaretiAddBasarili);
            }
            return new ErrorDataResult<int>(0,ResponseMessages.EtkinlikZiyaretiAddBasarisiz);
        }

        public IResult Delete(EtkinlikZiyaret entity)
        {
            var result = _etkinlikZiyaretDal.Add(entity);
            if (result > 0)
            {
                return new SuccessResult(ResponseMessages.EtkinlikZiyaretiDeleteBasarili);
            }
            return new ErrorResult(ResponseMessages.EtkinlikZiyaretiDeleteBasarisiz);
        }

        public IDataResult<List<EtkinlikZiyaret>> GetAll()
        {
            var result = _etkinlikZiyaretDal.GetAll();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikZiyaret>>(result);
            }
            return new ErrorDataResult<List<EtkinlikZiyaret>>(result);
        }


        public IDataResult<EtkinlikZiyaret> GetById(int id)
        {
            var result = _etkinlikZiyaretDal.GetById(id);
            if (result != null)
            {
                return new SuccessDataResult<EtkinlikZiyaret>(result);
            }
            return new ErrorDataResult<EtkinlikZiyaret>(result);
        }

        public IDataResult<List<EtkinlikZiyaretDto>> GetEtkinlikZiyaretByFirmaAdi(string firmaAdi)
        {
            var result = _etkinlikZiyaretDal.GetEtkinlikZiyaretByFirmaAdi(firmaAdi);
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikZiyaretDto>>(result);
            }
            return new ErrorDataResult<List<EtkinlikZiyaretDto>>(result);
        }

        public IDataResult<List<EtkinlikZiyaretDto>> GetEtkinlikZiyaretDto()
        {
            var result = _etkinlikZiyaretDal.GetEtkinlikZiyaretDto();
            if (result != null && result.Count > 0)
            {
                return new SuccessDataResult<List<EtkinlikZiyaretDto>>(result);
            }
            return new ErrorDataResult<List<EtkinlikZiyaretDto>>(result);
        }

        public IResult Update(EtkinlikZiyaret entity)
        {
            var result = _etkinlikZiyaretDal.Update(entity);
            if (result > 0)
            {
                return new SuccessResult(ResponseMessages.EtkinlikZiyaretiUpdateBasarili);
            }
            return new ErrorResult(ResponseMessages.EtkinlikZiyaretiUpdateBasarisiz);
        }
    }
}
