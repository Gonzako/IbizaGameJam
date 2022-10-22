using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "BaseShootable")]
	public sealed class BaseShootableGameEventListener : BaseGameEventListener<BaseShootable, BaseShootableGameEvent, BaseShootableUnityEvent>
	{
	}
}