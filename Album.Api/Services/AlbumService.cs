using Album.Api.Data;
using Album.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Album.Api.Services
{
    public class AlbumService : IAlbumService<Albummodel>
    {
        private readonly AppDBContext _context;

        public AlbumService(AppDBContext context)
        {
            _context = context;
        }


        public Albummodel Create(Albummodel _object)
        {
            var obj = _context.Albums.Add(_object);
            _context.SaveChanges();

            return _object;
        }

        public void Delete(int Id)
        {
            _context.Albums.Remove(_context.Albums.Find(Id));
            _context.SaveChanges();
        }

        public IEnumerable<Albummodel> GetAll()
        {
            return _context.Albums.ToList();
        }

        public Albummodel GetById(int Id)
        {
            var albummodel = _context.Albums.Find(Id);

            if (albummodel != null)
            {
                return albummodel;
            }
            else
            {
                return null;
            }

        }

        public void Update(Albummodel _object, int Id)
        {
            _context.Albums.Update(_object);
            _context.SaveChanges();
        }

        
    }

    public interface IAlbumService<T>
    {
        public T Create(T _object);

        public void Update(T _object, int Id);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public void Delete(int Id);
    }
}
