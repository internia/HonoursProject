using UnityEngine;
/// <summary>
/// VisualScaler
/// 
/// This script controls the functionality of the visualisation, increasing the scale of the bumpers.  
/// </summary>
public class VisualScaler : MonoBehaviour
{
    public float scaler;  //defined within unity, how high the bumpers will jump
    public int bumper; //represents the index value to bumpers on the visualscaler 
    public float bumperMultiplier = 0.2f; //sets a value for the vector to transform the bumper b

    void Update()
    {
        //creating variable val by recieving the bumper value from VisualiseSoundManager based on position and multipling with a scale factor
        var val = VisualiseSoundManager.Instance.bumpers[bumper] * scaler;
        transform.localScale = new Vector3(bumperMultiplier, val, bumperMultiplier);
    }
}

