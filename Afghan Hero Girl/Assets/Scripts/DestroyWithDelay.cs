using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys host gameobject with specified delay eg. bullets
/// </summary>
public class DestroyWithDelay : MonoBehaviour
{
	// how long to wait before destroying gameobject
	public float delay;		

	void Start () 
	{
		Destroy(gameObject, delay);
	}

}
