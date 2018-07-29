using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

	MovingPlatWithDelay dp;
    public GameObject topHinder;
	// Use this for initialization
	void Start () {
		dp=topHinder.GetComponent<MovingPlatWithDelay>();
        dp.enabled=false;
	}

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            dp.enabled=true;
        }
    }

}
