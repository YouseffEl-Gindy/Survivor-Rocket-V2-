using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{

    [SerializeField] GameObject Player;

    //X distance between the player and spawner
    float xDistanceOfPlayer;


    // Maximum and minimum Y position of the Rock
    [SerializeField] float maxY;
    [SerializeField] float minY;

    // X offset of collision game static object
    [SerializeField] float xOffsetStatic;

    // X offset of collision game moving object
    [SerializeField] float xOffsetMoving;


    // Start is called before the first frame update
    void Start()
    {
        xDistanceOfPlayer = Player.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerY = Player.transform.position.y;
        transform.position = new Vector3(Player.transform.position.x - xDistanceOfPlayer, playerY, transform.position.z);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            float yRange = Random.Range(minY, maxY);
            //collision.transform.position = new Vector3(collision.transform.position.x + xOffsetStatic, yRange, collision.transform.position.z);
        }
        else if(collision.gameObject.CompareTag("MovingRock"))
        {
            Transform parentObject = collision.transform.parent;
            //parentObject.transform.position = new Vector3(parentObject.transform.position.x + xOffsetMoving, parentObject.transform.position.y, parentObject.transform.position.z);                 
            //collision.transform.position = new Vector3(collision.transform.position.x + xOffsetMoving , collision.transform.position.y , collision.transform.position.z);
        }
    }
}
