using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonEnabler : MonoBehaviour 
{


	public int l=0;

	void Start () 
	{
		
		if(PlayerPrefs.GetInt("Level")>=l)
			GetComponent<Button>().interactable=true;
		
	}

}
