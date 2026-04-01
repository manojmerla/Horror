using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource musicSource;
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;

    private static bool isMusicOn = true; // persistent across scenes

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // persist across scenes
        }
        else
        {
            Destroy(gameObject); // avoid duplicates
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        UpdateMusic(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateMusic(scene.name);
    }

    void UpdateMusic(string sceneName)
    {
        AudioClip newClip = null;

        if (sceneName == "MainMenu") newClip = mainMenuMusic;
        else if (sceneName == "Game") newClip = gameMusic;

        if (newClip == null) return;

        if (musicSource.clip != newClip)
        {
            musicSource.clip = newClip;

            if (isMusicOn)
                musicSource.Play();
            else
                musicSource.Pause();
        }
    }

    public void ToggleMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
            isMusicOn = false;
        }
        else
        {
            musicSource.Play();
            isMusicOn = true;
        }
    }

    public bool IsMusicOn() => isMusicOn; // optional for UI icon update
}
