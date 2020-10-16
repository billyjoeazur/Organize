using Microsoft.AspNetCore.Components;
using Organize.Shared.Contracts;
using Organize.Shared.Entities;
using Organize.WASM.ItemEdit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Organize.WASM.Components
{
	public partial class ItemsList : ComponentBase, IDisposable
	{
		[Inject]
		private ICurrentUserService CurrentUserService { get; set; }

		[Inject]
		private ItemEditService ItemEditService { get; set; }

		protected ObservableCollection<BaseItem> UserItems { get; set; } = new ObservableCollection<BaseItem>();

		protected override void OnInitialized()
		{
			base.OnInitialized();

			UserItems = CurrentUserService.CurrentUser.UserItems;
			UserItems.CollectionChanged += HandleUserItemsCollectionChanged;
			Console.WriteLine(UserItems.Count);
			Console.WriteLine(UserItems);
			Console.WriteLine(JsonSerializer.Serialize(UserItems));
		}

		private void HandleUserItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			StateHasChanged();
		}

		private void OnBackgroundClicked()
		{
			ItemEditService.EditItem = null;
		}

		public void Dispose()
		{
			UserItems.CollectionChanged -= HandleUserItemsCollectionChanged;
		}
	}
}
