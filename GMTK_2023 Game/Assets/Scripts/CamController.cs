using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cameras;
    public GameObject[] aliensList;

    //change Interval and switch speed (idk if this should be randomly made or not)
    [SerializeField] private float changeInterval = 3.0f;
    [SerializeField] private float changeSpeed = 3.0f;

    private float diffSpeed = 90f;

    //Game Attributes
    private float lives = 3;
    void Start()
    {
        InvokeRepeating("PickCamera", changeInterval, changeSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            Application.Quit();
        }
    }

    void PickCamera()
    {
        Boolean selected;

        //Finds selected camera and unselects, if one exists
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].GetComponent<CameraScript>().isSelected)
            {
                cameras[i].GetComponent<CameraScript>().isSelected = false;
                break;
            }
        }
        //Turns on random camera from cameras array
        int index = UnityEngine.Random.Range(0, cameras.Length);
        cameras[index].GetComponent<CameraScript>().isSelected = true;
        print("Random1");
    }

    void AlienHeard()
    {

    }

    public void AlienSpotted()
    {
        lives--;
        print("Lives = " + lives);
        
        CancelInvoke();
        /*timer.GetComponent<Timer>().AlterTime(-120);
        //This part of the method sets the game into "hard mode"
        if (lives != 0)
        {
            //Cancels random camera selection
            //Sets each camera's rotation speed to 2x its current speed
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].GetComponent<CameraScript>().setToHardMode(diffSpeed);
            }
            Start();
        }
        */
    }
}
