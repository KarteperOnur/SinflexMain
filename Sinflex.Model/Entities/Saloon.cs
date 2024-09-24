using Sinflex.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.Model.Entities
{
    public class Saloon : BaseEntity
    {

        public string Name { get; set; }
        public int Capacity { get; set; }
		


		//MAPPING
		public ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
        public ICollection<Ticket> Ticket { get; set; } = new HashSet<Ticket>();
    }
}
