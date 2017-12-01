using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.Web.Api.Controllers.Brands
{
    public class BrandsController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/Brands
        public IQueryable<Brand> GetBrands()
        {
            // retrieve brands
            return _db.Brands;
        }

        // GET: api/Brands/5
        [ResponseType(typeof(Brand))]
        public IHttpActionResult GetBrand(int id)
        {
            Brand brand = _db.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        // PUT: api/Brands/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBrand(int id, Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brand.id)
            {
                return BadRequest();
            }

            _db.Entry(brand).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Brands
        [ResponseType(typeof(Brand))]
        public IHttpActionResult PostBrand(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Brands.Add(brand);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brand.id }, brand);
        }

        // DELETE: api/Brands/5
        [ResponseType(typeof(Brand))]
        public IHttpActionResult DeleteBrand(int id)
        {
            Brand brand = _db.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            _db.Brands.Remove(brand);
            _db.SaveChanges();

            return Ok(brand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrandExists(int id)
        {
            return _db.Brands.Count(e => e.id == id) > 0;
        }
    }
}