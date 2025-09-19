using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_Title : MonoBehaviour
{
    public AudioClip titleBGM;
    private AudioSource audioSource;
    private static BGM_Title instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = titleBGM;
        audioSource.loop = true;
        audioSource.spatialBlend = 0; // 2D
        audioSource.volume = 1f;

        audioSource.Play();
    }

    void OnDestroy()
    {
        instance = null;
    }
    public void StopBGM()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}