using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//WesternPortalScript: This script is used for transporting the player
//when they hit a portal within the scene.
public class WesternPortalScript : MonoBehaviour
{
    //allow audio source to be defined witin the Unity inspector
    public AudioSource BGaudio;

    void OnTriggerEnter()
    {
        Debug.Log("hit");
        //pause the current music when switching scene so tracks dont not overlap
        BGaudio.Pause();
        //switch and load in new scene
        SceneManager.LoadScene("WesternScene");
    }
}
