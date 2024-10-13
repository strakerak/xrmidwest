using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class starfucker : MonoBehaviour
{
    public Transform playerHead;
    public float releaseDistance = 25f;
    bool isHolding = false;

    // Start is called before the first frame update
    void Start()
    {
        playerHead = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    public void OnGrabStar(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform == this.transform)
        {
            isHolding = true;
        }
    }

    public void OnReleaseStar(SelectExitEventArgs args)
    {
        if(args.interactableObject.transform == this.transform)
        {

            isHolding = false;
            moveStar();

        
        }
    }    


    public void moveStar()
    {

        Vector3 gazeDirection = playerHead.forward;

        transform.position = playerHead.position + gazeDirection * releaseDistance;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
