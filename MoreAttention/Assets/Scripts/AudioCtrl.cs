using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour {

	#region: PUBLIC VARIABLES
	public static AudioCtrl instance;
	public Audio gameAudio;
	#endregion

	void Awake(){

		if(instance==null){
			instance = this;
		}
	}

	public void SwitchOff(Vector3 pos){

		AudioSource.PlayClipAtPoint (gameAudio.switchOffAudio,pos);
		
	}


}
