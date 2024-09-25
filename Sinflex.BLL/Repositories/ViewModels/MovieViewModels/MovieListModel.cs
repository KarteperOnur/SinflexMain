using Sinflex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.BLL.Repositories.ViewModels.MovieViewModels
{
    public class MovieListModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
		public double Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<DateTime> AirDates { get; set; }
        public string ImagePath { get; set; }
        public string Actors { get; set; }
        public string Category { get; set; }
        public string Director { get; set; }
        public string AgeRestriction { get; set; }

		//Session Bilgileri.
		//public Session Session { get; set; }




	}
}
