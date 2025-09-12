using UnityEngine;

namespace Controller
{
    [RequireComponent(typeof(CharacterMover))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class MovePlayerInput : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField] private string m_HorizontalAxis = "Horizontal";
        [SerializeField] private string m_VerticalAxis = "Vertical";
        [SerializeField] private string m_JumpButton = "Jump";
        [SerializeField] private KeyCode m_RunKey = KeyCode.LeftShift;

        [Header("Camera")]
        [SerializeField] private FollowPlayerCamera m_Camera; // Inspectorでドラッグ可能

        private CharacterMover m_Mover;
        private CharacterController m_Controller;
        private Animator m_Animator;

        private Vector2 m_Axis;
        private bool m_IsRun;
        private bool m_IsJump;
        private Vector3 m_Target;
        private Vector2 m_MouseDelta;
        private float m_Scroll;

        private void Awake()
        {
            m_Mover = GetComponent<CharacterMover>();
            m_Controller = GetComponent<CharacterController>();
            m_Animator = GetComponent<Animator>();

            // Cameraが設定されていなければシーン内のFollowPlayerCameraを探す
            if (m_Camera == null)
            {
                m_Camera = Camera.main?.GetComponent<FollowPlayerCamera>();
            }

            if (m_Camera != null)
                m_Camera.SetPlayer(transform);
        }

        private void Update()
        {
            GatherInput();
            SetInput();

            float speed = new Vector2(m_Axis.x, m_Axis.y).magnitude;
            m_Animator.SetFloat("Speed", speed);

            // ジャンプしてるかどうか
            m_Animator.SetBool("isJumping", !m_Controller.isGrounded);
        }

        public void GatherInput()
        {
            m_Axis = new Vector2(Input.GetAxis(m_HorizontalAxis), Input.GetAxis(m_VerticalAxis));
            m_IsRun = Input.GetKey(m_RunKey);
            m_IsJump = Input.GetButton(m_JumpButton);

            m_Target = (m_Camera == null) ? Vector3.zero : m_Camera.Target;
            m_MouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            m_Scroll = Input.GetAxis("Mouse ScrollWheel");
        }

        public void SetInput()
        {
            if (m_Mover != null)
                m_Mover.SetInput(in m_Axis, in m_Target, in m_IsRun, m_IsJump);
            if (m_Camera != null)
                m_Camera.SetInput(in m_MouseDelta, m_Scroll);
        }
    }
}