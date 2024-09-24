using Sinflex.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.Model.Entities
{
    public class Ticket : BaseEntity
    {

        public DateTime PurchaseDate { get; set; }
        public int PurchasePrice { get; set; }


        //MAPPING
        public virtual AppUser User { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
