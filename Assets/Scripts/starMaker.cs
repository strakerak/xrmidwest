using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starMaker : MonoBehaviour
{
    public GameObject star;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            GameObject s = Instantiate(star, transform.position, Quaternion.identity);
            s.SetActive(true);
        }
    }

    [Button]
    public void MakeStar()
    {
        for (int  i = 0; i<5;i++)
        {
            GameObject s = Instantiate(star, transform.position, Quaternion.identity);
            s.SetActive(true);
        }
    }
}
