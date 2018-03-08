﻿using CST356_Week_5_Lab.Data;
using CST356_Week_5_Lab.Data.Entities;
using CST356_Week_5_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST356_Week_5_Lab.Repositories
{
    public class AppRepository : IAppRepository
    {
        private readonly MyDbContext _dbContext;

        public AppRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationUser GetUser(string id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _dbContext.Users;
        }

        public void CreateUser(ApplicationUser user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(ApplicationUser user)
        {
            _dbContext.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            ApplicationUser user = _dbContext.Users.Find(id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public Pet GetPet(int id)
        {
            return _dbContext.Pets.Find(id);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _dbContext.Pets;
        }

        public void CreatePet(Pet pet)
        {
            _dbContext.Pets.Add(pet);
            _dbContext.SaveChanges();
        }

        public void UpdatePet(Pet pet)
        {
            _dbContext.SaveChanges();
        }

        public void DeletePet(int id)
        {
            Pet pet = _dbContext.Pets.Find(id);

            if (pet != null)
            {
                _dbContext.Pets.Remove(pet);
                _dbContext.SaveChanges();
            }
        }
    }
}