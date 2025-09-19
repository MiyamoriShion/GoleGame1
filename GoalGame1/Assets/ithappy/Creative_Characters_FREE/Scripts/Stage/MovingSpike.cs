using UnityEngine;

public class MovingSpikeChild : MonoBehaviour
{
    public Transform startPoint; // �o���ʒu�i���݂̓ʂ̈ʒu�j
    public Transform endPoint;   // ������i�؂̈ʒu�j
    public float speed = 3f;     // �ړ����x
    public float stopThreshold = 0.1f; // ���B����̗]�T

    private Transform targetPosition;

    private void Start()
    {
        // �����ʒu�͌��݂̈ʒu
        targetPosition = endPoint;
    }

    private void Update()
    {
        // �^�[�Q�b�g�Ɍ������Ĉړ�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

        // ���B������܂�Ԃ�
        if (Vector3.Distance(transform.position, targetPosition.position) <= stopThreshold)
        {
            targetPosition = (targetPosition == endPoint) ? startPoint : endPoint;
        }
    }
}