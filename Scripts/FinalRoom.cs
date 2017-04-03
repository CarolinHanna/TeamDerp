using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		//print("something entered collider");
		if(other.tag == "Player"){
			//print("player entered");
			GetComponent<Animator>().enabled = true;
		}
	}
}
