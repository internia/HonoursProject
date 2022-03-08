using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Compass Script - This script allows for the functionality of the compass UI component, allowing it to move with the player camera around the scene and feature icons 
//indicating the directional position of items. 
public class Compass : MonoBehaviour
{
   
    public RawImage compassImg; //base image for the compass itself
    public Transform player; //position of the player view

    public GameObject prefab; //allows us to use of the prefab created to hold any image placed on the compass
    List<QuestMarker> questMarkers = new List<QuestMarker>(); //list of quest markers necessary for the icons to be loaded into the compass relative to their position on the map

    //setting a maximum distance that the compass will show an item
    float maxDist = 50f; 

    float compassPosition; //holds a unit of screenspace on the compass

    //market icons to be added to the compass
    public QuestMarker coin;
    public QuestMarker crate;
    public QuestMarker potion;

    private void Start()
    {
        //creating a unit of screenspace measurement by dividing the width of the compass by the 360 world view
        compassPosition = compassImg.rectTransform.rect.width / 360f;

        //adding quest markers to the compass
        AddQuestMarker(coin);
        AddQuestMarker(crate);
        AddQuestMarker(potion);
    }

    private void Update()
    {
        //setting coordinate positions for the compass
        //basing the y value on the position of the player camera so it turns as the player looks around the scene
        compassImg.uvRect = new Rect(player.localEulerAngles.y / 360, 0, 1f, 1f);

        foreach(QuestMarker marker in questMarkers)
        {
            //adds an image to each quest marker in the list
            marker.image.rectTransform.anchoredPosition = GetPosition(marker);

            float dist = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), marker.position);
            float scale = 0f;

            if(dist < maxDist)
            {
                scale = 1f - (dist / maxDist);
            }

            marker.image.rectTransform.localScale = Vector3.one * scale;
        }
    }

    /// <summary>
    /// AddQuestMarker
    /// 
    /// this function adds a new quest marker to the list of markers to display in the compass
    /// </summary>
    /// <param name="marker"></param>
    public void AddQuestMarker(QuestMarker marker)
    {
        //when creating a new icon marker, instantiate it to be a child of the compass
        GameObject newMarker = Instantiate(prefab, compassImg.transform);

        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.compassIcon;

        questMarkers.Add(marker);

    }

    /// <summary>
    /// this function is the way to recieve the vector position of a marker respective to the player and calculates how that should be represented on the compass.
    /// </summary>
    /// <param name="marker"></param>
    /// <returns></returns>
    Vector2 GetPosition(QuestMarker marker)
    {
        //get player positions
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        //gets the players direction from a marker on the map by subtracting the player position from the marker position
        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);

        //returns the multiplication of the compass postiton and the calculated angle to represent the accurate amount of 
        //space on the compass for each marker
        return new Vector2(compassPosition * angle, 0f);
    }
}
