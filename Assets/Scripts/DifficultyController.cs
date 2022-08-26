using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{

    public static DifficultyController Instance;

    //Interval for score incrementation
    [SerializeField] int scoreInterval;

   /* public GameObject Rock1;
    public GameObject Rock2;
    public GameObject Rock3;
    public GameObject Rock4;*/

    bool incremented;

    [SerializeField] float prizeValue;
    
    // The value that the speen increases throughout the time
    [SerializeField] float timeValue;
    
    
    [SerializeField] GameObject[] rockGroups;
    //
    [SerializeField] GameObject threePointRock;
    [SerializeField] GameObject twoPointRock;
    
    
    [SerializeField] float[] rocksSpeed;
    //
    [SerializeField] float threePointRockSpeed;
    [SerializeField] float twoPointRockSpeed;
    


    
    

    private void Awake()
    {
        if(Instance != null) Destroy(gameObject);
        else Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rocksSpeed[0] = 2;
        rocksSpeed[1] = 3;
        rocksSpeed[2] = 5;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int Score = (int)ScoreManger.Instance.GetScore();
        if (Score % scoreInterval == 0 && Score != 0 && !incremented)
        {

            for(int i = 0; i<3; i++)
            {
                rocksSpeed[i] += timeValue;
                //rockGroups[i].gameObject.transform.Find("Rock").GetComponent<MovingRock>().setSpeed(rocksSpeed[i]);
                //Debug.Log("Speed Incremented", this);
            }
            
            /*Rock1.GetComponent<MovingRock>().IncremntSpeed(1);
            Rock2.GetComponent<MovingRock>().IncremntSpeed(1);
            Rock3.GetComponent<MovingRock>().IncremntSpeed(1);
            Rock4.GetComponent<MovingRock>().IncremntSpeed(1);*/

            ViewController.Instance.IncrementSpeedOfRocks(timeValue);

            incremented = true;

        }
        else if (Score % 10 != 0)
        {
            incremented = false;
        }
    }
    public void CollectPrize()
    {

        for(int i = 0; i < 3; i++)
        {
            rocksSpeed[i] += prizeValue;
        }

        /*Rock1.GetComponent<MovingRock>().IncremntSpeed(prizeValue);
        Rock2.GetComponent<MovingRock>().IncremntSpeed(prizeValue);
        Rock3.GetComponent<MovingRock>().IncremntSpeed(prizeValue);
        Rock4.GetComponent<MovingRock>().IncremntSpeed(prizeValue);*/
    }
    public float[] GetRocksSpeed()
    {
        return rocksSpeed;
    }
}
