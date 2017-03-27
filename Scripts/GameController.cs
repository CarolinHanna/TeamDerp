using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController singleton = null;

	void Awake(){
		if(!singleton)
			GameController.singleton = this;
		else
			Destroy(this.gameObject);
	}
}
