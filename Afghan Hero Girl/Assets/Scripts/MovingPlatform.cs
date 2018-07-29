using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Transform pos1,pos2;
    public float speed,delay1,delay2;
    Vector3 nextPos;
    public Transform StartPos;
	Rigidbody2D rb;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D> ();
        nextPos = StartPos.position;
    }

    // Update is called once per frame
    void Update () {
        if(transform.position==pos1.position){
			StartCoroutine ("stopMoving");
        }
        if(transform.position==pos2.position){
			StartCoroutine ("stopMoving2");

        }
        transform.position = Vector3.MoveTowards (transform.position, nextPos, speed * Time.deltaTime);

    }

	IEnumerator stopMoving(){
		rb.velocity = Vector2.zero;

		yield return new WaitForSeconds (delay1);
		nextPos = pos2.position;


	}
	IEnumerator stopMoving2(){
		rb.velocity = Vector2.zero;

		yield return new WaitForSeconds (delay2);
		nextPos = pos1.position;


	}

}


