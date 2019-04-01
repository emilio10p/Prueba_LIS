using LMCStore.Models;
using System.Linq;

namespace LMCStore.Models
{
    public interface IMockAreas
    {
        IQueryable<Area> Areas { get; }
        Area Save(Area area);
        void Delete(Area area);
        void Dispose();
    }
}