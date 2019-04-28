using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{

	public GameObject[] level;
	GameObject[] plats;
	Actions acts;
	
	

	void Start () 
	{
		StaticVars.curLevel--;
		NextLevel();
	}
	
	public void NextLevel()
	{
		StaticVars.curLevel++;
		
		if(PlayerPrefs.GetInt("Level")<StaticVars.curLevel)
			PlayerPrefs.SetInt("Level", StaticVars.curLevel);
		
		
		plats = GameObject.FindGameObjectsWithTag("Plats");
		
		foreach (GameObject plat in plats)
        {
			Destroy(plat);
        }
		
		
		
		for(int i=0;i<level.Length;i++)
		{
			
			if(StaticVars.curLevel==level.Length)
			{
				SceneManager.LoadScene("Menu", LoadSceneMode.Single);
			}
			
			if(i!=StaticVars.curLevel)
				level[i].SetActive(false);
			else
			{
				level[i].SetActive(true);
				acts = GameObject.FindWithTag("Player").GetComponent<Actions>();
				acts.flasksAllowed = level[i].GetComponent<FlasksAllowed>().flask;
				acts.FlasksGpxs();
				acts.SetBar();
				acts.SetHp(100);
			}
		}
	}

}
