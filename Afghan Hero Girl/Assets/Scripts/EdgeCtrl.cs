using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCtrl : MonoBehaviour {
	public Transform leftPos,rightPos;
	public float delay,delayForAppear;



	public void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {

			transform.parent.GetComponent<Animator> ().SetInteger ("State", 1);
			Invoke ("SetAnimToAppear",delay);

		}
	}
		
	public void SetAnimToAppear(){
			
		transform.parent.GetComponent<Animator> ().SetInteger ("State", 2);

		Invoke ("DisappearBoss",delayForAppear);
	
	}

	public void DisappearBoss(){
		if(!transform.parent.GetComponent<SpriteRenderer> ().flipX){
		transform.parent.transform.position = leftPos.position;
		}
		else if(transform.parent.GetComponent<SpriteRenderer> ().flipX){
			transform.parent.transform.position = rightPos.position;
		}
	}
		
}

