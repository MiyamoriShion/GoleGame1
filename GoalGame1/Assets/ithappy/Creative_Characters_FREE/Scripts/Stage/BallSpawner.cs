using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject ballPrefab;     // トゲトゲボールのプレハブ
    public Transform spawnPoint;      // 出現位置
    public float spawnInterval = 3f;  // 何秒ごとに出すか
    public float ballLifetime = 10f;  // ボールが消えるまでの秒数
    public float ballSpeed = 2f;      // ボールの進む速さ

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBall();
            timer = 0f;
        }
    }

    void SpawnBall()
    {
        if (ballPrefab == null)
        {
            Debug.LogWarning("BallSpawner: ballPrefab が設定されていません");
            return;
        }

        Vector3 pos = (spawnPoint != null) ? spawnPoint.position : transform.position;
        Quaternion rot = (spawnPoint != null) ? spawnPoint.rotation : transform.rotation;

        GameObject ball = Instantiate(ballPrefab, pos, rot);

        // RollingBall スクリプトを持っている前提
        RollingBall rb = ball.GetComponent<RollingBall>();
        if (rb != null)
        {
            rb.moveSpeed = ballSpeed;   // RollingBall に合わせた変数名
            rb.lifeTime = ballLifetime;
        }
    }
}