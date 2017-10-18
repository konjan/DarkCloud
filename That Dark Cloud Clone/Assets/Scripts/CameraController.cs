using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject MainCharacter;

	private GameManager m_GM;

	public float m_fTMD = 7.0f;
	public Vector2 m_v2BMD = new Vector2(20, 10);

	private Vector3 Direction;

	private float rotationX = 0;
	private float rotationY = 0;

	private Vector3 Sensitivity = new Vector3(4.0f, 1.0f, 1.0f);

	// Use this for initialization
	void Start ()
	{
		m_GM = GameObject.Find("GameManager").GetComponent<GameManager>();
		Direction = new Vector3(0, 0, -m_fTMD);
		transform.position = MainCharacter.transform.forward.normalized + Direction;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Select"))
			ModeSwitch();
		RotationUpdate();
	}

	private void RotationUpdate()
	{
		rotationX -= Input.GetAxis("RightHorizontal") * Sensitivity.x;
		if(m_GM.GameMode == Mode.TownMode)
			rotationY -= Input.GetAxis("RightVertical") * Sensitivity.y;

		rotationY = Mathf.Clamp(rotationY, 4, 55);
		Quaternion Rotation = Quaternion.Euler(rotationY, rotationX, 0);
		transform.position = Vector3.Lerp(transform.position, MainCharacter.transform.position + Rotation * Direction, 20);

		//-----Lookat Player position
		transform.LookAt(MainCharacter.transform.position);
	}

	private void ModeSwitch()
	{
		if (m_GM.GameMode == Mode.TownMode)
		{
			m_GM.GameMode = Mode.BuildMode;
			Direction = new Vector3(0, m_v2BMD.x, -m_v2BMD.y);
		}
		else if (m_GM.GameMode == Mode.BuildMode)
		{
			m_GM.GameMode = Mode.TownMode;
			Direction = new Vector3(0, 0, -m_fTMD);
		}
	}
}
