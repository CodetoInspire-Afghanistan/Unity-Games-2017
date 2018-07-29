using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GemCtrl : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.CompareTag ("Player")) {
            
			GameCtrl.instance.UpdateGemCount ();
			GameCtrl.instance.UpdateScore (GameCtrl.Item.Gem);
			Destroy (gameObject);
			SFXCtrl.instance.gem(transform.position);
			AudioController.instance.GemPickUp (transform.position);
		}
	}		
}
