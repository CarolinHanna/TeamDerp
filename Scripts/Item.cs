using UnityEngine;
using System.Collections;
using UnityEngine.UI;

abstract public class Item : ScriptableObject {

	[SerializeField] protected string item_name = null;
	[SerializeField] protected Sprite ui_sprite = null;

	virtual protected void use_item(){}
}
