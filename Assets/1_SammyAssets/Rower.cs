using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Rower : MonoBehaviour
{

    public Transform oarTip;
    public LayerMask waterLayer;
    public float rowingForce = 10f;
    public float maxDepth = 0.5f;

    public Transform xrOrigin;

    private Vector3 prevPos;
    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRowing();
    }

    void HandleRowing()
    {
        Vector3 currPos = transform.position;
        Vector3 movement = currPos - prevPos;

        RaycastHit hit;
        if(Physics.Raycast(oarTip.position, Vector3.down, out hit, maxDepth, waterLayer))
        {
            Debug.Log("HIT!");
            float depth = maxDepth - hit.distance;

            float forceMultiplier = Mathf.Clamp(depth / maxDepth, 0f, 1f);
            Vector3 force = movement * rowingForce * forceMultiplier;

            Debug.Log(movement.y);
            if (movement.y < 0)
            {
                Rigidbody waterRigidbody = hit.collider.GetComponent<Rigidbody>();
                if(waterRigidbody!=null)
                {
                    Debug.Log("WATER HIT!");
                    //waterRigidbody.AddForceAtPosition(-force, hit.point, ForceMode.Impulse);
                    xrOrigin.position += new Vector3(0, 0, 0.25f);
                }
            }
        }

        Debug.Log(currPos + " " + prevPos);
        prevPos = currPos;
    }
}
