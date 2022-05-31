using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data.Repositories
{
   

    public class User : IUser
    {
        MovieDBContext _movieDBContext;

        public User(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public string Delete(int userId)
        {
            string message = "";
            var foundUser = _movieDBContext.userModels.Find(userId);
            if (foundUser != null)
            {
                _movieDBContext.userModels.Remove(foundUser);
                _movieDBContext.SaveChanges();
                message = "User Deleted Successfully..!!";
                return message;
            }
            else
            {
                message = "User Not Found..!!";
                return message;
            }
        }

        public object Login(UserModel userModel)
        {
            UserModel validateduser = null;
            var foundUser = _movieDBContext.userModels.Where(u => u.Email.Equals(userModel.Email) && u.Password.Equals(userModel.Password)).ToList();
            if (foundUser.Count() > 0)
            {
                return foundUser[0];
            }
            else
            {
                return "User not Found..!!";
            }
        }

        public string Register(UserModel userModel)
        {
            string msg = "";
            _movieDBContext.userModels.Add(userModel);
            _movieDBContext.SaveChanges();
            msg = "Inserted";
            return msg;
        }

        public object SelectUsers()
        {
            //select * from userModel
            List<UserModel> userList = _movieDBContext.userModels.ToList();
            return userList;
        }

        public string Update(UserModel userModel)
        {
            _movieDBContext.Entry(userModel).State = EntityState.Modified;
            _movieDBContext.SaveChanges();
            return "Data Upddated";
        }

        public object findUserById(int id)
        {
            var foundUser = _movieDBContext.userModels.Find(id);
            if (foundUser != null)
            {
                return foundUser;
            }
            else
            {
                return "User not Found..!!";
            }
        }
    }
}
