using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [Header("�Ǐ]����^�[�Q�b�g")]
    public Transform target; // Player1 or Player2

    [Header("�J�����ݒ�")]
    public Vector3 offset = new Vector3(0, 3, -5); // �Ǐ]�ʒu
    public float followSpeed = 5f; // �Ǐ]�X�s�[�h
    public float rotateSpeed = 5f; // ��]�X�s�[�h

    private void LateUpdate()
    {
        if (target == null) return;

        // �Ǐ]����ʒu
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // �v���C���[�̌����ɍ��킹�ĉ�]
        Quaternion desiredRotation = Quaternion.LookRotation(target.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);
    }
}