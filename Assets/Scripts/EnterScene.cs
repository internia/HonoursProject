using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//EnterScene Script
//this script is used to allow the user to enter any scene from the menu
//via the click of a button
public class EnterScene : MonoBehaviour
{
	//setting up variables to be filled in the Unity inspector
	public Button enterBtn;
	public String scene; //allows us to set the scene definition for each scene


	void Start()
	{
		//fetch button
		Button btn = enterBtn.GetComponent<Button>();
		//listen for when the player clicks the button
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		//when the player clicks the button, load the defined scene
		SceneManager.LoadScene(scene);
	}

}
