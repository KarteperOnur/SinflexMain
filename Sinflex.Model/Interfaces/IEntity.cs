using Sinflex.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.Model.Interfaces
{
    public interface IEntity<T>
    {
        //Id: verinin veritabanında PK olarak tanımlanmasını temsil edecek.
        //MasterId: verinin UI'da  görüntülenmesi için kullanılabilir.

        public int Id { get; set; }
        public T MasterId { get; set; }

        //Ortak özellikler

        //Created
        public DateTime CreatedDate { get; set; }

        //Updated
        public DateTime? UpdatedDate { get; set; }


        public bool IsActive { get; set; }
        public DataStatus Status { get; set; }
    }
}
