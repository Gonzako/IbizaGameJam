using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "BaseShootableGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Shootable",
	    order = 120)]
	public sealed class BaseShootableGameEvent : GameEventBase<BaseShootable>
	{
	}
}