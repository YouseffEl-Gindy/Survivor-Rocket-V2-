using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] GameObject[] Rocks;

    [SerializeField] float timerPeriod;

    //minimum and maximum position of static rock
    [SerializeField] float minY;
    [SerializeField] float maxY;

    // X distance between the player and the next obstacle
    [SerializeField] float xDistance; 

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    //TPMR : Two Point Moving rock
    //THPMR : Three Point Moving rock
    //FPMR : Five Point Moving rock

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= timerPeriod)
        {
            float[] rocksSpeed = DifficultyController.Instance.GetRocksSpeed();
            float positionX = Player.transform.position.x + xDistance;
            int randomIndex = Random.Range(0, 4);
            if (randomIndex == 0)
            {
                float randomY = Random.Range(minY, maxY);
                Instantiate(Rocks[randomIndex], new Vector3(positionX + 25, randomY, 0f), Quaternion.identity);
            }
            else if (randomIndex == 1)
            {
                GameObject TPMR = Instantiate(Rocks[randomIndex], new Vector3(positionX + 18, -0.66f , 0f), Quaternion.identity);
                TPMR.transform.Find("Rock").GetComponent<MovingRock>().setSpeed(rocksSpeed[0]);
            }
            else if (randomIndex == 2)
            {
                GameObject THPMR = Instantiate(Rocks[randomIndex], new Vector3(positionX + 11, 2.5f, 0f), Quaternion.identity);
                THPMR.transform.Find("Rock").GetComponent<MovingRock>().setSpeed(rocksSpeed[1]);
            }
            else
            {
                GameObject FPMR = Instantiate(Rocks[randomIndex], new Vector3(positionX, -5.6f, 0f), Quaternion.identity);
                FPMR.transform.Find("Rock").GetComponent<MovingRock>().setSpeed(rocksSpeed[2]);
            }
                
            timer = 0;
        }
    }
}
