using MovieApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Service
{
    public class BookingService
    {
        IBooking _iBooking;

        public BookingService(IBooking iBooking)
        {
            _iBooking = iBooking;
        }

    }
}
