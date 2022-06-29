using Album.Api.Models;
using Album.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Api.Tests
{
    public class AlbumServiceFake : IAlbumService<Albummodel>
    {

        private readonly List<Albummodel> _albummodels;
        public AlbumServiceFake()
        {
            _albummodels = new List<Albummodel>()
            {
                new Albummodel() { Id = 1,
                    Name = "Orange Juice", Artist="Orange Tree", ImageUrl = "https://www.google.com" },
                new Albummodel() { Id = 2,
                    Name = "Diary Milk", Artist="Cow", ImageUrl = "https://www.google.com" },
                new Albummodel() { Id = 3,
                    Name = "Frozen Pizza", Artist="Uncle Mickey", ImageUrl = "https://www.google.com" }
            };
        }

        public Albummodel Create(Albummodel _object)
        {
            _albummodels.Add(_object);
            return _object;
        }

        public void Delete(int Id)
        {
            var existing = _albummodels.First(a => a.Id == Id);
            _albummodels.Remove(existing);
        }

        public IEnumerable<Albummodel> GetAll()
        {
            return _albummodels;
        }

        public Albummodel GetById(int Id)
        {
            return _albummodels.Where(a => a.Id == Id)
                .FirstOrDefault();
        }

        public void Update(Albummodel _object, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
