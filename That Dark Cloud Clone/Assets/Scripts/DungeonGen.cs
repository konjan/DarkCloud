using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGen : MonoBehaviour
{ 
	public float BlockDistance = 1.0f;
	public int REMOVEroomcount;

	public Vector2 GridSize = new Vector2(15, 15);
	public GameObject GridSect;

	// Use this for initialization
	void Start ()
	{
		REMOVEroomcount = Random.Range(4, 7);

		//Setup the grid and setthe colours
		GridSetup();

		for(int i = 0; i < REMOVEroomcount; i++)
			CreateRoom();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	private void GridSetup()
	{
		for (int i = 0; i < GridSize.x; i++)
		{
			for (int j = 0; j < GridSize.y; j++)
			{
				//getting the modulus if the index to use for the grid colour
				int k = (i + j) % 2;
				
				GameObject G = Resources.Load("GridSect") as GameObject;

				G.name = ("Grid" + i + "//" + j);

				GridSection TempAccess = G.GetComponent<GridSection>();
				TempAccess.TileSection = k;

				GameObject.Instantiate(G, new Vector3(i, 0, j), Quaternion.identity);
			}
		}
	}

	public void CreateRoom()
	{

		Vector2 tempSize = new Vector2(Random.Range(3, 5), Random.Range(3, 5));

		Vector2 tempPos = GenerateTempPos(tempSize.x, tempSize.y);

		for (int i = (int)tempPos.x; i < (int)(tempPos.x + tempSize.x); i++)
		{
			for (int j = (int)tempPos.y; j < (int)(tempPos.y + tempSize.y); j++)
			{
				GameObject GO = GameObject.Find("Grid" + i + "//" + j + "(Clone)");

				if (GO.GetComponent<GridSection>().isActive == false)
					GO.GetComponent<GridSection>().isActive = true;
			}
		}

	}

	//Generates a Vector 2 to replicate the position of the room within the grid.
	private Vector2 GenerateTempPos(float xSize, float ySize)
	{
		Vector2 pos = new Vector2(Random.Range(0, GridSize.x - xSize), Random.Range(0, GridSize.y - ySize));

		for(int i = (int)pos.x; i <= (int)(pos.x + xSize); i++)
		{
			for(int j = (int)pos.y; j <= (int)(pos.y + ySize); j++)
			{
				if (GameObject.Find("Grid" + i + "//" + j + "(Clone)").GetComponent<GridSection>().isActive)
					break;
			}
		}

		return pos;
	}
}