using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// provide parallax effects .
/// </summary>

public class Parallax : MonoBehaviour {

	public float speed;
	float offsetX;
	Material mat;
	PlayerCtrl plCtrl;
	public GameObject player;

	// Use this for initialization
	void Start () {

		mat = gameObject.GetComponent<Renderer> ().material;
		plCtrl = player.GetComponent<PlayerCtrl> ();
	}

	// Update is called once per frame
	void Update () {
		if(!plCtrl.isStuck){
			if (plCtrl.isMoveLeft)
				offsetX += -speed;
			else if (plCtrl.isMoveRight)
				offsetX += speed;

			offsetX += Input.GetAxisRaw ("Horizontal") * speed;
			mat.SetTextureOffset ("_MainTex",new Vector2(offsetX,0));

		}
	}
}
