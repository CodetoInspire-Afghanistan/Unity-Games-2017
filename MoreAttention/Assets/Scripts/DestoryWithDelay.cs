using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryWithDelay : MonoBehaviour {

	public float destroyDelay;


	// Update is called once per frame
	void Update () {

		Destroy(gameObject,destroyDelay);
	}
}
