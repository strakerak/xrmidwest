using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BallGameHandler : MonoBehaviour
{

    public float interval;
    public float ballSpeed;
    public float knockback;
    public float force;
    public int goal = 5;
    public int score = 0;
    public int awayScore = 0;
    public int awayLimit = 25;

    float timer = 0f;

    float yayTimer = 0f;

    float tempInterval;

    public GameObject ball;
    public Transform cannon;

    public TMP_Text intervalText;
    public TMP_Text forceText;
    public TMP_Text goalText;
    public TMP_Text limitText;

    public TMP_Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        interval = 3f;
        ballSpeed = 1.1f;
        tempInterval = interval;

        intervalText.text = "Interval: " + interval.ToString();
        forceText.text = "Speed: " + (force / 1000).ToString();
        goalText.text = "Goal: " + goal.ToString();
        limitText.text = "Away Limit: " + awayLimit.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            GameObject bullet = Instantiate(ball, cannon.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = cannon.forward * force * Time.deltaTime;
            timer = 0f;
        }

        if (score > goal)
        {
            interval = 0f;
            yayTimer += Time.deltaTime;
            if (yayTimer > 5f)
            {
                score = 0;
                interval = tempInterval;
                deleteBalls();
                resetYayTimer();
            }
        }

        if (awayScore > awayLimit)
        {
            //SceneManager.LoadScene("Menu");
        }

        scoreDisplay.text = $"Home - {score} || {awayScore} - Away";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("Menu");
        }
    }

    public void intervalSliderChange(float value)
    {
        float localValue = value;
        intervalText.text = "Interval: " + localValue.ToString("0.00");
        interval = value;
        tempInterval = value;
    }

    public void forceSliderChange(float value)
    {
        float localValue = value;
        forceText.text = "Speed: " + (localValue / 1000).ToString("0.00");
        force = value;
    }

    public void goalSliderChange(float value)
    {
        float localValue = value;
        goalText.text = "Score: " + localValue.ToString("0.00");
        goal = (int)value;
    }

    public void awayLimitChange(float value)
    {
        float localValue = value;
        limitText.text = "Away Limit: " + localValue.ToString("0.00");
        awayLimit = (int)value;
    }

    void deleteBalls()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }

    void resetYayTimer()
    {
        yayTimer = 0f;
    }
}
