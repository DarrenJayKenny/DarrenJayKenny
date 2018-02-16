using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("Load Level requested for "+name);
		Application.LoadLevel(name);
	}
	public void QuitRequest(){
		Application.Quit();
	}
	
}