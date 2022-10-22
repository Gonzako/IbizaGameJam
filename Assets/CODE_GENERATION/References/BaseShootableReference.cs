using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class BaseShootableReference : BaseReference<BaseShootable, BaseShootableVariable>
	{
	    public BaseShootableReference() : base() { }
	    public BaseShootableReference(BaseShootable value) : base(value) { }
	}
}