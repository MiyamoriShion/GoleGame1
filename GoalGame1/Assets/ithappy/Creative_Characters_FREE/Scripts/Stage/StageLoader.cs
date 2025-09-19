using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader : MonoBehaviour
{
    public string nextSceneName;    // 次に読み込むシーン名
    public AudioSource clickSound;  // クリック音をここにセット（Inspectorでドラッグ）

    // ボタンから呼ばれるメソッド
    public void LoadNextStage()
    {
        if (clickSound != null)
        {
            StartCoroutine(PlaySoundAndLoadScene());
        }
        else
        {
            // AudioSourceがない場合は即座にシーン切り替え
            LoadScene();
        }
    }

    private System.Collections.IEnumerator PlaySoundAndLoadScene()
    {
        clickSound.Play(); // 音を鳴らす
        yield return new WaitForSeconds(clickSound.clip.length); // 音が鳴り終わるまで待つ
        LoadScene();
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("[StageLoader] 次のシーン名が設定されていません！");
        }
    }
}