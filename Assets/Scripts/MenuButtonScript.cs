using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadClimber()
    {
        SceneManager.LoadScene("RocksUp");
    }

    public void LoadStars()
    {
        SceneManager.LoadScene("Stargaze");
    }

    public void LoadWhackAMole()
    {
        SceneManager.LoadScene("WhackaMole");
    }

    public void LoadBalls()
    {
        SceneManager.LoadScene("Balls");
    }

    public void LoadCity()
    {
        SceneManager.LoadScene("City");
    }    
}
