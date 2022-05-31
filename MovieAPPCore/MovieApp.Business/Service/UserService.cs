using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Service
{
    public class UserService
    {
        IUser _iuser;
        public UserService(IUser user)
        {
            _iuser = user;
        }

        public string Register(UserModel userModel)
        {
            return _iuser.Register(userModel);
        }

        public object SelctUser()
        {
            return _iuser.SelectUsers();
        }

        public string deleteUser(int id)
        {
            return _iuser.Delete(id);
        }

        public string UpdateUser(UserModel userModel)
        {
            return _iuser.Update(userModel);
        }

        public object Login(UserModel userModel)
        {
            return _iuser.Login(userModel);
        }

        public object findUserById(int id)
        {
            return _iuser.findUserById(id);
        }
    }
}
