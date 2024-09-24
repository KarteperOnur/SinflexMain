
using Sinflex.Core.Enums;
using Sinflex.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.Model.Base
{
    public abstract class BaseEntity : IEntity<Guid>
    {
        public BaseEntity()
        {
            Status = DataStatus.Created;

            CreatedDate = DateTime.Now;
            MasterId = Guid.NewGuid();
            IsActive = true;

        }
        public int Id { get; set; }
        public Guid MasterId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public DataStatus Status { get; set; }
    }
}
