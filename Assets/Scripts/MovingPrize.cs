using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPrize : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float speed;

    Transform nextPos;
    int nextPosIndex;

    bool isCollected;

    float timer;

    [SerializeField] float timeToShow;

    [SerializeField] SpriteRenderer[] Sprites;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        isCollected = false;
        transform.position = Positions[0].position;
        nextPos = Positions[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePrize();
        CheckVisability();
    }

    void MovePrize()
    {
        if(transform.position == nextPos.position)
        {
            nextPosIndex++;
            if(nextPosIndex >= Positions.Length)
            {
                nextPosIndex = 0;
            }
            nextPos = Positions[nextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        }
    }



    public void OnCollect()
    {
        isCollected = true;
    }
    public bool IsCollected()
    {
        return isCollected;
    }

    void CheckVisability()
    {
        if(isCollected)
        {
            timer +=Time.deltaTime;
            if(timer >= timeToShow)
            {
                for(int i = 0; i < Sprites.Length; i++)
                {
                    Sprites[i].enabled = true;
                }
                isCollected = false;
            }

        }
        else
        {
            timer = 0f;
        }
    }

    public void HideSprites()
    {
        for(int i = 0; i < Sprites.Length; i++)
        {
            Sprites[i].enabled = false; 
        }
    }


}
