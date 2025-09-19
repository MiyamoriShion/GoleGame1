using UnityEngine;

public class MovingSpikeChild : MonoBehaviour
{
    public Transform startPoint; // 出発位置（現在の凸の位置）
    public Transform endPoint;   // 往復先（木の位置）
    public float speed = 3f;     // 移動速度
    public float stopThreshold = 0.1f; // 到達判定の余裕

    private Transform targetPosition;

    private void Start()
    {
        // 初期位置は現在の位置
        targetPosition = endPoint;
    }

    private void Update()
    {
        // ターゲットに向かって移動
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

        // 到達したら折り返す
        if (Vector3.Distance(transform.position, targetPosition.position) <= stopThreshold)
        {
            targetPosition = (targetPosition == endPoint) ? startPoint : endPoint;
        }
    }
}