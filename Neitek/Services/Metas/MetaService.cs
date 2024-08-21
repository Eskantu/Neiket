

using Neitek.services.Metas;

namespace Neitek.Services.Metas
{
    public class MetaService : IMetaService
    {
        private readonly IConfiguration _configuration;
        private readonly string urlService;
        public MetaService(IConfiguration configuration)
        {
            _configuration = configuration;
            urlService = _configuration.GetSection("Services")["Metas"] ?? throw new Exception("No se ha configurado la URL del servicio de metas");
            ;
        }
        public bool CreateMeta(Meta meta)
        {
            meta.FechaCreacion=new DateOnly(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlService);
                var response = client.PostAsJsonAsync("api/Metas", meta).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateMeta(services.Metas.Meta metaUpdate)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlService);
                var response = client.PutAsJsonAsync($"api/Metas/{metaUpdate.PkMeta}", metaUpdate).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteMeta(int idMeta)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlService);
                var response = client.DeleteAsync($"api/Metas/{idMeta}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<List<services.Metas.Meta>> GetMetas()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlService);
                var response = client.GetAsync("api/Metas").Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var metas = System.Text.Json.JsonSerializer.Deserialize<List<Meta>>(result, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = false,  });
                    return metas;
                }
                else
                {
                    return [];
                }
            }
        }
    }
}
