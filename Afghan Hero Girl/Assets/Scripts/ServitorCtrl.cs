using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServitorCtrl : MonoBehaviour {
	public static ServitorCtrl instance;
	public static bool isBottleCollected;
	public GameObject solduer;
	public Button bottleButton;
	public bool startFlying;
	public Sprite newSprite;
	public float flySpeed;
	int magicBottleNumber;
	public bool isTuoch;



	void Awake(){
		if (instance == null)
			instance = this;
	}

	// Use this for initialization
	void Start () {
//		bottleButton=bottleButton.GetComponent<Button> ();
		startFlying = false;


	}
	
	// Update is called once per frame
	void Update () {

		if (startFlying) {
			
			transform.position = Vector3.Lerp (transform.position,solduer.transform.position,flySpeed);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("BottleBullet")) {
			
			if (GameCtrl.instance.data.magicBottleCounter > 0) {
				AudioController.instance.SavingServitor (col.transform.position);
				SFXCtrl.instance.Servicer (transform.position);
				startFlying = true;
				gameObject.transform.Find ("Magic").gameObject.SetActive (false);
				gameObject.transform.Find ("Man").GetComponent<SpriteRenderer> ().sprite = newSprite;
				GameCtrl.instance.UpdateSoldeirCount ();
				bottleButton.interactable = false;
				Destroy (col.gameObject);
				GameCtrl.instance.FireBottle ();
			}
		}

	}
		
	void OnTriggerStay2D(Collider2D col){

		if (col.gameObject.CompareTag ("Player")) {
			RescueBtnCtrl.Pass (gameObject);
			bottleButton.gameObject.SetActive (true);
			if (GameCtrl.instance.data.magicBottleCounter > 0 ) {
				bottleButton.interactable = true;
				isTuoch = true;

			} 

		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.CompareTag ("Player")) {
			bottleButton.interactable = false;
			bottleButton.gameObject.SetActive (false);
			isTuoch = false;

		}
	
	}

}
