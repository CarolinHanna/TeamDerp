using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Items/Potion")]
public class Potion : Item {

	[SerializeField] PotionType potion_type;
	[SerializeField] int restore_amount = 1;

	public override void use_item(){
		Debug.Log("I healed the player i promise");
	}

	enum PotionType{
		health,
		mana,
	}
}
