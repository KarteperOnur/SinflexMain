using Sinflex.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.Model.Entities
{
    public class Booth:BaseEntity
    {
        public string Description { get; set; }


        //MAPPING

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
