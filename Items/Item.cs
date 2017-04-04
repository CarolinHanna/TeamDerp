using UnityEngine;
using System.Collections;
using UnityEngine.UI;

abstract public class Item : ScriptableObject {

	[SerializeField] protected string item_name = null;
	[SerializeField] public Sprite ui_sprite = null;
	[SerializeField] protected GameObject model_prefab = null;

	public abstract void use_item();
}
