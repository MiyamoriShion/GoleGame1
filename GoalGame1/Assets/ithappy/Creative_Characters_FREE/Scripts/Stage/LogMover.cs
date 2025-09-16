using UnityEngine;

public class LogMover : MonoBehaviour
{
    [HideInInspector] public float speed = 2f;        // �i�ޑ���
    [HideInInspector] public float lifetime = 10f;    // ������܂ł̎���
    public float rotationSpeed = 180f;                // �S���S����]�̑���

    void Start()
    {
        // ��莞�Ԍ�ɏ���
        Destroy(gameObject, lifetime);

        // �ۑ���������点��i���|���ɂ���j
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    void Update()
    {
        // -Z�����ɐi��
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // Z���ŉ�]�i�S���S���]����悤�Ɍ�����j
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
    }
}