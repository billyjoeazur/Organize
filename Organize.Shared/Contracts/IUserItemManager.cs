using Organize.Shared.Entities;
using Organize.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Organize.Shared.Contracts
{
	public interface IUserItemManager
	{
		Task<ChildItem> CreateNewChildItemAndAddItToParentItemAsync(ParentItem parent);

		Task<BaseItem> CreateNewUserItemAndAddItToUserAsync(User user, ItemTypeEnum typeEnum);
	}
}
