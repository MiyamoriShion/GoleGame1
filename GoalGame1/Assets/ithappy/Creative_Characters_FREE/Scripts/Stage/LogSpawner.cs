using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject logPrefab;    // 丸太のプレハブ
    public float spawnInterval = 3f; // 何秒ごとに出すか
    public float logLifetime = 10f;  // 丸太が消えるまでの秒数
    public float logSpeed = 2f;      // 丸太の進む速さ（Y軸方向）

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnLog();
            timer = 0f;
        }
    }

    void SpawnLog()
    {
        // 丸太を生成
        GameObject log = Instantiate(logPrefab, transform.position, Quaternion.identity);

        // 移動スクリプトをアタッチして動かす
        LogMover mover = log.AddComponent<LogMover>();
        mover.speed = logSpeed;
        mover.lifetime = logLifetime;
    }
}