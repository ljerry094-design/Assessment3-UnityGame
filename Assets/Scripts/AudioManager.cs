using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Background Music")]
    public AudioClip bgmIntro;
    public AudioClip bgmStartScene;
    public AudioClip bgmGhostNormal;
    public AudioClip bgmGhostScared;
    public AudioClip bgmGhostDead;

    [Header("Sound Effects")]
    public AudioClip sfxMove;
    public AudioClip sfxPellet;
    public AudioClip sfxWall;
    public AudioClip sfxDeath;

    private AudioSource audioSource;

    void Awake()
    {
    
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayIntroThenNormal());
    }

    IEnumerator PlayIntroThenNormal()
    {

        audioSource.clip = bgmIntro;
        audioSource.Play();

   
        yield return new WaitForSeconds(Mathf.Min(bgmIntro.length, 3f));

      
        PlayBGM(bgmGhostNormal);
    }

    public void PlayBGM(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
