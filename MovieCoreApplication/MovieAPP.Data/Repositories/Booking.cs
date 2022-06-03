using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public class Booking : IBooking
    {
        MovieDBContext _movieDbContext;
        public Booking(MovieDBContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public List<BookingModel> BookingList()
        {
            return _movieDbContext.bookingModels.ToList();
        }

        public string DeleteBooking(int bookingId)
        {
            string message = "";
            var foundUser = _movieDbContext.bookingModels.Find(bookingId);
            if (foundUser != null)
            {
                _movieDbContext.bookingModels.Remove(foundUser);
                _movieDbContext.SaveChanges();
                message = "Booking Deleted Successfully..!!";
                return message;
            }
            else
            {
                message = "Booking Not Found..!!";
                return message;
            }
        }

        public object findBookingById(int bookingId)
        {
            var foundUser = _movieDbContext.bookingModels.Find(bookingId);
            if (foundUser != null)
            {
                return foundUser;
            }
            else
            {
                return "Booking not Found..!!";
            }
        }

        public string InsertBooking(BookingModel bookingModel)
        {
            _movieDbContext.bookingModels.Add(bookingModel);
            _movieDbContext.SaveChanges();
            return "Inserted";
        }

        public string UpdateBooking(BookingModel bookingModel)
        {
            _movieDbContext.Entry(bookingModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            return "Data Upddated";
        }
    }
}
