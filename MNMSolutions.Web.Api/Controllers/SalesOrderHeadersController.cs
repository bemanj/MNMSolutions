using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.Web.Api.Controllers
{
    public class SalesOrderHeadersController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();
        //#region Global Declaration
        //private readonly IRepository<SalesOrderHeader> _soHeadersRepository = null;

        //public SalesOrderHeadersController()
        //{
        //    this._soHeadersRepository= new Repository<SalesOrderHeader>();
        //}
        //#endregion
        // GET: api/SalesOrderHeaders
        public IQueryable<SalesOrderHeader> GetSalesOrderHeaders()
        {
            return _db.SalesOrderHeaders;
        }

        // GET: api/SalesOrderHeaders/5
        [ResponseType(typeof(SalesOrderHeader))]
        public async Task<IHttpActionResult> GetSalesOrderHeader(int id)
        {
            SalesOrderHeader salesOrderHeader = await _db.SalesOrderHeaders.FindAsync(id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            return Ok(salesOrderHeader);
        }

        // PUT: api/SalesOrderHeaders/5 [FromUri]  int id, 
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSalesOrderHeader([FromBody] SalesOrderHeader salesOrderHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //if (id != salesOrderHeader.SalesOrderID)
            //{
            //    return BadRequest();
            //}

            _db.Entry(salesOrderHeader).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderHeaderExists(salesOrderHeader.SalesOrderID))
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

        // POST: api/SalesOrderHeaders
        [ResponseType(typeof(SalesOrderHeader))]
        //[HttpPost] [FromBody] 
        public async Task<IHttpActionResult> PostSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.SalesOrderHeaders.Add(salesOrderHeader);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = salesOrderHeader.SalesOrderID }, salesOrderHeader);
        }

        // DELETE: api/SalesOrderHeaders/5
        [ResponseType(typeof(SalesOrderHeader))]
        public async Task<IHttpActionResult> DeleteSalesOrderHeader(int id)
        {
            SalesOrderHeader salesOrderHeader = await _db.SalesOrderHeaders.FindAsync(id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            _db.SalesOrderHeaders.Remove(salesOrderHeader);
            await _db.SaveChangesAsync();

            return Ok(salesOrderHeader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesOrderHeaderExists(int id)
        {
            return _db.SalesOrderHeaders.Count(e => e.SalesOrderID == id) > 0;
        }
    }
}