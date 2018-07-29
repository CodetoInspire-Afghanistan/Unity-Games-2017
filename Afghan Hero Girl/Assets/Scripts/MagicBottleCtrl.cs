using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBottleCtrl : MonoBehaviour {
	public Vector3 size;
	public Vector2 pos;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		transform.Rotate (size);
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void OnTriggerEnter2D(Collider2D co1){
		if(co1.gameObject.CompareTag("Player")){
			ServitorCtrl.isBottleCollected = true;
			GameCtrl.instance.UpdateScore (GameCtrl.Item.MagicBottle);
			GameCtrl.instance.UpdateMagicBottleCount ();
			Destroy (gameObject);
			SFXCtrl.instance.MagicBottle (transform.position);
			AudioController.instance.MagicBottle (transform.position);
		
		}
	}
}
