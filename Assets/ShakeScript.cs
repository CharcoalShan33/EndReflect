using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    private Vector3 shakePos;

    private Vector3 originalPos;

    private Vector3 shakeRot;


    [SerializeField]
    float duration = 0f; // how long the shake lasts. The lower the number, the shorter the time. 

    [SerializeField]
    float magnitude = .5f; // how strong the shake. value from 0 to 1. IMPACT

    [SerializeField]
    float frequency; // the speed at which the wave happens. Large number, Smaller waves.





    private void Start()
    {
       
        //Shake Rotation
        //shakeRot = Vector3.one;
        duration = magnitude = frequency = 0;


        magnitude = Mathf.Clamp01(magnitude);

        frequency = Mathf.Clamp(frequency, 0, 35);

    }

    private void Update()
    {

        if (duration <= 0)
        {
            duration = 0;
        }
        else
        {
            duration -= Time.deltaTime;
        }
        Shake1();
    }

    void Shake1()// Horizontal Shake

    {
         //Shake Position
       shakePos = Vector3.one;
        //Starting Position
        originalPos = Vector3.zero;
        transform.localPosition = new Vector3(shakePos.x * Mathf.PerlinNoise(0.0f, Time.time * frequency), 0, 0) * magnitude;
        //Transform Local positions for X and Y Axis only.
    }

    void ImpactHit() // Rotational Shake
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, shakeRot.z * Mathf.PerlinNoise(0f, Time.time * frequency)) * magnitude);
        // Rotation is for Z axis only.
    }

    void Shake2() // Vertical Shake
    {
        transform.localPosition = new Vector3(0, shakePos.y * Mathf.PerlinNoise(Time.time * frequency, 0.0f), 0) * magnitude;
    }
    void Quake() // allShake
    {
        transform.localPosition = new Vector3(shakePos.x * Mathf.PerlinNoise(0.0f, Time.time * frequency), shakePos.y * Mathf.PerlinNoise(Time.time * frequency, 0.0f), 0) * magnitude;
    }

    public void Tremor(float intensity, float speed, float timeAmount)
    {
        magnitude = intensity;

        frequency = speed;

        duration = timeAmount;


    }

}

