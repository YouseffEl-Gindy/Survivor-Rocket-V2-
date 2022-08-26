using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem Instance;

    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioSource prizeAudio;
    [SerializeField] AudioSource dieAudio;

    [SerializeField] AudioSource backgroundAudio;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        backgroundAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonAudio()
    {
        buttonAudio.Play();
    }

    public void PlayPrizeAudio()
    {
        prizeAudio.Play();
    }

    public void PlayDieAudio()
    {
        dieAudio.Play();
    }
}
