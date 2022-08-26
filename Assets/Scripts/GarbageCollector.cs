using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    [SerializeField] GameObject Player;


    // The x Diffrence between the player and the Collector
    float xDiffBetweenPlayer;

    // Start is called before the first frame update
    void Start()
    {
        xDiffBetweenPlayer = Player.transform.position.x - transform.position.x;
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerY = Player.transform.position.y;

        transform.position = new Vector3(Player.transform.position.x - xDiffBetweenPlayer, playerY, transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name , this);

        if(collision.CompareTag("Rock"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
        else if(collision.CompareTag("MovingRock"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
