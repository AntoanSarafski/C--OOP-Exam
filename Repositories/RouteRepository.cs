using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private readonly List<IRoute> routes;

        public RouteRepository()
        {
            routes = new List<IRoute>();
        }
        public void AddModel(IRoute route)
        {
            routes.Add(route);
        }

        public bool RemoveById(string identifier)
        {
            int indentifierAsInt = int.Parse(identifier);

            IRoute routeForRemoving = routes.FirstOrDefault(r => r.RouteId == indentifierAsInt);
            if (routeForRemoving == null) return false;
            else
            {
                routes.Remove(routeForRemoving);
                return true;
            }
        }

        IRoute IRepository<IRoute>.FindById(string identifier)
        {
            int indentifierAsInt = int.Parse(identifier);
            IRoute routeForFindingById = routes.FirstOrDefault(r => r.RouteId == indentifierAsInt);
            if (routeForFindingById == null)
            {
                return null;
            }
            else
            {
                return routes.First(r => r.RouteId == indentifierAsInt);
            }
        }

        IReadOnlyCollection<IRoute> IRepository<IRoute>.GetAll() => routes.AsReadOnly();
    }
}
