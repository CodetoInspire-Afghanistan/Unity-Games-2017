using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {

	public void Play(int sceneNum){
		GameCtrl.instance.ResetData ();
		SceneManager.LoadScene (sceneNum);

		
	}
}
