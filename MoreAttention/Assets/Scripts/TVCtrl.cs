using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVCtrl : MonoBehaviour {

	#region: PUBLIC VARIABLES
	public GameObject fuse;
	public GameObject tvWire;
	public GameObject tvProgram;
	public GameObject popUpScore;
	public Transform popUpScoreSpawner;
	public GameObject tvProgramAudio;
	#endregion

	#region: MONOBEHAVIOR METHODS

	public void OnMouseDown(){
		
			Destroy (gameObject);
		fuse.gameObject.SetActive (true);
		tvWire.gameObject.SetActive (true);
		tvProgram.gameObject.SetActive (false);
		tvProgramAudio.SetActive (false);
		Instantiate (popUpScore, popUpScoreSpawner.position, Quaternion.identity);
		GameCtrl.instance.UpdateScore ();
	
	}
	#endregion
}
