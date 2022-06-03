using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;

namespace MovieApp.Data.Repositories
{
    public interface IUser
    {
        string Register(UserModel userModel);
        object Login(UserModel userModel);
        string Update(UserModel userModel);
        string Delete(int userId);
        object SelectUsers();

        public object findUserById(int id);
    }
}
