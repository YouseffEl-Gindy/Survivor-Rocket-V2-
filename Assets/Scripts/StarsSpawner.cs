using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{

    [SerializeField] GameObject Player;

    // X distance betweeb player and spawner
    float xDistanceOfPlayer;

    //X offset of collision game object
    [SerializeField] float xOffset;

    // Start is called before the first frame update
    void Start()
    {
        xDistanceOfPlayer = Player.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();

    }
    void FollowPlayer()
    {
        float playerY = Player.transform.position.y;
        transform.position = new Vector3(Player.transform.position.x - xDistanceOfPlayer, playerY, transform.position.z);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Stars"))
        {
            collision.transform.position = new Vector3(collision.transform.position.x + xOffset, collision.transform.position.y, collision.transform.position.z);
        }
    }
}
