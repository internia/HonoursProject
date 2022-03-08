using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ButtonClick Script:
//this script controls the arrow buttons on the menu
//allowing the user to move back and forth through the pages
public class ButtonClick : MonoBehaviour
{
	//setting up variables to be filled in the Unity inspector
	public Button startBtn;
	public GameObject currentPage, newPage; //variables to handle the pages to switch to


	void Start()
	{
		//fetch button
		Button btn = startBtn.GetComponent<Button>();
		//listen for input
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		//when user clicks a button, set the current page to inactive
		currentPage.gameObject.SetActive(false);
		newPage.gameObject.SetActive(true); //and the destination page to active
	}
}