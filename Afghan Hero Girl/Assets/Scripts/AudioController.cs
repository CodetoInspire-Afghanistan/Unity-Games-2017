using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	public static AudioController instance;
	public PlayerAudio playeraudio;
	public Transform player;
	[Tooltip("Use On/Off the audio of the game from inspector")]
	public bool soundon;
	// Use this for initialization
	void Start () {
		if (instance == null) {

			instance = this;
		}
	}

	public void PlayerJump(Vector3 playerPos){
		if (soundon) {
			AudioSource.PlayClipAtPoint (playeraudio.playerJump,playerPos);
		}
	}
	public void GemPickUp(Vector3 playerPos){
		if (soundon) {
			AudioSource.PlayClipAtPoint (playeraudio.Gempickup,playerPos);
		}
	}
	public void FireBullet(Vector3 playerPos){
		if (soundon) {
			AudioSource.PlayClipAtPoint (playeraudio.playerBullet,playerPos);
		}
	}
	public void KeyFound(Vector3 playerPos){
		if (soundon) {
			AudioSource.PlayClipAtPoint (playeraudio.keyfound,playerPos);
		}
	}
	public void EnemyHit(Vector3 playerPos){
		if (soundon) {
			AudioSource.PlayClipAtPoint (playeraudio.enemyHit,playerPos);
		}
	}
	public void PlayerDie(Vector3 playerPos){
		if (soundon) {
			AudioSource.PlayClipAtPoint (playeraudio.playerDie,playerPos);
		}
	}
	public void MagicBottle(Vector3 playerPos){
		if (soundon) {
			AudioSource.PlayClipAtPoint (playeraudio.magicBottle,playerPos);
		}
	}
	public void SavingServitor(Vector3 playerPos){
		if (soundon) {
			AudioSource.PlayClipAtPoint (playeraudio.savingServitor,playerPos);
		}
	}
	public void PirestBullet(Vector3 playerPos){
		if (soundon) {
			AudioSource.PlayClipAtPoint (playeraudio.pirestBullet,playerPos);
		}
	}

}
