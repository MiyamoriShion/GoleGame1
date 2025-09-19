using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceHeight = 8f; // ���ʂ̃W�����v��荂�߂ɐݒ�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 1P
            Player1_Move p1 = other.GetComponent<Player1_Move>();
            if (p1 != null)
            {
                p1.SetSpringJump(bounceHeight);
            }

            // 2P
            Player2_Move p2 = other.GetComponent<Player2_Move>();
            if (p2 != null)
            {
                p2.SetSpringJump(bounceHeight);
            }
        }
    }
}