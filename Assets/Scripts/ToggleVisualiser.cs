using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ToggleVisualiser script: This script is used to toggle the
//visualiser ON and OFF within the settings menu.
public class ToggleVisualiser : MonoBehaviour
{
	//setting up variables to be filled in the Unity inspector
	Toggle getToggle;
    public GameObject visualiser;

	void Start()
	{
		//fetch the toggle
		getToggle = GetComponent<Toggle>();
		//listen for when state of the tottle changes and call changer method
		getToggle.onValueChanged.AddListener(delegate { ToggleChange(getToggle); });
		
	}

	void ToggleChange(Toggle change)
	{
		//set the setting game object on and then off for each click of the toggle
		visualiser.gameObject.SetActive(!visualiser.activeSelf);
    }
}
