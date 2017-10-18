using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructPiece : MonoBehaviour {

	private bool isActive = false;

	public List<GameObject> PlacementGrids;
	private GameManager m_GM;
	private GameObject Player;

	public int SnapSize = 5;

	private Collider m_cCollider;

	// Use this for initialization
	void Start ()
	{
		m_cCollider = this.GetComponent<Collider>();
		m_GM = GameObject.Find("GameManager").GetComponent<GameManager>();
		Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isActive == true)
		{
			if (m_GM.GameMode == Mode.BuildMode)
			{
				Vector3 ppos = Player.transform.position;
				this.transform.position = new Vector3(Mathf.Round((ppos.x) / SnapSize) * SnapSize, transform.position.y, Mathf.Round((ppos.z) / SnapSize) * SnapSize);

				if (Input.GetButtonDown("RTrigger"))
					this.transform.RotateAround(transform.position, Vector3.up, 90);
				else if (Input.GetButtonDown("LTrigger"))
					this.transform.RotateAround(transform.position, Vector3.up, -90);

				//Resets the isActive bool
				if (Input.GetButtonDown("BButton"))
					isActive = false;
			}
			else if (m_GM.GameMode == Mode.TownMode)
				isActive = false;

			//REMEMBER TO TURN BACK ON
			///////////////////////////
			///////////////////////////
			//PlacementGridCheck();
			///////////////////////////
			///////////////////////////
		}
	}

	void OnTriggerStay(Collider coll)
	{
		if(coll.name == "Player" && m_GM.GameMode == Mode.BuildMode)
		{
			if(Input.GetButtonDown("AButton"))
				isActive = true;
		}
	}

	public bool PlacementGridCheck()
	{
		foreach(GameObject PG in PlacementGrids)
		{
			Collider testCollider = PG.GetComponent<Collider>();

			if (testCollider.bounds.Contains(m_cCollider.bounds.min) && testCollider.bounds.Contains(m_cCollider.bounds.max))
			{
				return true;
			}
		}
		
		//make invis
		return false;
	}
}
