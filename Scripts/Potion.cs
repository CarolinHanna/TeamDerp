using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class Potion : Item {

	[SerializeField] type potion_type;

	protected override void use_item(){
		
	}

	enum type{
		health,
		mana,
	}
}
