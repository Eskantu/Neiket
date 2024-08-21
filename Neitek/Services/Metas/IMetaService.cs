

using Neitek.services.Metas;

namespace Neitek.Services.Metas
{
    public interface IMetaService
    {
        bool CreateMeta(Meta meta);
        bool DeleteMeta(int idMeta);
        Task<List<MetasView>> GetMetas();
        bool UpdateMeta(Meta metaUpdate);
    }
}