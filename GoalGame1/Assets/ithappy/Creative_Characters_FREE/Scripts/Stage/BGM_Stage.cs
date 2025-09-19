using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_Stage : MonoBehaviour
{
    public AudioClip stageBGM;
    private AudioSource audioSource;
    private static BGM_Stage instance;

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
        audioSource.clip = stageBGM;
        audioSource.loop = true;
        audioSource.spatialBlend = 0; // 2D
        audioSource.volume = 1f;
    }

    public void PlayBGM()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }
    void Start()
    {
        BGM_Title titleBGM = FindObjectOfType<BGM_Title>();
        if (titleBGM != null)
        {
            titleBGM.StopBGM();
            Destroy(titleBGM.gameObject); // �s�v�Ȃ�j��
        }

        // �X�e�[�WBGM���Đ�
        audioSource.Play();
    }


    public void StopBGM()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }
}