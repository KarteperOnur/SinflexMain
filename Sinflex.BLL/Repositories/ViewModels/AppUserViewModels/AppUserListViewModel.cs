using Sinflex.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.BLL.Repositories.ViewModels.AppUserViewModels
{
    public class AppUserListViewModel
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }

        public string Profession { get; set; }
        public string EconomicalStatus { get; set; }
        public UserType UserType { get; set; }

    }
}
