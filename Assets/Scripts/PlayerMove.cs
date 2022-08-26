using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;

    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;

    //maximum and minimum y position of player 
    [SerializeField] float maxY;
    [SerializeField] float minY;

    //bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        //isDead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BoundriesCheck();
    }
    void BoundriesCheck()
    {
        float playerY = transform.position.y;
        float dir = Input.GetAxisRaw("Vertical");

        if (playerY <= maxY && dir > 0)
        {
            rb.velocity = (Vector2.up * dir * verticalSpeed) + (Vector2.right * horizontalSpeed);
        }
        else if (playerY >= minY && dir < 0)
        {
            rb.velocity = (Vector2.up * dir * verticalSpeed) + (Vector2.right * horizontalSpeed);

        }
        else
            rb.velocity = Vector2.right * horizontalSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("MovingRock"))
        {
            AudioSystem.Instance.PlayDieAudio();

            ScoreManger.Instance.OnDead();
            SceneManager.LoadScene("GameoverScene");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Prize"))
        {
            
            if(!collision.GetComponent<MovingPrize>().IsCollected())
            {
                AudioSystem.Instance.PlayPrizeAudio();

                collision.GetComponent<MovingPrize>().OnCollect();
                collision.GetComponent<MovingPrize>().HideSprites();

                ScoreManger.Instance.CollectPrize();
                DifficultyController.Instance.CollectPrize();

                ViewController.Instance.IncrementSpeedOfRocks(0.5f);
            }    
            
        }
    }



}
