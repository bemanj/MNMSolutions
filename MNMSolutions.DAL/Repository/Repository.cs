using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNMSolutions.DAL.DB.Dev;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MNMSolutions.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MNMSolutionsDevDBEntities _context;  
        //-- -- -- -- -- -- -- -- -- -- - > represent edmx context name
        private readonly DbSet<T> _dbSet;  
        //-- -- -- -- -- -- -- -- -- -- -- -- -- - > represent respective table to perform certain operations
        public Repository()
        {
            _context = new MNMSolutionsDevDBEntities();
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll() //-- -- -- -- -- -- -- -- -- > To get all data from respective table 
        {  
            return _dbSet.ToList();  
        }

        public T GetById(object id) //-- -- -- -- -- -- -- -- -- -- -- -- - > To get particular row data based on id(this id field should be the primary key field)
        {
            return _dbSet.Find(id);
        }

        public T Insert(T obj) //-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- > Add new record to respectiv table
        {
            _dbSet.Add(obj);  
            Save();  
            return obj;  
        }
        public void Delete(object id) //-- -- -- -- -- -- -- -- -- -- > Delete respective record from respective table based on primarykey id
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }
        public void Delete(T entityToDelete) //-- -- -- -- -- -- -- -- -- > this is to record the state as detached
        {
            //while we deleting data from table {  
            if (_context.Entry(entityToDelete).State == EntityState.Detached) {
            _dbSet.Attach(entityToDelete);
            //------------------------ > it add the row like in particular table, particular field, particular value has been deleted with timestamps.
            }
        _dbSet.Remove(entityToDelete);
        }

        public T Update(T obj) //-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- > it 's to update the existing record  {  
        {
            _dbSet.Attach(obj);  
            _context.Entry(obj).State = EntityState.Modified;  
            //-- -- -- -- -- - > same to record the modified state and where, what and when
            Save();  
            return obj;  
        }

        public void Save()
        {
            try {
                _context.SaveChanges();
                //----------------------------------------- > to keep changing the entityframe as well db
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        //--- > you just put the log to know the errors
                        }
                }
            }
        }
        protected virtual void Dispose(bool disposing) //-- -- -- -- -- -- -- - > this dispose method after very instance 
        {  
            if (disposing) {  
                if (_context != null) {
                    _context.Dispose();
                    _context = null;
                }       
            }  
        }

    }
}