using Sinflex.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sinflex.BLL.Repositories.ViewModels.AppUserViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
		[Display(Name = "Kullanıcı adı")]


		public string Username { get; set; }

		[Required(ErrorMessage = "Email boş geçilemez")]
		[EmailAddress(ErrorMessage = "Değer email formatında olmalı")]

		private string _emailAddress;
		public string Email
		{

			get { return _emailAddress; }

			set
			{
				var usernameArray = value.Split('@');
				Username = usernameArray[0];
				_emailAddress = value;
			}
		}

		[Required(ErrorMessage = "Şifre boş geçilemez")]
		[Display(Name = "Şifre")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Şifre (Tekrar) boş geçilemez")]
		[Display(Name = "Şifre (Tekrar)")]
		[Compare("Password", ErrorMessage = "Şifreler uyumlu aynı")]
		public string ConfirmPassword { get; set; }
		public string ConfirmEmail { get; set; }
		public string Address { get; set; }
		public string EconomicalStatus { get; set; }
		public DateTime BirthDate { get; set; }
		public string Profession { get; set; }
		public string PhoneNumber { get; set; }
		public Gender Gender { get; set; }


	}
}


