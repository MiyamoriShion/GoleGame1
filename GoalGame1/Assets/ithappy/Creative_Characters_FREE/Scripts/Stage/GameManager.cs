using UnityEngine;
using UnityEngine.UI; // Text 用
using TMPro;          // TextMeshPro 用

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public Text goalText;          // 通常の Text
    public TextMeshProUGUI goalTMP; // TMP 版

    [Header("Audio")]
    public AudioSource sfxAudio;
    public AudioClip goalClip;

    private void Awake()
    {
        Instance = this;
    }

    public void GameClear()
    {
        // ゴール文字を表示
        if (goalText != null) goalText.text = "GOAL!";
        if (goalTMP != null) goalTMP.text = "GOAL!";

        // 効果音再生
        if (goalClip != null && sfxAudio != null)
        {
            sfxAudio.PlayOneShot(goalClip);
        }
    }
}