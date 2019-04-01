using System;
using System.Linq;
using LMCStore.Controllers;

namespace LMCStore.Models
{
    internal class IDataAreas : IMockAreas
    {
        //db connection
        private DbModel db = new DbModel();

        public IQueryable<Area> Areas { get { return db.Areas; } }

        public void Delete(Area area)
        {
            db.Areas.Remove(area);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Area Save(Area area)
        {
            if (area.Area_id == 0)
            {
                db.Areas.Add(area);
            }
            else
            {
                db.Entry(area).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return area;
        }
    }
}