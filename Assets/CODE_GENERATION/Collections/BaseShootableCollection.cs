using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "BaseShootableCollection.asset",
	    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Shootable",
	    order = 120)]
	public class BaseShootableCollection : Collection<BaseShootable>
	{
	}
}