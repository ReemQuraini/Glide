using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour {
	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minLoadTime= 3.0f;
																																			
	// Use this for initialization
	private void Start () {
		fadeGroup = FindObjectOfType<CanvasGroup> ();

		fadeGroup.alpha = 1f;

		if (Time.time < minLoadTime) {
			loadTime = minLoadTime;
		} else {
			loadTime = Time.time;
		}
	}

	private void Update()
	{
		if (Time.time < minLoadTime) {
			fadeGroup.alpha = 1 - Time.time;
		} 
		if(Time.time>minLoadTime && loadTime!=0){
			fadeGroup.alpha = Time.time - minLoadTime;
			if (fadeGroup.alpha>=1){
				SceneManager.LoadScene ("mainMenu");
			}
		}
	}
	

}
