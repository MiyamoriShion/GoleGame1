using UnityEngine;

public class SwingMotion : MonoBehaviour
{
    [Header("Swing Settings")]
    public float speed = 2.0f;       // �h��鑬��
    public float angle = 45.0f;      // �ő�̐U��p�x

    private float time;

    void Update()
    {
        // ���Ԃ�i�߂�
        time += Time.deltaTime * speed;

        // �T�C���g�� -1�`1 ���J��Ԃ� �� �p�x�ɕϊ�
        float zRotation = Mathf.Sin(time) * angle;

        // Z����]������i2D�Ȃ�Z�A3D�Ȃ玲��ς��Ă�OK�j
        transform.localRotation = Quaternion.Euler(0, 0, zRotation);
    }
}