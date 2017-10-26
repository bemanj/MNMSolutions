using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.DB.Dev;
using MNMSolutions.DAL.Repository;

namespace MNMSolutions.Web.Api.Controllers
{
    public class Category1Controller : ApiController
    {
        //private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        #region Global Declaration
        private readonly IRepository<category1> _category1Repository = null;

        public Category1Controller()
        {
            this._category1Repository = new Repository<category1>();
        }
        #endregion

        // GET: api/category1
        //[Route("api/category1")]
        [HttpGet]
        public HttpResponseMessage Getcategories1()
        {
            var result = _category1Repository.GetAll();
            var response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // GET: api/category1/5
        [ResponseType(typeof(category1))]
        public IHttpActionResult Getcategories1(string id)
        {
            var category1 = _category1Repository.GetById(id);//_db.categories1.FindAsync(id);
            if (category1 == null)
            {
                return NotFound();
            }

            return Ok(category1);
        }

        // PUT: api/category1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcategory1(string id, category1 category1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category1.category)
            {
                return BadRequest();
            }

            _category1Repository.Update(category1);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/category1
        [ResponseType(typeof(category1))]
        public IHttpActionResult Postcategory1(category1 category1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _category1Repository.Insert(category1);

            return CreatedAtRoute("DefaultApi", new { id = category1.category }, category1);
        }

        // DELETE: api/category1/5
        [ResponseType(typeof(category1))]
        public IHttpActionResult Deletecategory1(string id)
        {
            var category1 = _category1Repository.GetById(id);
            if (category1 == null)
            {
                return NotFound();
            }

            _category1Repository.Delete(category1);

            return Ok(category1);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool category1Exists(string id)
        //{
        //    return _db.categories1.Count(e => e.category == id) > 0;
        //}
    }
}