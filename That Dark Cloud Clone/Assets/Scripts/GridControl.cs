using UnityEngine;
using System.Collections;

public class GridControl : MonoBehaviour {

	Vector3 newPos;
	// Use this for initialization
	void Start ()
	{
		newPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("LR") || Input.GetButtonDown("FB"))
			newPos += new Vector3((int)Input.GetAxis("LR"), 0, (int)Input.GetAxis("FB"));
		
		if(this.transform.position != newPos)
			this.transform.position = Vector3.Lerp(this.transform.position, newPos, 10);

		if (Input.GetKeyDown("e"))
			this.transform.RotateAround(transform.position, Vector3.up, 90);
		else if (Input.GetKeyDown("q"))
			this.transform.RotateAround(transform.position, Vector3.up, -90);
	}
}
