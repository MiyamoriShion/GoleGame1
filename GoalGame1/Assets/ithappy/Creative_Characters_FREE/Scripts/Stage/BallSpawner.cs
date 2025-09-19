using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject ballPrefab;     // �g�Q�g�Q�{�[���̃v���n�u
    public Transform spawnPoint;      // �o���ʒu
    public float spawnInterval = 3f;  // ���b���Ƃɏo����
    public float ballLifetime = 10f;  // �{�[����������܂ł̕b��
    public float ballSpeed = 2f;      // �{�[���̐i�ޑ���

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
            Debug.LogWarning("BallSpawner: ballPrefab ���ݒ肳��Ă��܂���");
            return;
        }

        Vector3 pos = (spawnPoint != null) ? spawnPoint.position : transform.position;
        Quaternion rot = (spawnPoint != null) ? spawnPoint.rotation : transform.rotation;

        GameObject ball = Instantiate(ballPrefab, pos, rot);

        // RollingBall �X�N���v�g�������Ă���O��
        RollingBall rb = ball.GetComponent<RollingBall>();
        if (rb != null)
        {
            rb.moveSpeed = ballSpeed;   // RollingBall �ɍ��킹���ϐ���
            rb.lifeTime = ballLifetime;
        }
    }
}