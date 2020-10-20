using Blazored.Modal;
using Blazored.Modal.Services;
using GeneralUi.BusyOverlay;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Organize.Business;
using Organize.Shared.Contracts;
using Organize.Shared.Entities;
using Organize.WASM.Components;
using Organize.WASM.OrganizeAuthenticationStateProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Organize.WASM.Pages
{
	public class SignInBase : SignBase
	{
        protected string Day { get; } = DateTime.Now.DayOfWeek.ToString();
		

		[Inject]
		private NavigationManager NavigationManager { get; set; }

		[Inject]
		private IUserManager UserManager { get; set; }

		[Inject]
		private IModalService ModalService { get; set; }

		[Inject]
		private BusyOverlayService BusyOverlayService { get; set; }

		[Inject]
		private ICurrentUserService CurrentUserService { get; set; }

		[Inject]
		private IAuthenticationStateProvider authenticationStateProvider { get; set; }

		protected async void OnSubmit()
		{
			if (!EditContext.Validate())
			{
				return;
			}

			try
			{
				BusyOverlayService.SetBusyState(BusyEnum.Busy);
				var foundUser = await UserManager.TrySignInAndGetUserAsync(User);

				if (foundUser != null)
				{
					authenticationStateProvider.SetAuthenticatedState(foundUser);
					CurrentUserService.CurrentUser = foundUser;
					NavigationManager.NavigateTo("items");
				}
				else
				{
					var parameters = new ModalParameters();
					parameters.Add(nameof(ModalMessage.Message), "User not found");
					ModalService.Show<ModalMessage>("Error", parameters);
				}
			}
			catch(Exception e)
			{
				var parameters = new ModalParameters();
				parameters.Add(nameof(ModalMessage.Message), e.Message);
				ModalService.Show<ModalMessage>("Error", parameters);
			}
			finally
			{
				BusyOverlayService.SetBusyState(BusyEnum.NotBusy);
			}
		}

		//      protected string Username { get; set; } = "Boyet";

		//      protected User User { get; set; } = new User();

		//protected EditContext EditContext { get; set; }

		protected override void OnInitialized()
		{
			base.OnInitialized();
			User = new User { FirstName = "x", LastName = "x", PhoneNumber = "123" };
			EditContext = new EditContext(User);
		}

		//protected void HandleUserNameChanged(ChangeEventArgs eventArgs)
		//      {
		//          Username = eventArgs.Value.ToString();
		//      }

		//      protected void HandleUserNameValueChanged(string value)
		//      {
		//          Username = value;
		//      }

		//      public string GetError(Expression<Func<object>> fu)
		//      {
		//          if (EditContext == null)
		//          {
		//              return null;
		//          }
		//          return EditContext.GetValidationMessages(fu).FirstOrDefault();
		//      }
	}
}
