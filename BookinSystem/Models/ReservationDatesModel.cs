using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookinSystem.Models
{
    public class ReservationDatesModel
    {
        public int DateReservationId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public static List<ReservationDatesModel> IReservedDateTimes = new List<ReservationDatesModel>();

        public ReservationDatesModel(DateTime DateFrom, DateTime DateTo)
        {
            this.DateReservationId = IReservedDateTimes.Count == 0 ? 1 : IReservedDateTimes.Count() + 1;
            this.DateFrom = DateFrom;
            this.DateTo = DateTo;
        }
    }
}