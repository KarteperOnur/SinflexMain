using Microsoft.EntityFrameworkCore;
using Sinflex.BLL.Repositories.Abstracts.BaseAbstract;
using Sinflex.Core.Enums;
using Sinflex.DAL.Context;
using Sinflex.Model.Base;

namespace Sinflex.BLL.Repositories.Concretes.BaseConcrete
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly SinflexContext _context;
        private DbSet<T> _entities;

        public BaseRepository(SinflexContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<string> Create(T entity)
        {
            try
            {
                entity.Status = DataStatus.Created;

                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();

                return "Kayıt işlemi başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Delete(T entity)
        {
            try
            {
                entity.Status = DataStatus.Deleted;
                Update(entity);

                return "Silme işlemi başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> DestroyData(T entity)
        {
            _entities.Remove(entity);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return "Veri kalıcı olarak silindi";
            }
            else
            {
                return "Bir hata meydana geldi";
            }

        }

        public IEnumerable<T> GetActives()
        {
            return _entities.Where(x => x.IsActive == true).ToList();
        }

        public IQueryable<T> GetActivesQ()
        {
            return _entities.Where(x => x.IsActive == true);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public IQueryable<T> GetAllQ()
        {
            return _entities;
        }

        public T GetbyId(int id)
        {
            try
            {
                return _entities.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<T> GetPassives()
        {
            return _entities.Where(x => x.IsActive == false).ToList();
        }

        public IQueryable<T> GetPassivesQ()
        {
            return _entities.Where(x => x.IsActive == false);
        }

        public async Task<string> Update(T entity)
        {
            string result = "";
            switch (entity.Status)
            {
                case DataStatus.Deleted:
                    entity.Status = DataStatus.Deleted;
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    result = "Veri Güncellendi";
                    break;
                case DataStatus.Created:
                    entity.Status = DataStatus.Created;
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    result = "Veri Güncellendi";
                    break;
                case DataStatus.Updated:
                    entity.Status = DataStatus.Updated;
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    result = "Veri Güncellendi";
                    break;
            }
            return result;

        }
    }
}
