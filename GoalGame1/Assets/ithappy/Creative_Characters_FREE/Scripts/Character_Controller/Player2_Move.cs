using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Player2_Move : MonoBehaviour
{
    [Header("�ړ��ݒ�")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float rotationSpeed = 10f; // ��]�̂Ȃ߂炩��
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // �n�ʔ���
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // ���́i2P�̓e���L�[ 2468 + 0 + �EShift�j
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.Keypad4)) moveX = -1f; // ��
        if (Input.GetKey(KeyCode.Keypad6)) moveX = 1f;  // �E
        if (Input.GetKey(KeyCode.Keypad8)) moveZ = 1f;  // �O
        if (Input.GetKey(KeyCode.Keypad5)) moveZ = -1f; // ���

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // ���� or ����
        bool isRunning = Input.GetKey(KeyCode.RightShift);
        float speed = isRunning ? runSpeed : walkSpeed;

        if (move.magnitude >= 0.1f)
        {
            // ��]���Ȃ߂炩��
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // �ړ�
            controller.Move(transform.forward * speed * Time.deltaTime);
            animator.SetFloat("Speed", isRunning ? 1f : 0.5f); // Run = 1, Walk = 0.5
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        // �W�����v
        if (Input.GetKeyDown(KeyCode.Keypad0) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("isJumping", true);
        }
        else if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        // �d��
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}