using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Items/Potion")]
public class Potion : Item {

	[SerializeField] PotionType potion_type;
	[SerializeField] int restore_amount = 1;

	protected override void use_item(){
		Debug.LogWarning("Used potion but shits not implimented");
	}

	enum PotionType{
		health,
		mana,
	}
}
