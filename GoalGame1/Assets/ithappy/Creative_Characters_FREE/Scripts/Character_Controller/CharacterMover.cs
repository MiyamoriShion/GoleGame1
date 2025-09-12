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

        // --- 追加: MovePlayerInputから渡される入力 ---
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
            // --- 地面判定 ---
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // --- 移動処理 ---
            Vector3 move = new Vector3(axis.x, 0, axis.y);

            // カメラ方向基準に変換
            if (cam != null)
            {
                move = cam.TransformDirection(move);
                move.y = 0f;
            }

            float speed = isRun ? runSpeed : walkSpeed;
            controller.Move(move * speed * Time.deltaTime);

            // --- ジャンプ処理 ---
            if (isJump && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // --- 重力 ---
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        // --- 追加: MovePlayerInputから入力を受け取るメソッド ---
        public void SetInput(in Vector2 inputAxis, in Vector3 target, in bool run, bool jump)
        {
            axis = inputAxis;
            targetDir = target;
            isRun = run;
            isJump = jump;
        }
    }
}