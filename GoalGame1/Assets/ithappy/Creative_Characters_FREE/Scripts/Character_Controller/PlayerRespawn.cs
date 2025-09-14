using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;

    void Start()
    {
        // �Q�[���J�n���̈ʒu���������X�|�[���n�_�ɂ���
        respawnPoint = transform.position;
    }

    // �Z�[�u�|�C���g�ɐG�ꂽ���A�������Ă΂�Ēn�_���X�V����
    public void SetRespawnPoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
        Debug.Log("[PlayerRespawn] RespawnPoint set to " + respawnPoint);
    }

    // ��Q���ɓ����������ɌĂ΂��
    public void Respawn()
    {
        Debug.Log("[PlayerRespawn] Respawn to " + respawnPoint);

        // CharacterController�𖳌������Ă���ʒu���ړ����Ȃ��ƃo�O�邱�Ƃ�����
        var cc = GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            transform.position = respawnPoint;
            cc.enabled = true;
        }
        else
        {
            transform.position = respawnPoint;
        }
    }
}