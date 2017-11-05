using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.Web.Api.Controllers
{
    public class ViewSalesOrderDetailsController : ApiController
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // GET: api/View_SalesOrderDetails
        public IQueryable<View_SalesOrderDetails> GetView_SalesOrderDetails()
        {
            return _db.View_SalesOrderDetails;
        }

        // GET: api/View_SalesOrderDetails/5
        [ResponseType(typeof(View_SalesOrderDetails))]
        public async Task<IHttpActionResult> GetView_SalesOrderDetails(int id)
        {
            View_SalesOrderDetails viewSalesOrderDetails = await _db.View_SalesOrderDetails.FindAsync(id);
            if (viewSalesOrderDetails == null)
            {
                return NotFound();
            }

            return Ok(viewSalesOrderDetails);
        }

        //    // PUT: api/View_SalesOrderDetails/5
        //    [ResponseType(typeof(void))]
        //    public async Task<IHttpActionResult> PutView_SalesOrderDetails(int id, View_SalesOrderDetails view_SalesOrderDetails)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != view_SalesOrderDetails.OrderID)
        //        {
        //            return BadRequest();
        //        }

        //        db.Entry(view_SalesOrderDetails).State = EntityState.Modified;

        //        try
        //        {
        //            await db.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!View_SalesOrderDetailsExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return StatusCode(HttpStatusCode.NoContent);
        //    }

        //    // POST: api/View_SalesOrderDetails
        //    [ResponseType(typeof(View_SalesOrderDetails))]
        //    public async Task<IHttpActionResult> PostView_SalesOrderDetails(View_SalesOrderDetails view_SalesOrderDetails)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        db.View_SalesOrderDetails.Add(view_SalesOrderDetails);

        //        try
        //        {
        //            await db.SaveChangesAsync();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (View_SalesOrderDetailsExists(view_SalesOrderDetails.OrderID))
        //            {
        //                return Conflict();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return CreatedAtRoute("DefaultApi", new { id = view_SalesOrderDetails.OrderID }, view_SalesOrderDetails);
        //    }

        //    // DELETE: api/View_SalesOrderDetails/5
        //    [ResponseType(typeof(View_SalesOrderDetails))]
        //    public async Task<IHttpActionResult> DeleteView_SalesOrderDetails(int id)
        //    {
        //        View_SalesOrderDetails view_SalesOrderDetails = await db.View_SalesOrderDetails.FindAsync(id);
        //        if (view_SalesOrderDetails == null)
        //        {
        //            return NotFound();
        //        }

        //        db.View_SalesOrderDetails.Remove(view_SalesOrderDetails);
        //        await db.SaveChangesAsync();

        //        return Ok(view_SalesOrderDetails);
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }

        //    private bool View_SalesOrderDetailsExists(int id)
        //    {
        //        return db.View_SalesOrderDetails.Count(e => e.OrderID == id) > 0;
        //    }
    }
}