using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeneralUi.Validation
{
	public class ValidationInputBase : ComponentBase
	{
		[Parameter]
		public EventCallback<string> ValueChanged { get; set; }

		[Parameter]
		public string Value { get; set; }

		[Parameter]
		public string Error { get; set; }

		[Parameter(CaptureUnmatchedValues =true)]
		public Dictionary<string, object> InputAttributes { get; set; }

		protected async void HandleInputChanged(ChangeEventArgs eventArgs)
		{
			await ValueChanged.InvokeAsync(eventArgs.Value.ToString());
		}

		
	}
}
