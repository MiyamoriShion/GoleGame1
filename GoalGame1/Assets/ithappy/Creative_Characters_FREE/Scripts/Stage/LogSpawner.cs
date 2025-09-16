using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject logPrefab;    // �ۑ��̃v���n�u
    public float spawnInterval = 3f; // ���b���Ƃɏo����
    public float logLifetime = 10f;  // �ۑ���������܂ł̕b��
    public float logSpeed = 2f;      // �ۑ��̐i�ޑ����iY�������j

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
        // �ۑ��𐶐�
        GameObject log = Instantiate(logPrefab, transform.position, Quaternion.identity);

        // �ړ��X�N���v�g���A�^�b�`���ē�����
        LogMover mover = log.AddComponent<LogMover>();
        mover.speed = logSpeed;
        mover.lifetime = logLifetime;
    }
}