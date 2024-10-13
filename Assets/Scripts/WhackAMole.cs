using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackAMole : MonoBehaviour
{

    public static WhackAMole instance;


    [Header("Game Handling")]
    public Transform spawnPoints;
    public List<Vector3> spawnPointList = new List<Vector3>();
    public GameObject mole;
    public List<GameObject> moles = new List<GameObject>();


    //public Transform Player;
    int score;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform item in spawnPoints)
            spawnPointList.Add(item.position);

        InvokeRepeating("GetMole", 1f, 1f);
    }

    public void GetMole()
    {
        if(spawnPointList.Count > 0)
        {
            Vector3 randPos = spawnPointList[(Random.Range(0, spawnPointList.Count))];
            spawnPointList.Remove(randPos);

            GameObject currMole = Instantiate(mole, randPos, new Quaternion(0,179,179,0));
            currMole.SetActive(true);
            moles.Add(currMole);
        }
        else
        {
            Debug.Log("MAX");
        }
    }

    public void DestroyMole(GameObject _mole)
    {
        spawnPointList.Add(_mole.transform.position);
        moles.Remove(_mole);
        Destroy(_mole);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
