using NINValidatorAPI.ApiModels.Requests;
using NINValidatorAPI.ApiModels.Responses;
using NINValidatorAPI.Models;
using NINValidatorAPI.Repositories;
using System.Runtime;

namespace NINValidatorAPI.Services
{
    public class NinInfoService : INinInfoService
    {
        private readonly INinInfoRepository _repo;
        private readonly List<NinInfo> _ninInfoList = new();

        public NinInfoService(INinInfoRepository repo)
        {
            _repo = repo;
        }

        public NinInfoResponse CreateNinInfo(CreateNinInfoRequest request)
        {
            var ninInfo = new NinInfo
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                NIN = request.NIN,
                VerificationDate = request.VerificationDate,
                VerificationStatus = request.VerificationStatus,
                CommonReference = "request.CommonReference",
                CreatedBy = "System"
            };

            _repo.Add(ninInfo);

            return new NinInfoResponse
            {
                Id = ninInfo.Id,
                FirstName = ninInfo.FirstName,
                MiddleName = ninInfo.MiddleName,
                LastName = ninInfo.LastName,
                DateOfBirth = ninInfo.DateOfBirth,
                NIN = ninInfo.NIN,
                VerificationDate = ninInfo.VerificationDate,
                VerificationStatus = ninInfo.VerificationStatus,
                CommonReference = "ninInfo.CommonReference"
            };
        }

        public NinInfoResponse GetByNin(string nin)
        {
            var ninInfo = _ninInfoList.FirstOrDefault(x => x.NIN.Trim().Equals(nin.Trim(), StringComparison.OrdinalIgnoreCase));
            if (ninInfo == null)
                return null;

            return new NinInfoResponse
            {
                Id = ninInfo.Id,
                FirstName = ninInfo.FirstName,
                MiddleName = ninInfo.MiddleName,
                LastName = ninInfo.LastName,
                DateOfBirth = ninInfo.DateOfBirth,
                NIN = ninInfo.NIN,
                VerificationDate = ninInfo.VerificationDate,
                VerificationStatus = ninInfo.VerificationStatus,
                CommonReference = ninInfo.CommonReference
            };
        }
        public bool DeleteByNin(string nin)
        {
            var ninInfo = _ninInfoList.FirstOrDefault(x => x.NIN == nin);
            if (ninInfo == null)
                return false;

            _ninInfoList.Remove(ninInfo);
            return true;
        }

        public List<NinInfoSummaryResponse> GetAll()
        {
            return _repo.GetAll().Select(info => new NinInfoSummaryResponse
            {
                Id = info.Id,
                FullName = $"{info.FirstName} {info.LastName}",
                NIN = info.NIN,
                Status = info.VerificationStatus.ToString()
            }).ToList();
        }
    }
}
