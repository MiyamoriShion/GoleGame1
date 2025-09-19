using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader : MonoBehaviour
{
    public string nextSceneName;    // ���ɓǂݍ��ރV�[����
    public AudioSource clickSound;  // �N���b�N���������ɃZ�b�g�iInspector�Ńh���b�O�j

    // �{�^������Ă΂�郁�\�b�h
    public void LoadNextStage()
    {
        if (clickSound != null)
        {
            StartCoroutine(PlaySoundAndLoadScene());
        }
        else
        {
            // AudioSource���Ȃ��ꍇ�͑����ɃV�[���؂�ւ�
            LoadScene();
        }
    }

    private System.Collections.IEnumerator PlaySoundAndLoadScene()
    {
        clickSound.Play(); // ����炷
        yield return new WaitForSeconds(clickSound.clip.length); // ������I���܂ő҂�
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
            Debug.LogError("[StageLoader] ���̃V�[�������ݒ肳��Ă��܂���I");
        }
    }
}