using UnityEngine;

[CreateAssetMenu]
public class DrumConfig : ScriptableObject
{
    [Header("UI")]
    public float waitToStop = 3f;

    [Header("Speed")]
    public float maxSpeed;
    public float accelerationTime;
    public float decelerationTime;

    [Header("Centering")]
    public float waitToCentring;
    public float centeringTime = 0.25f;
}