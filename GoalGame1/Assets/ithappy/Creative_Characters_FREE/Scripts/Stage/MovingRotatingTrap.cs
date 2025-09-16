using UnityEngine;

public class MovingRotatingTrap : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 1f;     // 往復する距離（短め）
    public float moveSpeed = 2f;        // 往復スピード

    private Vector3 startPos;

    void Start()
    {
        // 初期位置を記録
        startPos = transform.position;
    }

    void Update()
    {
        // ② 左右に往復
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }
}