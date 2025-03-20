using NINValidatorAPI.Models;

namespace NINValidatorAPI.Repositories
{
    public interface INinInfoRepository
    {
        void Add(NinInfo info);
        NinInfo? GetByNin(string nin);
        List<NinInfo> GetAll();
    }
}

