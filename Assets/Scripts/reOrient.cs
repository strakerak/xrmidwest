using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class reOrient : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject controller;
    public GameObject holder;
    public GameObject origin;


    float x;
    float y;
    float z;

    bool reOrients = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void reOrienter()
    {
        if (reOrients)
        {
            if (this.gameObject.name == "Left Controller")
            {
                controller.transform.eulerAngles = new Vector3(0f, 0f, 0f);


            }
            else if (this.gameObject.name == "Right Controller")
            {
                controller.transform.eulerAngles = new Vector3(0f, 0f, 0f);

            }
            else
                Debug.Log("WTF!?");
        }
    }

    public void captureRot()
    {
        x = holder.transform.eulerAngles.x;
        y = holder.transform.eulerAngles.y;
        z = holder.transform.eulerAngles.z;
        reOrients = true;
        reOrienter();
    }
}
