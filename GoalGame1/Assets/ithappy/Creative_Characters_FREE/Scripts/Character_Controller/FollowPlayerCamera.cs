using UnityEngine;

namespace Controller
{
    public class FollowPlayerCamera : PlayerCamera
    {
        protected override void Awake()
        {
            base.Awake();
        }

        private void LateUpdate()
        {
            if (m_Player == null) return;

            // プレイヤーの位置に追従
            Vector3 direction = new Vector3(0f, 0f, -m_Distance);
            Quaternion rotation = Quaternion.Euler(m_Angles.x, m_Angles.y, 0f);

            m_Transform.position = m_Player.position + rotation * direction;
            m_Transform.LookAt(m_Player.position);
        }
    }
}