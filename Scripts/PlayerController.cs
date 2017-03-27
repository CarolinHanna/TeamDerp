using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController singleton = null;

	void Awake(){
		if(!singleton)
			PlayerController.singleton = this;
		else
			Destroy(this.gameObject);
	}
}
