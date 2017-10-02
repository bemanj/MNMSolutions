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
        private MNMSolutionsDevDBEntities1 context;  
        //-- -- -- -- -- -- -- -- -- -- - > represent edmx context name
        private DbSet<T> dbSet;  
        //-- -- -- -- -- -- -- -- -- -- -- -- -- - > represent respective table to perform certain operations
        public Repository()
        {
            context = new MNMSolutionsDevDBEntities1();
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() //-- -- -- -- -- -- -- -- -- > To get all data from respective table 
        {  
            return dbSet.ToList();  
        }

        public T GetById(object id) //-- -- -- -- -- -- -- -- -- -- -- -- - > To get particular row data based on id(this id field should be the primary key field)
        {
            return dbSet.Find(id);
        }

        public T Insert(T obj) //-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- > Add new record to respectiv table
        {
            dbSet.Add(obj);  
            Save();  
            return obj;  
        }
        public void Delete(object id) //-- -- -- -- -- -- -- -- -- -- > Delete respective record from respective table based on primarykey id
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public void Delete(T entityToDelete) //-- -- -- -- -- -- -- -- -- > this is to record the state as detached
        {
            //while we deleting data from table {  
            if (context.Entry(entityToDelete).State == EntityState.Detached) {
            dbSet.Attach(entityToDelete);
            //------------------------ > it add the row like in particular table, particular field, particular value has been deleted with timestamps.
            }
        dbSet.Remove(entityToDelete);
        }

        public T Update(T obj) //-- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- > it 's to update the existing record  {  
        {
            dbSet.Attach(obj);  
            context.Entry(obj).State = EntityState.Modified;  
            //-- -- -- -- -- - > same to record the modified state and where, what and when
            Save();  
            return obj;  
        }

        public void Save()
        {
            try {
                context.SaveChanges();
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
                if (context != null) {
                    context.Dispose();
                    context = null;
                }       
            }  
        }

    }
}