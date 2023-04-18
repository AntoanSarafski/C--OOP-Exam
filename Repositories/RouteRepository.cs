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

        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public IRoute FindById(string identifier)
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

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return routes.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            int indentifierAsInt = int.Parse(identifier);
            IRoute routeForRemoving = routes.FirstOrDefault(u => u.RouteId == indentifierAsInt);

            if (routeForRemoving == null)
            {
                return false;
            }
            else
            {
                routes.Remove(routeForRemoving);
                return true;
            }
        }


        private readonly List<IRoute> routes;

        public RouteRepository()
        {
            routes = new List<IRoute>();
        }
    }
}
