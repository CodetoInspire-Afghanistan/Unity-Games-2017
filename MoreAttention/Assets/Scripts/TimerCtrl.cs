using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Health bar.
/// </summary>
public class TimerCtrl : MonoBehaviour {
	
	#region: PRIVATE VARIABLES
	Image healthbar;
	float maxHealth = 100f;
	public float health;
	#endregion

	#region: MONOBEHAVIOR METHODS

	// Use this for initialization
	void Start () {
		healthbar = GetComponent<Image> ();
		health = maxHealth;

	}

	// Update is called once per frame
	void Update () {
		
		health -= (float)Time.deltaTime+0.01f;
		healthbar.fillAmount = health / maxHealth;
		GameCtrl.instance.CheckScore ();

	}
    #endregion


	


}
