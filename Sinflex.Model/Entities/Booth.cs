using Sinflex.Model.Base;

namespace Sinflex.Model.Entities
{
    public class Booth:BaseEntity
    {
        public string Description { get; set; }


        //MAPPING

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
