using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;

    void Start()
    {
        // ゲーム開始時の位置を初期リスポーン地点にする
        respawnPoint = transform.position;
    }

    // セーブポイントに触れた時、ここが呼ばれて地点を更新する
    public void SetRespawnPoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
        Debug.Log("[PlayerRespawn] RespawnPoint set to " + respawnPoint);
    }

    // 障害物に当たった時に呼ばれる
    public void Respawn()
    {
        Debug.Log("[PlayerRespawn] Respawn to " + respawnPoint);

        // CharacterControllerを無効化してから位置を移動しないとバグることがある
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