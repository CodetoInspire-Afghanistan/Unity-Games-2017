using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
/// <summary>
/// Managing the GamePLAY features like keeping the score,
/// restarting levels, Saving ,Loading data .updating the HUD etc..
/// </summary>
public class GameCtrl : MonoBehaviour {

	public static GameCtrl instance;
	public GameData data;
	public GameObject another;
	private GameObject player;
	public GameObject currentCheckPoint;
	public GameObject platform;
	public GameObject door;
	public GameObject diedCollider;
	public Transform pos1,pos2,pos3;

	public int gemValue;
	public int magicBottleValue;
	public int EnemyValue;

	public bool canOpenDoor;
	public bool showPlatform;
	public bool soundOn;

	public float restartDelay;
	public float MaxTime;
	float TimeLeft;

	BinaryFormatter bf;

	string dataFilePath;

	public UI ui;
	bool timeOver;

	public enum Item
	{
		Gem,
		MagicBottle,
		Enemy
	}
		
	void Awake(){
		if (instance == null) {
			instance = this;
			bf = new BinaryFormatter ();
			dataFilePath = Application.persistentDataPath + "/game.bat";

		}
	}

	// Use this for initialization
	void Start () {
		soundOn = true;
		player = GameObject.FindGameObjectWithTag ("Player") as GameObject;
		diedCollider.GetComponent<Collider2D> ().enabled = false;
		//data.lives = 3;
		UpdateHearts ();
		TimeLeft = MaxTime;

		
	}
	
	// Update is called once per frame
	void Update () {

		if (TimeLeft > 0)
			UpdateTimer ();


		if(Input.GetKeyDown(KeyCode.Escape)){
			ResetData ();
		}
	}

	void SaveData(){
		FileStream fs = new FileStream (dataFilePath,FileMode.Create);
		bf.Serialize (fs,data);
		fs.Close ();
	}

	void LoadData(){
		if(File.Exists(dataFilePath)){
			FileStream fs = new FileStream (dataFilePath,FileMode.Open);
			data = (GameData)bf.Deserialize (fs);
			ui.gemText.text = "X " + data.gemCounter;
			ui.sodierText.text = "" + data.soldeirCounter;
			ui.magicBottleText.text=""+data.magicBottleCounter;
			ui.magicBottleText.text = "X " + data.magicBottleCounter;
			ui.totalGemText.text = "   " + data.gemCounter;
			ui.totalMagicBottleText.text = "   " + data.magicBottleCounter;
			fs.Close ();
		}
	}

	void OnEnable(){
		LoadData ();
	}
		
	void OnDisable(){
		SaveData ();
	}	
	public void BulletHitEnemy(Transform enemy){
		Vector3 pos = enemy.position;
		pos.z = 20f;
		Destroy (enemy.gameObject);
	}
	public void UpdateMagicBottleCount(){
		data.magicBottleCounter += 1;
		ui.magicBottleText.text = "X " + data.magicBottleCounter;
		ui.totalMagicBottleText.text = "   " + data.magicBottleCounter;


	}
	public void LessMagicBottle_Servitor(){
		data.magicBottleCounter -= 1;
		ui.magicBottleText.text = "X " + data.magicBottleCounter;
		ui.totalMagicBottleText.text = "   " + data.magicBottleCounter;
		data.soldeirCounter -= 1;
		ui.sodierText.text= ""+data.soldeirCounter;


	}

	public void FireBottle(){
		data.magicBottleCounter -= 1;
		ui.magicBottleText.text = "X " + data.magicBottleCounter;
		ui.totalMagicBottleText.text = "   " + data.magicBottleCounter;
	


	}

	void ResetData(){

		FileStream fs = new FileStream (dataFilePath,FileMode.Create);

		data.gemCounter = 0;
		//data.Score = 0;
		ui.gemText.text= "X 0";
		data.magicBottleCounter = 0;
		ui.magicBottleText.text = "X 0";
		data.soldeirCounter = 10;
		ui.sodierText.text = "10";
		data.lives = 3;
		UpdateHearts ();
		bf.Serialize (fs,data);
		fs.Close ();
	}
	public void UpdateGemCount(){
		data.gemCounter += 1;
		ui.gemText.text = "X " + data.gemCounter;
		ui.totalGemText.text = "   " + data.gemCounter;
	}
	public void UpdateSoldeirCount(){
		data.soldeirCounter -= 1;
		ui.sodierText.text = " " + data.soldeirCounter;
		ui.totalsodierText.text= "   " + data.soldeirCounter;
	}

	public void UpdateScore(Item item){
		int itemVlaue = 0;
		switch (item) {
		case Item.Gem:
			itemVlaue = gemValue;
			break;
		case Item.MagicBottle:
			itemVlaue = magicBottleValue;
			break;
		case Item.Enemy:
			itemVlaue = EnemyValue;
			break;
		default:
			break;
		}

		data.Score += itemVlaue;
	
	}

	void UpdateTimer(){
		TimeLeft -= Time.deltaTime;
		ui.timerText.text=" "+(int)TimeLeft;

		if (TimeLeft <= 0) {
			ui.timerText.text = "Timer: 0";
			GameOver ();
		}
	}

//	timeLeft -= Time.deltaTime;
//	ui.textTimer.text = " Timer : " + (int)timeLeft;
//
//	if(timeLeft <=0){
//		ui.textTimer.text = " Timer : 0";
//		GameObject player = GameObject.FindGameObjectWithTag ("Player") as GameObject;
//		PlayerDied (player);
//	}

	void UpdateHearts(){

		if (data.lives == 3) {
			ui.heart1.sprite = ui.fullHeart;
			ui.heart2.sprite = ui.fullHeart;
			ui.heart3.sprite = ui.fullHeart;
		}
		if (data.lives == 2) {
			ui.heart1.sprite = ui.emptyHeart;

		}
		if (data.lives == 1) {
			ui.heart1.sprite = ui.emptyHeart;
			ui.heart2.sprite = ui.emptyHeart;
		}

	}



	void CheckLives(){
		int updateLive = data.lives;

		if (data.lives > 0) {
			updateLive -= 1;
			data.lives = updateLive;

		}
		if (data.lives == 0) {
			data.lives = 3;
			SaveData ();
			Invoke ("GameOver",0.1f);

		} else {
			UpdateHearts ();
			SaveData ();
			RespawnPlayer ();

	}
}

	void RestartLevel(){
		SceneManager.LoadScene (0);
	}
	void GameOver(){
		if (timeOver && data.lives > 0) {
			ui.heart1.sprite = ui.emptyHeart;
			ui.heart2.sprite = ui.emptyHeart;
			ui.heart3.sprite = ui.emptyHeart;
			ui.GameOverPanel.SetActive (true);
			ResetData ();
			player.SetActive (false);
		} else {
//		data.magicBottleCounter = 0;
//		ui.magicBottleText.text = "" + data.magicBottleCounter;
			ui.heart3.sprite = ui.emptyHeart;
			ui.GameOverPanel.SetActive (true);
			ResetData ();
			player.SetActive (false);
		}

	}

	public void PlayerDied(GameObject other){
		
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		player.GetComponent<Animator> ().SetInteger ("State",5);
		player.GetComponent<BoxCollider2D> ().enabled = false;
		player.GetComponent<PlayerCtrl> ().enabled = false;


		diedCollider.GetComponent<Collider2D> ().enabled = true;
		Invoke ("CheckLives",restartDelay);


	}


	public void stopCameraFollow(){
		Camera.main.GetComponent<CameraCtrl>().enabled = false;
		player.GetComponent<PlayerCtrl> ().isStuck = true;
		player.transform.Find ("LeftCheck").gameObject.SetActive(false);
		player.transform.Find ("RightCheck").gameObject.SetActive (false);
	}

	public void RespawnPlayer(){
		
		player.GetComponent<Animator> ().SetInteger ("State",0);
		player.transform.position = currentCheckPoint.transform.position;
		player.GetComponent<PlayerCtrl> ().enabled = true;
		player.GetComponent<Collider2D> ().enabled = true;
		diedCollider.GetComponent<Collider2D> ().enabled = false;

	}
	public void OpenDoor(){
		SFXCtrl.instance.DoorEffect (door.transform.position);
		door.GetComponent<Animator> ().enabled=true;
		Invoke ("StopDoorOpening",1.8f);

		
	}
	public void StopDoorOpening(){
		door.GetComponentInParent<Collider2D> ().enabled = true;
		door.gameObject.SetActive (false);
	
	}

	public void LevelComplete(){
		ui.LevelCompletePanel.SetActive (true);

	}
	public void PauseButton(){
		Time.timeScale = 0f;
		ui.pausePanel.SetActive (true);
	}
	public void ResumeButton(){
		Time.timeScale = 1f;
		ui.pausePanel.SetActive (false);
	}
	public void SoundOff(){
		if (soundOn) {
			Camera.main.GetComponent<AudioListener> ().enabled = false;
			ui.SoundOff.image.sprite = ui.img_SoundOff;
			soundOn = false;
		} else {
			Camera.main.GetComponent<AudioListener> ().enabled = true;
			ui.SoundOff.image.sprite = ui.img_SoundOn;
			soundOn = true;
		}
	
	}

}
