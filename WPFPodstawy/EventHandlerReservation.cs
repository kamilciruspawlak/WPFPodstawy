﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPodstawy
{
    public class EventHandlerReservation
    {
        public void LogTrans(object sender, EventArgs eventArgs)
        {
            var args = eventArgs as ReservationEventArgs;
            Console.WriteLine($"Został zarejstrowany bilet na film: { args.Movie}, Użytkownik: {args.Name}, numer rezerwacji: {args.ReservationId}");
        }
    }
}
