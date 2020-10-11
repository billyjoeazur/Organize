using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Organize.Shared.Entities
{
	public class ParentItem : BaseItem
	{
		public ObservableCollection<ChildItem> ChildItems { get; set; }
	}
}
