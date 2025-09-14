using UnityEngine;

public class SwingMotion : MonoBehaviour
{
    [Header("Swing Settings")]
    public float speed = 2.0f;       // —h‚ê‚é‘¬‚³
    public float angle = 45.0f;      // Å‘å‚ÌU‚êŠp“x

    private float time;

    void Update()
    {
        // ŠÔ‚ği‚ß‚é
        time += Time.deltaTime * speed;

        // ƒTƒCƒ“”g‚Å -1`1 ‚ğŒJ‚è•Ô‚· ¨ Šp“x‚É•ÏŠ·
        float zRotation = Mathf.Sin(time) * angle;

        // Z²‰ñ“]‚³‚¹‚éi2D‚È‚çZA3D‚È‚ç²‚ğ•Ï‚¦‚Ä‚àOKj
        transform.localRotation = Quaternion.Euler(0, 0, zRotation);
    }
}