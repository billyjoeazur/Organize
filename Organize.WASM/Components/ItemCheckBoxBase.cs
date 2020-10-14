using Microsoft.AspNetCore.Components;
using Organize.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organize.WASM.Components
{
	public class ItemCheckBoxBase : ComponentBase
	{
		[Parameter]
		public BaseItem Item { get; set; }

		[CascadingParameter]
		public string ColorPrefix { get; set; }
	}
}
