using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//SettingsClick: This script handles the setting button
//Allowing the player to click once and the menu will display
//Click again and it will return to the scene
public class SettingsClick : MonoBehaviour
{
	//setting up variables to be filled in the Unity inspector
	public Button settingsBtn;
	public GameObject settings;
	
	void Start()
	{
		//get the button component and listen for the player to click
		Button btn = settingsBtn.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	//when the button is clicked
	void TaskOnClick()
	{
		//set the setting game object on and then off for each click
		settings.gameObject.SetActive(!settings.activeSelf);

	}
}