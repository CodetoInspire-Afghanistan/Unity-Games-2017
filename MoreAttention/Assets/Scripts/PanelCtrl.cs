using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Panel ctrl.
/// </summary>

public class PanelCtrl : MonoBehaviour {
	
	#region: PUBLIC VARIABLES
	public GameObject lamp;
	public GameObject panel;
	public GameObject timer;
	public GameObject tvProgramAudio;


	#endregion
		
	void Start(){
		foreach (Light light in lamp.transform.GetComponentsInChildren<Light>()) {
			light.enabled = false;
		}

		timer.GetComponent<TimerCtrl> ().enabled = false;
		tvProgramAudio.gameObject.SetActive (false);


	}


	#region: PUBLIC METHODS
	public void ClosePanel(){
		FindObjectOfType<PlayerCtrl> ().canMove = true;
		panel.gameObject.SetActive (false);
		foreach (Light light in lamp.transform.GetComponentsInChildren<Light>()) {
			light.enabled = true;
		}
		timer.GetComponent<TimerCtrl> ().enabled = true;
		tvProgramAudio.gameObject.SetActive (true);
		GameCtrl.instance.ResetData ();
	}
	#endregion

}
