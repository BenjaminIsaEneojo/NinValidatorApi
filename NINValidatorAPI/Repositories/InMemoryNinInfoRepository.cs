using NINValidatorAPI.Models;

namespace NINValidatorAPI.Repositories
{
    public class InMemoryNinInfoRepository : INinInfoRepository
    {
        private readonly List<NinInfo> _store = new();

        public void Add(NinInfo info) => _store.Add(info);

        public NinInfo? GetByNin(string nin) => _store.FirstOrDefault(x => x.NIN == nin);

        public List<NinInfo> GetAll() => _store;
    }
}
