using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSection : MonoBehaviour {

	public bool isActive = false;
	public List<GameObject> Tiles;

	public int TileSection = 0;
	// Use this for initialization
	void Start ()
	{
		Tiles = new List<GameObject>();

		foreach(Transform child in transform)
		{
			Tiles.Add(child.gameObject);
			child.gameObject.SetActive(false);
		}

		TileSection = ((int)transform.position.x + (int)transform.position.z) % 2;
		Tiles[TileSection].SetActive(true);

	}
	
	// Update is called once per frame
	void Update ()
	{
		TileCheck();
	}

	private void TileCheck()
	{
		if (isActive && !Tiles[2].activeSelf)
		{
			Tiles[TileSection].SetActive(false);
			Tiles[2].SetActive(true);
		}
		else if (!isActive && !Tiles[TileSection].activeSelf)
		{
			Tiles[TileSection].SetActive(true);
			Tiles[2].SetActive(false);
		}
	}
}
