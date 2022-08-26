using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManger : MonoBehaviour
{
    float score;

    [SerializeField] TMP_Text scoreText;

    public static ScoreManger Instance;

    [SerializeField]float prizeValue;

    bool isDead;
    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(scoreText.transform.parent.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isDead)
        {
            score += Time.deltaTime;
            scoreText.text = "Score : " + ((int)score).ToString();
        }

    }
    public void DestroyAll()
    {
        Destroy(scoreText.gameObject);
        Destroy(gameObject);
    }
    public void OnDead()
    {
        isDead = true;
    }
    public float GetScore()
    {
        return score;
    }
    public void CollectPrize()
    {
        score += prizeValue;
    }

}
