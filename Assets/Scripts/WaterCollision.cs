
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    //setting up game objects and audio
    public GameObject image, particles;
    public AudioSource audio;

    //when the box collider is hit by player
    void OnTriggerEnter()
    {
        Debug.Log ("hit");
        //activate all effects
        image.gameObject.SetActive(true);
        particles.gameObject.SetActive(true);
        audio.Play();
    }

     void OnTriggerExit( )
    {
        //disable all effects
        image.gameObject.SetActive(false);
        particles.gameObject.SetActive(false);
        audio.Stop();
    }
}
