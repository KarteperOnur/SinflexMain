using Sinflex.Core.Enums;
using Sinflex.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.Model.Entities
{
    public class Reservation : BaseEntity
    {
        public int Price { get; set; }
        public SaleType SaleType { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual AppUser User { get; set; }
    }
}
