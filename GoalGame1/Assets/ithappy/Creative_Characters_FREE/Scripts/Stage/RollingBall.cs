using UnityEngine;

public class RollingBall : MonoBehaviour
{
    public float moveSpeed = 3f;   // �O�ɐi�ޑ���
    public float rotationSpeed = 180f; // ��]�̑���
    public float lifeTime = 5f;   // ���b��ɏ����邩

    void Start()
    {
        Destroy(gameObject, lifeTime); // ��莞�Ԍ�ɏ���
    }

    void Update()
    {
        // �O�i
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);

        // �]�����]�iX����]�ŃS���S�������o���j
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}