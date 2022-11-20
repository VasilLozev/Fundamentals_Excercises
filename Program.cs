using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularReservations = new HashSet<string>();
            HashSet<string> VIPreservations = new HashSet<string>();

            while (true)
            {
                string reservation = Console.ReadLine();

                if (reservation == "PARTY")
                {
                    while (true)
                    {
                        string reservationCame = Console.ReadLine();
                        if (reservationCame == "END")
                        {
                            reservation = reservationCame;
                            break;
                        }
                        if (char.IsDigit(reservationCame[0]))
                        {
                            VIPreservations.Remove(reservationCame);
                        }
                        else
                        {
                            regularReservations.Remove(reservationCame);
                        }
                    }
                }
                if (reservation.Length == 8)
                {

                    if (char.IsDigit(reservation[0]))
                    {
                        VIPreservations.Add(reservation);
                    }
                    else
                    {
                        regularReservations.Add(reservation);
                    }
                }
                if (reservation == "END")
                {
                    break;
                }
            }
            int count = regularReservations.Count + VIPreservations.Count;
            Console.WriteLine(count);
            foreach (var item in VIPreservations)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regularReservations)
            {
                Console.WriteLine(item);
            }
        }
    }
}
