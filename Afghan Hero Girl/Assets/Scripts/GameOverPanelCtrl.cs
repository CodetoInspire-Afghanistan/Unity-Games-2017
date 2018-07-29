﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanelCtrl : MonoBehaviour {

	public Transform targetPos;
	public float speed;

	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.MoveTowards (transform.position, targetPos.position, speed * Time.deltaTime);

	}
		
}


