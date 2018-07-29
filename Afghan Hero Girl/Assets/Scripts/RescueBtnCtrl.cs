using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RescueBtnCtrl : MonoBehaviour {

	public Image rescueImg;
    static GameObject gameSer;
	 float holdDown;

	// Use this for initialization
	void Start () {
		rescueImg.fillAmount = 0f;
		
	}

	public static void Pass(GameObject g){
		gameSer = g;
	}

	public void OnPointerDown(){
		if (ServitorCtrl.isBottleCollected) {
			rescueImg.fillAmount = 0f;
			StartCoroutine ("StartCounting");

		}

	}

	public void OnPointerUp(){
		if(ServitorCtrl.isBottleCollected){
			StopCoroutine ("StartCounting");

			if(holdDown<0.9f){
				print ("Something1");
			}else{
				
				SFXCtrl.instance.KeySparkle (gameSer.transform.position);
				AudioController.instance.GemPickUp (gameSer.transform.position);
				GameCtrl.instance.LessMagicBottle_Servitor ();
				Destroy (gameSer);
				print("Something2");
				ServitorCtrl.isBottleCollected = false;
		
			}
			rescueImg.fillAmount = 0f;
	}
	}
	IEnumerator StartCounting(){

		for(holdDown=0f;holdDown<=1f;holdDown+=Time.deltaTime){
			rescueImg.fillAmount = holdDown;
			yield return new WaitForSeconds (Time.deltaTime);
		}
		holdDown = 1f;
		rescueImg.fillAmount = holdDown;
	}
}
