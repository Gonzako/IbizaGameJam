using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class BaseShootableEvent : UnityEvent<BaseShootable> { }

	[CreateAssetMenu(
	    fileName = "BaseShootableVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Shootable",
	    order = 120)]
	public class BaseShootableVariable : BaseVariable<BaseShootable, BaseShootableEvent>
	{
	}
}