using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.onClick.AddListener(MenuButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuButton()
    {
        AudioSystem.Instance.PlayButtonAudio();

        ScoreManger.Instance.DestroyAll();
        SpeedText.Instance.DestroyGameObject();
        SceneManager.LoadScene("MenuScene");
    }
}
