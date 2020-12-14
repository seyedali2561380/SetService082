using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Data;
using BOL.DbContext;

namespace DAL
{
    public partial class EfRepository<T> :
        IRepositry<T> where T : BaseEntity
    {
        public EfRepository()
        {
            _Context = new SetServiceDbContext();
        }
        private readonly SetServiceDbContext _Context;
        private IDbSet<T> entities;
        public IQueryable<T> Table
        {
            get
            {
                return this.entities;
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get
            {
                return this.entities.AsNoTracking();
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");

                }
                this.entities.Remove(entity);
                _Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities==null)
                {
                    throw new ArgumentNullException("entities");

                }
                foreach (var e in entities)
                {
                    this.entities.Remove(e);
                }
                _Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }
        }

        public T GetById(int id)
        {
            return this.entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                this.entities.Add(entity);
                _Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }
        }

        public void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                foreach (var e in entities)
                {
                    this.entities.Add(e);
                }
                _Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                _Context.Entry(entity).State = EntityState.Modified;
                _Context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                foreach (var e in entities)
                {
                    _Context.Entry(e).State = EntityState.Modified;
                }
                _Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }
        }
        protected virtual IDbSet<T> Entitties
        {
            get
            {
                if (entities == null)
                    entities = _Context.Set<T>();
                return entities;

            }
        }
    }


}
