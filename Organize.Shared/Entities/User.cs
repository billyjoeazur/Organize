using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Organize.Shared.Entities
{
	public class User : BaseEntity
	{
		[Required]
		[StringLength(10, ErrorMessage ="username is too long.")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "The Password is Required!!!")]
		public string Password { get; set; }


		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		[Phone]
		public string PhoneNumber { get; set; }

		public ObservableCollection<BaseItem> UserItems { get; set; }
	}
}
