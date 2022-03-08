using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMarker : MonoBehaviour
{
    public Sprite compassIcon;
    public Image image; 

    //returns the transformed position of the quest marker as a vector
    public Vector2 position
    {
        get { return new Vector2(transform.position.x, transform.position.z); }
    }  
}
