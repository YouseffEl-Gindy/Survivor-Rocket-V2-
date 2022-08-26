using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartButton()
    {
        AudioSystem.Instance.PlayButtonAudio();

        ScoreManger.Instance.DestroyAll();
        SpeedText.Instance.DestroyGameObject();
        SceneManager.LoadScene("GameScene");
    }
}
