using UnityEngine;

public class RollingBall : MonoBehaviour
{
    public float moveSpeed = 3f;   // ‘O‚Éi‚Ş‘¬‚³
    public float rotationSpeed = 180f; // ‰ñ“]‚Ì‘¬‚³
    public float lifeTime = 5f;   // ‰½•bŒã‚ÉÁ‚¦‚é‚©

    void Start()
    {
        Destroy(gameObject, lifeTime); // ˆê’èŠÔŒã‚ÉÁ‚·
    }

    void Update()
    {
        // ‘Oi
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);

        // “]‚ª‚é‰ñ“]iX²‰ñ“]‚ÅƒSƒƒSƒŠ´‚ğo‚·j
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}