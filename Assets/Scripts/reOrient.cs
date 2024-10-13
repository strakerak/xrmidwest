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

    ClimbUp cu;

    float x;
    float y;
    float z;

    bool reOrients = false;
    void Start()
    {
        cu = origin.GetComponent<ClimbUp>();
    }

    // Update is called once per frame
    void Update()
    {
        //reOrienter();
    }

    void reOrienter()
    {
        if(reOrients)
        {
            if (this.gameObject.name == "Left Controller")
            {
                controller.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                cu.leftRotThresh = holder.transform.eulerAngles.z + 90f;


            }
            else if (this.gameObject.name == "Right Controller")
            {
                controller.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                cu.rightRotThresh = holder.transform.eulerAngles.z - 90f;

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
