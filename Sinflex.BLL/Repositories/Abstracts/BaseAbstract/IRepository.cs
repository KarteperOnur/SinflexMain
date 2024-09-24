using Sinflex.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.BLL.Repositories.Abstracts.BaseAbstract
{
    public interface IRepository<T> where T : BaseEntity
    {

        //List
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllQ();


        //Get
        T GetbyId(int id);

        //Active
        IEnumerable<T> GetActives();
        IQueryable<T> GetActivesQ();

        //Passive
        IEnumerable<T> GetPassives();
        IQueryable<T> GetPassivesQ();


        //Destroy
        Task<string> DestroyData(T entity);

        //Create
        Task<string> Create(T entity);

        //Update
        Task<string> Update(T entity);

        //Delete
        Task<string> Delete(T entity);



















    }
}
