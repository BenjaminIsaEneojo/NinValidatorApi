using NINValidatorAPI.ApiModels.Requests;
using NINValidatorAPI.ApiModels.Responses;

namespace NINValidatorAPI.Services
{
    public interface INinInfoService
    {
        NinInfoResponse CreateNinInfo(CreateNinInfoRequest request);
        NinInfoResponse GetByNin(string nin);
        List<NinInfoSummaryResponse> GetAll();
        bool DeleteByNin(string nin);
    }
}
