using CST356_Week_5_Lab.Data.Entities;
using CST356_Week_5_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST356_Week_5_Lab.Repositories
{
    public interface IAppRepository
    {
        ApplicationUser GetUser(string id);

        IEnumerable<ApplicationUser> GetAllUsers();

        void CreateUser(ApplicationUser user);

        void UpdateUser(ApplicationUser user);

        void DeleteUser(string id);

        Pet GetPet(int id);

        IEnumerable<Pet> GetAllPets();

        void CreatePet(Pet pet);

        void UpdatePet(Pet pet);

        void DeletePet(int id);
    }
}
