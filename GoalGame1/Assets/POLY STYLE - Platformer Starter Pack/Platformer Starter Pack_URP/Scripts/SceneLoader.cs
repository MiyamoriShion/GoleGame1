using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // PlayerSelect�V�[���ֈړ�
    public void LoadPlayerSelect()
    {
        SceneManager.LoadScene("PlayerSelectScene");
    }
}