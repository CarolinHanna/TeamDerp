using UnityEngine;

public class ItemPickup : MonoBehaviour {

	[SerializeField] Item item;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			PlayerController.singleton.add_item(item);
			Destroy(this.gameObject);
		}
	}
}
