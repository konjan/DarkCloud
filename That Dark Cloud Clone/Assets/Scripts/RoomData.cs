using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour {

	public List<GameObject> Exits;
	public int m_fHeight, m_fWidth;
	public Vector3 Pos = new Vector3();

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SetHW(int height, int width)
	{
		m_fHeight = height;
		m_fWidth = width;
	}

	public bool Intersect(RoomData A, RoomData B)
	{
		if ((A.Pos.x + A.m_fWidth + 1 < B.Pos.x || A.Pos.x > B.Pos.x + B.m_fWidth + 1)
		&& (A.Pos.y + A.m_fHeight + 1 < B.Pos.y || A.Pos.y > B.Pos.y + B.m_fHeight + 1))
			return false;
		else
			return true;
	}
}
