using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCatcher : MonoBehaviour
{

    public BallGameHandler bg;
    bool caught = false;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bg = GameObject.Find("Cannon").GetComponent<BallGameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 100 * Time.deltaTime);
        transform.Rotate(Vector3.right, 100 * Time.deltaTime);
        timer += Time.deltaTime;
        if(timer>15f)
        {
            if (!caught)
                bg.awayScore += 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (caught)
        {
            if (other.gameObject.tag == "hands")
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    public void addScore()
    {
        caught = true;
        bg.score += 1;
    }
}
