using UnityEngine;

namespace Controller
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMover : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float walkSpeed = 4f;
        [SerializeField] private float runSpeed = 7f;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private float gravity = -9.81f;

        private CharacterController controller;
        private Transform cam;

        private Vector3 velocity;
        private bool isGrounded;

        // --- �ǉ�: MovePlayerInput����n�������� ---
        private Vector2 axis;
        private bool isRun;
        private bool isJump;
        private Vector3 targetDir;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            cam = Camera.main.transform;
        }

        private void Update()
        {
            // --- �n�ʔ��� ---
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // --- �ړ����� ---
            Vector3 move = new Vector3(axis.x, 0, axis.y);

            // �J����������ɕϊ�
            if (cam != null)
            {
                move = cam.TransformDirection(move);
                move.y = 0f;
            }

            float speed = isRun ? runSpeed : walkSpeed;
            controller.Move(move * speed * Time.deltaTime);

            // --- �W�����v���� ---
            if (isJump && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // --- �d�� ---
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        // --- �ǉ�: MovePlayerInput������͂��󂯎�郁�\�b�h ---
        public void SetInput(in Vector2 inputAxis, in Vector3 target, in bool run, bool jump)
        {
            axis = inputAxis;
            targetDir = target;
            isRun = run;
            isJump = jump;
        }
    }
}