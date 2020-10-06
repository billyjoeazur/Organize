using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organize.WASM.Controls
{
	public class ValidationInputBase : ComponentBase
	{
		[Parameter]
		public EventCallback<string> ValueChangedCallback { get; set; }

		[Parameter]
		public string Value { get; set; }

		protected async void HandleInputChanged(ChangeEventArgs eventArgs)
		{
			await ValueChangedCallback.InvokeAsync(eventArgs.Value.ToString());
		}
	}
}
