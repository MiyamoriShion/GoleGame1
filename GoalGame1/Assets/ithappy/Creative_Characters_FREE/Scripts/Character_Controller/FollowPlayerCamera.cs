using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [Header("追従するターゲット")]
    public Transform target; // Player1 or Player2

    [Header("カメラ設定")]
    public Vector3 offset = new Vector3(0, 3, -5); // 追従位置
    public float followSpeed = 5f; // 追従スピード
    public float rotateSpeed = 5f; // 回転スピード

    private void LateUpdate()
    {
        if (target == null) return;

        // 追従する位置
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // プレイヤーの向きに合わせて回転
        Quaternion desiredRotation = Quaternion.LookRotation(target.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);
    }
}