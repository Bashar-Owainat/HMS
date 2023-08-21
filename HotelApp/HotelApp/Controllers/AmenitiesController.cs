using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApp.Data;
using HotelApp.Models;
using HotelApp.Models.Interfaces;
using HotelApp.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HotelApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            var Amenities = await _amenity.GetAll();
            return Amenities;

        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            Amenity amenity = await _amenity.GetById(id);
            AmenityDTO dto = new AmenityDTO { ID = amenity.Id, Name = amenity.Name };
            return dto;

        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
           Amenity updated = await _amenity.Update(id, amenity);
            return Ok(updated);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize(Roles = "PropertyManager")]
        [HttpPost]
        [Authorize(Roles = "DistrictManager,PropertyManager")]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
           await _amenity.Insert(amenity);
            return Ok(amenity); 

        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            await _amenity.Delete(id);
            return NoContent();
        }

    }
}
