using UnityEngine;
using System.Collections;

enum CardAttribute
{
	HERO,
	DEMON,
	NULLATT
};

public struct Cost
{
	enum CostType
	{
		SOUL,
		LIFE
	};

	int CostAmount;
	CostType CT;

	void CostResolution()
	{
		if (CT == CostType.LIFE)
		{
			//Life -= CostAmount;
		}
		else if (CT == CostType.SOUL)
		{
			//RemoveSoul(CostAmount);
		}

	}
};

public class Card : MonoBehaviour {

	public CardAbility[] Abilities;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
