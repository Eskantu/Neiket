

namespace Neitek.Services.Tareas
{
    public class TareaService : ITareaService
    {
        private readonly IConfiguration _configuration;
        private readonly string urlService;
        public TareaService(IConfiguration configuration)
        {
            _configuration = configuration;
            urlService = _configuration.GetSection("Services")["Tareas"] ?? throw new Exception("No se ha configurado la URL del servicio de metas");
        }

        public bool CreateTarea(Tarea tarea)
        {
            tarea.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            tarea.Completada = false;
            tarea.Importante = false; 
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlService);
                var response = client.PostAsJsonAsync("api/Tareas", tarea).Result;
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

        public bool UpdateTarea(Tarea tareaUpdate)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlService);
                    var response = client.PutAsJsonAsync($"api/Tareas/{tareaUpdate.PkTarea}", tareaUpdate).Result;
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
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeleteTarea(int idTarea)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlService);
                var response = client.DeleteAsync($"api/Tareas/{idTarea}").Result;
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

        public List<Tarea> GetTareas()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlService);
                var response = client.GetAsync("api/Tareas").Result;
                if (response.IsSuccessStatusCode)
                {
                    var tareas = System.Text.Json.JsonSerializer.Deserialize<List<Tarea>>(response.Content.ReadAsStringAsync().Result);
                    return tareas;
                }
                else
                {
                    return [];
                }
            }
        }

        public List<TareaViewModel> GetTareasByFkMeta(int fkMeta)
        {
            List<TareaViewModel> tareasViewModel = new List<TareaViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlService);
                var response = client.GetAsync($"api/Tareas/GetTareaByFkMeta?fkMeta={fkMeta}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var tareas = System.Text.Json.JsonSerializer.Deserialize<List<Tarea>>(response.Content.ReadAsStringAsync().Result);
                    foreach (var item in tareas)
                    {
                        tareasViewModel.Add(new TareaViewModel
                        {
                            FkMeta = item.FkMeta,
                            FechaCreacion = item.FechaCreacion,
                            Importante = item.Importante,
                            NombreTarea = item.NombreTarea,
                            PkTarea = item.PkTarea,
                            Completada = item.Completada,
                            Selected = false
                            
                        });
                    }
                    return tareasViewModel;
                }
                else
                {
                    return [];
                }
            }
        }
    }
}
