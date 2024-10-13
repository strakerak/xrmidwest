using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class RockGameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> spheres = new List<GameObject>();

    public TMP_Text radiusText;

    float ballRadius;

    void Start()
    {
        ballRadius = 0.5f;
        radiusText.text = "Radius: " + ballRadius.ToString("0.00");

        GameObject[] objs = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in objs)
        {
            if(obj.name.StartsWith("Handles"))
            {

            spheres.Add(obj); 

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void forceSliderChange(float value)
    {
        float localValue = value;
        radiusText.text = "Radius: " + localValue.ToString("0.00");
        ballRadius = value;
        foreach (GameObject sphere in spheres)
        {
            Debug.Log(sphere.name + " " + sphere.GetComponent<ClimbInteractable>());
            Debug.Log("Changing it");
            sphere.GetComponent<SphereCollider>().radius = ballRadius;
            Debug.Log(sphere.name + " " + sphere.GetComponent<SphereCollider>().radius);
        }
    }
}
