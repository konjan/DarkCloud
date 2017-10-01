using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGen : MonoBehaviour {
	
	public GameObject Entrance;
	public GameObject Exit;

	public float BlockDistance = 4.0f;

	public int REMOVERoomCount = 4;

	public List<GameObject> Rooms;

	public Vector2 Grid = new Vector2(15, 15);

	// Use this for initialization
	void Start ()
	{
		int roomCount = Random.Range(4, 8);

		GameObject.Instantiate(Entrance);
		Entrance.transform.position = new Vector3(Random.Range(3, 3) * BlockDistance, 0, Random.Range(3, 3) * BlockDistance);
		Entrance.transform.RotateAround(Entrance.transform.position, Vector3.up, 90 * (int)Random.Range(0, 4));

		do
		{
			CreateRoom();
			REMOVERoomCount -= 1;
		} while (REMOVERoomCount > 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	bool CheckRoom(GameObject testRoom, int roomcount)
	{
		if(testRoom.GetComponent<RoomData>().Exits.Count <= roomcount)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void CreateRoom()
	{
		int height = (int)Random.Range(3, 4.9f);
		int width = (int)Random.Range(3, 4.9f);

		GameObject tempRoom = GameObject.CreatePrimitive(PrimitiveType.Cube);
		tempRoom.transform.localScale = new Vector3(width * BlockDistance, 1, height * BlockDistance);
		tempRoom.transform.position = RandomPosition(height, width);
		tempRoom.AddComponent<RoomData>();
		RoomData tempRoomData = tempRoom.GetComponent<RoomData>();
		tempRoomData.SetHW(height, width);
		tempRoomData.Pos = tempRoom.transform.position;

		//for (int i = 0; i < Rooms.Count; i++)
		//{
		//	if (tempRoomData.Intersect(tempRoomData, Rooms[i].GetComponent<RoomData>()))
		//	{
		//		tempRoom.transform.position = RandomPosition(tempRoomData);
		//		tempRoomData.Pos = tempRoom.transform.position;
		//
		//		i = 0;
		//	}
		//}

		Rooms.Add(tempRoom);
	}

	void ChooseDoor(RoomData room)
	{

	}

	Vector3 RandomPosition(int h, int w)
	{
		Vector3 tempPos = new Vector3();
		tempPos.x = (int)Random.Range(0, Grid.x - w) * BlockDistance;
		tempPos.z = (int)Random.Range(0, Grid.y - h) * BlockDistance;

		return tempPos;
	}
	Vector3 RandomPosition(RoomData rd)
	{
		Vector3 tempPos = new Vector3();
		tempPos.x = (int)Random.Range(0, Grid.x - rd.m_fWidth) * BlockDistance;
		tempPos.z = (int)Random.Range(0, Grid.y - rd.m_fHeight) * BlockDistance;

		return tempPos;
	}

	//Vector3 GridPosition(Grid )
}
