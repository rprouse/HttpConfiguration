using Alteridem.Http.Service;
using System;

namespace HttpServiceConfiguration.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservations = UrlReservation.GetAll();
            foreach (UrlReservation r in reservations)
            {
                Console.WriteLine($"URL: {r.Url}");
                Console.WriteLine("Users: {0}", string.Join(", ", r.Users));
                Console.WriteLine();
            }
            Console.WriteLine("*** Press ENTER to Exit ***");
            Console.ReadLine();
        }
    }
}
