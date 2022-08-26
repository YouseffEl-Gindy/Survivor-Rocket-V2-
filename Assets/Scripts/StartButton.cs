using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAction()
    {
        AudioSystem.Instance.PlayButtonAudio();

        SceneManager.LoadScene("GameScene");
    }
}
