using Sinflex.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.Model.Entities
{
    public class Seat : BaseEntity
    {
        public bool IsReserved { get; set; }
        public bool IsSold { get; set; }
        public bool IsAvailable { get; set; }


        public virtual Saloon Saloon { get; set; }
    }
}
