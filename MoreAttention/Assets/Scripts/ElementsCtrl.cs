using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Elements ctrl.
/// </summary>

public class ElementsCtrl : MonoBehaviour {

	#region: PUBLIC VARIABLES
	public GameObject popUpScore;
	public Transform popUpScoreSpawner;
	#endregion

	#region: MONOBEHAVIOR METHODS

	void OnMouseDown(){
		
		gameObject.GetComponentInChildren<Light> ().enabled=false;
		gameObject.GetComponent<Collider2D> ().enabled=false;
		AudioCtrl.instance.SwitchOff (transform.position);
		Instantiate (popUpScore,popUpScoreSpawner.position,Quaternion.identity);
		GameCtrl.instance.UpdateScore ();
	
	}
	#endregion

}
