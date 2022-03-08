using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public GameObject image;

    void OnTriggerEnter()
    {
        Debug.Log("hit");
        image.gameObject.SetActive(true);
        //particles.gameObject.SetActive(true);
    }

    void OnTriggerExit()
    {
        image.gameObject.SetActive(false);
       // particles.gameObject.SetActive(false);
    }
}
