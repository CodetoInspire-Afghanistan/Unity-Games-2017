using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
/// <summary>
/// Game ctrl.
/// </summary>

public class GameCtrl : MonoBehaviour {
	
	#region: PUBLIC VARIABLES
	public GameData data;
	public static GameCtrl instance;
	public UI ui;
	public GameObject winPanel;
	public GameObject tvProgramAudio;
	public GameObject gameOverPanel;
	public GameObject timer;
	TimerCtrl timerCtrl;


	#endregion

	#region: PRIVATE VARIABLES
	string dataFilePath;
	BinaryFormatter bf;

	#endregion


	#region: MONOBEHAVIOR METHODS

	void Awake(){
		if( instance== null){
			
			instance = this;
			bf = new BinaryFormatter ();
			dataFilePath=Application.persistentDataPath +"/Game.bat";
		}
	}

	// Use this for initialization
	void Start () {
		
		timerCtrl = timer.GetComponent<TimerCtrl> ();
		
	}
		
	void OnEnable(){
		LoadData ();
		
	}

	void OnDisable(){

		SaveData ();
		
	}
	#endregion


	#region: PUBLIC METHODS

	public void SaveData(){
		FileStream fs = new FileStream (dataFilePath,FileMode.Create);
		bf.Serialize (fs,data);
		fs.Close ();
	}

	public void LoadData(){
		if(File.Exists(dataFilePath)){
			FileStream fs = new FileStream (dataFilePath,FileMode.Open);
			data = (GameData)bf.Deserialize (fs);
			ui.scoreText.text = "" + data.score +" /45";
			fs.Close ();
		}
	}

	public void ResetData(){
		FileStream fs = new FileStream (dataFilePath,FileMode.Create);
		data.score = 0;
		ui.scoreText.text = "" + data.score +" /45";
		bf.Serialize (fs,data);
		fs.Close ();

	}

	public void UpdateScore(){
		data.score += 5;
		ui.scoreText.text = "" + data.score +" /45";
	}
	public void MinesScore(){
		data.score -= 5;
		ui.scoreText.text = "" + data.score +" /45";
	}
		
	public void Win(){
		tvProgramAudio.SetActive (false);
		winPanel.gameObject.SetActive (true);
		ui.finalScoreText.text = "" + data.score+" /45";
		timerCtrl.enabled = false; 
		GameObject[] c = GameObject.FindGameObjectsWithTag ("Element");
		for (int i = 0; i < c.Length; i++) {
			c [i].gameObject.GetComponent<Collider2D> ().enabled = false;
		}
		Camera.main.GetComponent<PlayerCtrl> ().enabled = false;
	
	}

	public void GameOver(){
		tvProgramAudio.SetActive (false);
		gameOverPanel.gameObject.SetActive (true);
		ui.gameOverfinalScoreText.text = "" + data.score+" /45";
		timerCtrl.enabled = false; 
		GameObject[] c = GameObject.FindGameObjectsWithTag ("Element");
		for (int i = 0; i < c.Length; i++) {
			c [i].gameObject.GetComponent<Collider2D> ().enabled = false;
		}
		Camera.main.GetComponent<PlayerCtrl> ().enabled = false;
	}

	public void CheckScore(){
		if (data.score < 45 && timerCtrl.health <=0) {
			GameOver ();
		} else if(data.score >= 45 && timerCtrl.health >=0){
			Win ();
		}
	}


	#endregion


		
}



		


