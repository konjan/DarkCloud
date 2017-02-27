using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Movement : MonoBehaviour {

	private Rigidbody rb;
	//public Animator anim;
	public AnimationCurve speedCurve;
	public float accerateTime = 1.0f;

	private float speedModifier = 0.1f;
	private Vector3 previousDirection = Vector3.zero;
	private float currentAccelerateTime = 0.0f;
	private bool isMoving;
	private Quaternion desiredDir;

	private Quaternion previousPlayerCameraDirection = Quaternion.identity;
	private float controlLockTimer;
	private bool controlLockTimerActive = false;

	public float DefaultControlLockTime = 0.05f;

	// Use this for initialization
	void Start () {
		//anim = gameObject.GetComponent<Animator>();
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//anim.SetFloat("Movement", Input.GetAxis("LeftVertical"));
	}

	void FixedUpdate()
	{
		FreeMovement();
	}

	void FreeMovement()
	{
		Vector3 cameraForward = Camera.main.transform.forward;
		cameraForward.y = 0.0f; cameraForward.Normalize();

		Vector3 inputDirection = new Vector3(-Input.GetAxis("LeftVertical"), 0, Input.GetAxis("LeftHorizontal"));

		if (inputDirection.magnitude > 0.1f)
		{
			inputDirection.Normalize();
			desiredDir = Quaternion.LookRotation(inputDirection, Vector3.up);

			Quaternion CameraDirection = Quaternion.LookRotation(cameraForward, Vector3.up);
			Quaternion controlRotationModifier = CameraDirection;

			if (controlLockTimerActive)
			{
				controlRotationModifier = previousPlayerCameraDirection;
				controlLockTimer -= Time.deltaTime;
				if (controlLockTimer < 0.0f)
				{
					controlLockTimerActive = false;
					previousPlayerCameraDirection = Quaternion.identity;

				}
			}
			else
			{
				if (previousPlayerCameraDirection == Quaternion.identity)
				{
					previousPlayerCameraDirection = CameraDirection;
				}

				float fDot = Quaternion.Dot(previousPlayerCameraDirection, CameraDirection);
				if (fDot < 0.8f)
				{
					controlLockTimerActive = true;
					controlLockTimer = DefaultControlLockTime;
					controlRotationModifier = previousPlayerCameraDirection;
				}
				else
				{
					previousPlayerCameraDirection = CameraDirection;
				}
			}

			desiredDir = controlRotationModifier * desiredDir;


			Vector3 forwardOffset = controlRotationModifier * new Vector3(0, 0, 1) * Input.GetAxis("LeftVertical") * 5 * Time.deltaTime;
			Vector3 rightOffset = controlRotationModifier * new Vector3(-1, 0, 0) * -Input.GetAxis("LeftHorizontal") * 5 * Time.deltaTime;

			//-----Move Player in the direction of the joystick input
			Vector3 moveDir = forwardOffset + rightOffset;
			moveDir.Normalize();

			float dot = Vector3.Dot(moveDir, previousDirection);
			previousDirection = moveDir;

			if (dot > 0.7f)
			{
				currentAccelerateTime += Time.deltaTime;
				float alpha = currentAccelerateTime / accerateTime;

				speedModifier = speedCurve.Evaluate(alpha);
			}
			else
			{
				currentAccelerateTime = 0.0f;
			}

			//-----Move Player in the desired direction
			rb.MovePosition(rb.transform.position + (forwardOffset + rightOffset) * speedModifier);

			//-----Rotate Player towards desired Joystick direction
			rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, desiredDir, 750 * Time.deltaTime);
		}
	}
}
