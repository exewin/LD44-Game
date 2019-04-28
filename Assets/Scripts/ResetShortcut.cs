using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetShortcut : MonoBehaviour 
{
	
	void Update()
	{
		if(Input.GetKeyDown("r"))
			SceneManager.LoadScene("Game", LoadSceneMode.Single);
	}


}
