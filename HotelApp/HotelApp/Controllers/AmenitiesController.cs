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
            var Amenities = await _amenity.GetAmenities();
            return Amenities;

        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            AmenityDTO amenity = await _amenity.GetAmenity(id); 
            return amenity;

        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
           Amenity updated = await _amenity.UpdateAmenity(id, amenity);
            return Ok(updated);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize(Roles = "PropertyManager")]
        [Authorize(Roles = "DistrictManager,PropertyManager")]
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(AmenityDTO amenity)
        {
           await _amenity.CreateAmenity(amenity);
            return Ok(amenity); 

        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            await _amenity.DeleteAmenity(id);
            return NoContent();
        }

    }
}
