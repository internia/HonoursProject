using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorrorPortalScript : MonoBehaviour
{

    //public GameObject scene;
    public AudioSource BGaudio;

    void OnTriggerEnter()
    {
        Debug.Log("hit");
        BGaudio.Pause();
        SceneManager.LoadScene("HorrorScene");

    }
}
