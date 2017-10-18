using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode
{
	TownMode,
	BuildMode,
	DungeonMode
}

public class GameManager : MonoBehaviour {

	public Mode GameMode = Mode.TownMode;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ModeSwitch(Mode M)
	{
		GameMode = M;
	}
}
