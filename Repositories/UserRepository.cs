using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private readonly List<IUser> users;

        public void AddModel(IUser model)
        {
            users.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            IUser userForRemoving = users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

            if (userForRemoving == null)
            {
                return false;
            }
            else
            {
                users.Remove(userForRemoving);
                return true;
            }
        }

        public IUser FindById(string identifier)
        {
            if(users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier) != null)
            {
                return users.First(u => u.DrivingLicenseNumber == identifier);
            }
            else
            {
                return null;
            }
        }

        public IReadOnlyCollection<IUser> GetAll() => users.AsReadOnly();

    }
}
