using UnityEngine;

public class LogMover : MonoBehaviour
{
    [HideInInspector] public float speed = 2f;        // i‚Ş‘¬‚³
    [HideInInspector] public float lifetime = 10f;    // Á‚¦‚é‚Ü‚Å‚ÌŠÔ
    public float rotationSpeed = 180f;                // ƒSƒƒSƒ‰ñ“]‚Ì‘¬‚³

    void Start()
    {
        // ˆê’èŠÔŒã‚ÉÁ‚·
        Destroy(gameObject, lifetime);

        // ŠÛ‘¾‚ğ‰¡‚½‚í‚ç‚¹‚éi‰¡“|‚µ‚É‚·‚éj
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    void Update()
    {
        // -Z•ûŒü‚Éi‚Ş
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // Z²‚Å‰ñ“]iƒSƒƒSƒ“]‚ª‚é‚æ‚¤‚ÉŒ©‚¦‚éj
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
    }
}