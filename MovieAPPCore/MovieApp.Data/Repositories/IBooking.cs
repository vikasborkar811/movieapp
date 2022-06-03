using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface IBooking
    {
        string InsertBooking(BookingModel bookingModel);
        List<BookingModel> BookingList();

        public object findBookingById(int bookingId);


        string UpdateBooking(BookingModel bookingModel);

        string DeleteBooking(int bookingId);
    }
}
