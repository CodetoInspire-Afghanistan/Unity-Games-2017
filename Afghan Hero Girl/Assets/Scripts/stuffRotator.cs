using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuffRotator : MonoBehaviour {

    public float rotationSpeed;
	Rigidbody2D rb;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D> ();

		rb.bodyType = RigidbodyType2D.Dynamic;
    }
		
}
