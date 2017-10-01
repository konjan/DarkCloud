using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCamera : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		transform.LookAt(new Vector3(4.5f, 0, 4.5f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
