using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class SaveManager : MonoBehaviour {

	public static SaveManager Instance { set; get;}

	public SaveState saveState;

	private void Awake(){
		DontDestroyOnLoad (gameObject);
		Instance = this;
		Load ();
	}

	public void Save(){
		PlayerPrefs.SetString ("save",Helper.Serialize<SaveState>(saveState));
	}

	public void Load(){
		if (PlayerPrefs.HasKey ("save")) {
		
			saveState = Helper.Deserlialize<SaveState> (PlayerPrefs.GetString("save")); 
		
		} else {

			saveState = new SaveState ();
			Save ();
		}

	
	}

}
