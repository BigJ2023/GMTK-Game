using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSelected = false;
    private float rotationSpeed = 30f;
    public float deviation;
    public Light cameraView;


    private float intensity = 2.23f;

    private float InitialRotation; //inital y degree rotation
    private float lowerBound;
    private float upperBound;
    void Start()
    {
        InitialRotation = Mathf.Abs(transform.eulerAngles.y);
        //Gets the upper and lower bounds via the "deviation" (Works like error bars on a chart)
        upperBound = Mathf.Abs(transform.eulerAngles.y) + deviation;

        lowerBound = Mathf.Abs(transform.eulerAngles.y) - deviation;
    }

    // Update is called once per frame
    void Update()
    {
        //Turns on light (increase intensity) and reverses rotation speed of camera once bounds are reached
        if (isSelected)
        {
            cameraView.intensity = intensity;
            if (Mathf.Abs(transform.eulerAngles.y) <= lowerBound || Mathf.Abs(transform.eulerAngles.y) >= upperBound)
            {
                rotationSpeed *= -1;
            }
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else
        {
            cameraView.intensity = 0;
        }

    }


    //Increases rotation speed of camera to whatever value is passed in
    public void setToHardMode(float rotSpeed)
    {
        rotationSpeed = rotSpeed;
    }
}
