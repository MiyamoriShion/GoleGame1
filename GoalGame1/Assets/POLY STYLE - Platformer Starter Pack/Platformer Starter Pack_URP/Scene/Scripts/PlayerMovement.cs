using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerNumber = 1; // 1P or 2P �����
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float turnSpeed = 10f; // ��]�̊��炩���i���l��ς��Ē����j

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

        // �v���C���[���ƂɃL�[��ς���
        if (playerNumber == 1) // 1P: WASD
        {
            moveX = Input.GetAxisRaw("Horizontal"); // A,D
            moveZ = Input.GetAxisRaw("Vertical");   // W,S
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }
        else if (playerNumber == 2) // 2P: ���L�[
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

        // �ړ������x�N�g��
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // �L�����̌��������炩�ɕς���
        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }

        // Rigidbody�̈ړ�
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
        // �n�ʂɐG�ꂽ��W�����v�\��
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}