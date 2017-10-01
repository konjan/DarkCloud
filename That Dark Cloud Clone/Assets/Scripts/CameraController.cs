using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject MainCharacter;

	private Vector3 Direction = new Vector3(0, 0, -5);

	public float rotationX = 0;
	public float rotationY = 0;

	public Vector3 Sensitivity = new Vector3(4.0f, 3.0f, 1.0f);

	// Use this for initialization
	void Start ()
	{
		transform.position = MainCharacter.transform.forward.normalized + Direction;
	}
	
	// Update is called once per frame
	void Update ()
	{
		RotationUpdate();
	}

	private void RotationUpdate()
	{
		rotationX -= Input.GetAxis("RightHorizontal") * Sensitivity.x;
		rotationY += Input.GetAxis("RightVertical") * Sensitivity.y;

		rotationY = Mathf.Clamp(rotationY, 4, 55);
		Quaternion Rotation = Quaternion.Euler(rotationY, rotationX, 0);
		transform.position = MainCharacter.transform.position + Rotation * Direction;

		//-----Lookat Player position
		transform.LookAt(MainCharacter.transform.position);
	}
}
