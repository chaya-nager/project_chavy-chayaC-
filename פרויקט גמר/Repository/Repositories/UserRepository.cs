﻿using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly IContext context;
        public UserRepository(IContext context)
        {
            this.context = context;
        }
        public User AddItem(User item)
        {
            this.context.Users.Add(item);
            this.context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this.context.Users.Remove(GetById(id));
            this.context.Save();
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(x => x.UserId == id);
        }

        public void UpdateItem(int id, User item)
        {
            var user = GetById(id);
            user.FullName = item.FullName;
            user.Email = item.Email;
            user.PasswordHash = item.PasswordHash;
            user.BirthDate = item.BirthDate;
            user.UserType = item.UserType;
            user.HealthConditions = item.HealthConditions;
            user.WorkoutVideos = item.WorkoutVideos;
            context.Save();
        }
    }
}
