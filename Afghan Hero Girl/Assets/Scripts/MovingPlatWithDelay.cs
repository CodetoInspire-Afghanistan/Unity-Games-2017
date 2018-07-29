using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatWithDelay : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    public Transform pos1 , pos2,startPos;
    Vector3 nextPos;

    // Use this for initialization
    void Start () {
        rb = GetComponent <Rigidbody2D> ();
        nextPos = startPos.position;

    }

    // Update is called once per frame
    void Update () {
        if(transform.position==pos1.position){
            nextPos = pos2.position;
        }else if(transform.position==pos2.position){

            StartCoroutine ("stopMoving");
            
        }

        transform.position=	Vector3.MoveTowards (transform.position,nextPos,speed*Time.deltaTime);
    }

    IEnumerator stopMoving(){
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds (1);
        nextPos=pos1.position;

    }
}
