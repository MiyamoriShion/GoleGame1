using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerNumber = 1; // 1P or 2P を区別
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float turnSpeed = 10f; // 回転の滑らかさ（数値を変えて調整）

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // プレイヤーごとにキーを変える
        if (playerNumber == 1) // 1P: WASD
        {
            moveX = Input.GetAxisRaw("Horizontal"); // A,D
            moveZ = Input.GetAxisRaw("Vertical");   // W,S
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }
        else if (playerNumber == 2) // 2P: 矢印キー
        {
            if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1;
            if (Input.GetKey(KeyCode.RightArrow)) moveX = 1;
            if (Input.GetKey(KeyCode.UpArrow)) moveZ = 1;
            if (Input.GetKey(KeyCode.DownArrow)) moveZ = -1;
            if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded)
            {
                Jump();
            }
        }

        // 移動方向ベクトル
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // キャラの向きを滑らかに変える
        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }

        // Rigidbodyの移動
        Vector3 newVelocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);
        rb.velocity = newVelocity;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面に触れたらジャンプ可能に
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}