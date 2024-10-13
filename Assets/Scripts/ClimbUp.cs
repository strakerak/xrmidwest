using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ClimbUp : MonoBehaviour
{
    public GameObject player;
    public GameObject leftHand;
    public GameObject rightHand;

    public float leftRotThresh;
    public float rightRotThresh;

    public bool leftGrab = false;
    public bool rightGrab = false;

    public Vector3 goalPos;

    public float _current, _target;

    public float riseRate = 0.5f;

    public Material redConfo;
    public Material greenConfo;

    public GameObject leftConfo;
    public GameObject rightConfo;

    public Vector3 currPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        goalPos = new Vector3(player.transform.position.x, player.transform.position.y + riseRate, player.transform.position.z);

        if (leftGrab && leftHand.transform.rotation.z < leftRotThresh && rightHand.transform.rotation.z < rightRotThresh)
        {
            leftGrab = false;
            StartCoroutine(MoveUp(currPos, goalPos,1f));
        }
        else if (rightGrab && rightHand.transform.rotation.z > rightRotThresh && leftHand.transform.rotation.z > leftRotThresh)
        {
            rightGrab = false;
            StartCoroutine(MoveUp(currPos, goalPos, 1f));
        }
        else
        {
            //l
        }

        if(leftGrab)
        {
            leftConfo.GetComponent<Image>().material = greenConfo;
        }
        else
        {
            leftConfo.GetComponent <Image>().material = redConfo;
        }

        if(rightGrab)
        {
            rightConfo.GetComponent<Image>().material = greenConfo;
        }
        else
        {
            rightConfo.GetComponent<Image>().material = redConfo;
        }

    }

    public void GoUp()
    {
        if (leftHand.transform.rotation.z > leftRotThresh)
        {
            Debug.Log("GO ON UP!");
            this.leftGrab = true;
        }
        /*else
        {
            Debug.Log("Sit ur ass down");
            this.leftGrab = false;
        }*/

        if (rightHand.transform.rotation.z < rightRotThresh)
        {
            Debug.Log("GO ON UP!");
            this.rightGrab = true;
        }

        /*else
        {
            Debug.Log("sit ur ass down");
            this.rightGrab= false;
        }*/


        Debug.Log(leftGrab + " " + rightGrab);

        
    }


    IEnumerator MoveUp(Vector3 start, Vector3 end, float overTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime<overTime)
        {
            player.transform.position = Vector3.Lerp(start, end, (elapsedTime / overTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
