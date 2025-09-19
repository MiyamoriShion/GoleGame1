using UnityEngine;
using UnityEngine.UI; // Text �p
using TMPro;          // TextMeshPro �p

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public Text goalText;          // �ʏ�� Text
    public TextMeshProUGUI goalTMP; // TMP ��

    [Header("Audio")]
    public AudioSource sfxAudio;
    public AudioClip goalClip;

    private void Awake()
    {
        Instance = this;
    }

    public void GameClear()
    {
        // �S�[��������\��
        if (goalText != null) goalText.text = "GOAL!";
        if (goalTMP != null) goalTMP.text = "GOAL!";

        // ���ʉ��Đ�
        if (goalClip != null && sfxAudio != null)
        {
            sfxAudio.PlayOneShot(goalClip);
        }
    }
}