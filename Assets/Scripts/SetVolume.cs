using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//SetVolume script:
//This script allows for the user control of volume across the application
//Allows player to use the toggle change volume
public class SetVolume : MonoBehaviour
{
    //setting up variables to be filled in the Unity inspector
    public AudioMixer mixer; //allows us to choose which mixer to adapt the volume
    public Slider slider; //allows foe the selection of a specific slider

    void Start()
    {
        //sets a default value for the slider
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public void SetLevel()
    {
      
        float sliderValue = slider.value;   //recieve slider value
        //pass the slider value and convert using base 10 log function
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20); 
        //saves the volume of the slider when its changed
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}