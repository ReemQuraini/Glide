using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

	private CanvasGroup fadeGroup;

	private float fadeInSpeed = 0.33f;


	public RectTransform menuContainer;
	public Transform levelPanel;

	public Transform colorPanel;
	public Transform trailPanel;


	private Vector3 desiredMenuPosition;

	private void Start () {
		fadeGroup = FindObjectOfType<CanvasGroup> ();

		fadeGroup.alpha = 1f;

	}

	private void initShop()
	{
		if (colorPanel == null || trailPanel == null) {
			Debug.Log ("null colors or trail");
		}

		int i = 0;
		foreach (Transform t in colorPanel) {
			int currentIndex = i;
			Button b = t.GetComponent<Button> ();
			b.onClick.AddListener (() => onColorSelect (currentIndex));
			i++;
		}
		 i = 0;
		foreach (Transform t in trailPanel) {
			int currentIndex = i;
			Button b = t.GetComponent<Button> ();
			b.onClick.AddListener (() => onTrailSelect (currentIndex));
			i++;
		}


	}

	private void initLevel(){
	
		if (levelPanel == null) {
			Debug.Log ("null colors or trail");
		}

		int i = 0;
		foreach (Transform t in levelPanel) {
			int currentIndex = i;
			Button b = t.GetComponent<Button> ();
			b.onClick.AddListener (() => onLevelSelect (currentIndex));
			i++;
		}
	
	}


	private void Update(){
		fadeGroup.alpha =1- Time.timeSinceLevelLoad * fadeInSpeed;

		menuContainer.anchoredPosition3D = Vector3.Lerp (menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);
	}

	private void navigateTo(int menuIndex){
		switch (menuIndex) {

		default:
		case 0:
			desiredMenuPosition = Vector3.zero;
			break;
		case 1:
			desiredMenuPosition = Vector3.right * 1280;
			break;
		case 2:
			desiredMenuPosition = Vector3.left * 1280;
			break;

		}
	}


	//Buttons

	public void onPlayClick()
	{
		navigateTo (1);
	}

	public void onShopClick()
	{
		navigateTo (2); 	
	}

	public void onColorBuy()
	{
	}

	public void onTrailBuy()
	{
	}



	public void onBackClick(){
		navigateTo (0);
	
	}

	public void onLevelSelect(int currentIndex){
	}

	private void onColorSelect(int currentIndex){
	}

	private void onTrailSelect(int currentIndex){
	}
		
}
