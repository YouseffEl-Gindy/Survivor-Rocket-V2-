using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedText : MonoBehaviour
{
    public static SpeedText Instance;

    [SerializeField] TMP_Text speedText;

    float speedOfRocks;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        speedOfRocks = 1f;
        speedText.text = "Speed : x " + speedOfRocks;

        DontDestroyOnLoad(gameObject);
        //DontDestroyOnLoad(speedText.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }
    public void ChangeSpeed(float speedOfRocks)
    {
        this.speedOfRocks = speedOfRocks;
        speedText.text = "Speed : x " + speedOfRocks;
    }
    public void DestroyGameObject()
    {
        Destroy(speedText.gameObject);
        Destroy(gameObject);
    }

}
