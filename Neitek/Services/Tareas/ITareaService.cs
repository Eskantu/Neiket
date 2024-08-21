
namespace Neitek.Services.Tareas
{
    public interface ITareaService
    {
        bool CreateTarea(Tarea tarea);
        bool DeleteTarea(int idTarea);
        List<Tarea> GetTareas();
        bool UpdateTarea(Tarea tareaUpdate);
        List<TareaViewModel> GetTareasByFkMeta(int fkMeta);
    }
}