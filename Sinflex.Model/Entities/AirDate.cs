using Sinflex.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.Model.Entities
{
	public class AirDate:BaseEntity
	{
        public DateTime Airdate { get; set; }

		public virtual Movie Movie { get; set; }

    }
}
