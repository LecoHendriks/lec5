using Album.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Albums.Any())
            {
                return;   // DB has been seeded
            }

            var album = new Albummodel[]
            {
            // Id will be created and automatically incremented throught the database.
            new Albummodel{Name="Bullcrasf",Artist="Alexander",ImageUrl="usman.jpg"},
            new Albummodel{Name="Meredith",Artist="Alonso",ImageUrl="https://i.pinimg.com/550x/bd/81/41/bd8141a3f062fffe7fa72dd220403987.jpg"},
            new Albummodel{Name="United",Artist="Anand",ImageUrl="hello.png"},
            new Albummodel{Name="Welooe",Artist="Anand",ImageUrl="tests.png"}
            };
            foreach (Albummodel s in album)
            {
                context.Albums.Add(s);
            }
            context.SaveChanges();
        }
    }
}
