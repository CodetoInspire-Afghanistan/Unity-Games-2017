using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthBar : MonoBehaviour {
	public GameObject levelOneBoss;
	Image healthbar;
	float maxHealth = 100f;
	public static float health;


	void Awake(){
		levelOneBoss = GameObject.FindGameObjectWithTag ("LevelOneBoss") as GameObject;
	}
	// Use this for initialization
	void Start () {

		healthbar = GetComponent<Image> ();
		health = maxHealth;

	}

	// Update is called once per frame
	void Update () {

		healthbar.fillAmount = health / maxHealth;

		if (health <=0) {
			GameCtrl.instance.canOpenDoor=true;
			Destroy (levelOneBoss);
			SFXCtrl.instance.BossEffect (levelOneBoss.transform.position);
		}

	}
}
