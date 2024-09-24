using Sinflex.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.Model.Entities
{
    public class Session:BaseEntity
    {
        public DateTime Time { get; set; }

        //MAPPING

        public virtual Movie Movies { get; set; }
    }
}
