using UnityEngine;

public class MovingRotatingTrap : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 1f;     // �������鋗���i�Z�߁j
    public float moveSpeed = 2f;        // �����X�s�[�h

    private Vector3 startPos;

    void Start()
    {
        // �����ʒu���L�^
        startPos = transform.position;
    }

    void Update()
    {
        // �A ���E�ɉ���
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }
}