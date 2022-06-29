using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Album.Api.Data;
using Album.Api.Models;
using Album.Api.Services;

namespace Album.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService<Albummodel> _albumService;

        public AlbumController(IAlbumService<Albummodel> albumService)
        {
            _albumService = albumService;
        }

        // GET: api/Album
        [HttpGet]
        public IActionResult GetAlbums()
        {
            var items = _albumService.GetAll();
            return Ok(items);
        }

      // GET: api/Album/5
        [HttpGet("{id}")]
        public IActionResult GetAlbummodel(int id)
        {
            if (_albumService.GetById(id) == null)
            {
                return NotFound();
            }
            else { return Ok(_albumService.GetById(id)); }
            
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutAlbummodel(int id, Albummodel albummodel)
        {
            _albumService.Update(albummodel, id);
            //if (id != albummodel.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(albummodel).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AlbummodelExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/Album
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAlbummodel(Albummodel albummodel)
        {
            if (albummodel.Name == null | albummodel.Artist == null | albummodel.ImageUrl == null) { return BadRequest(); }
            else
            {
                _albumService.Create(albummodel);

                return CreatedAtAction("GetAlbumModel", new { id = albummodel.Id }, albummodel);
            }
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbummodel(int id)
        {
            _albumService.Delete(id);
            return NoContent();
        }
    }
}
