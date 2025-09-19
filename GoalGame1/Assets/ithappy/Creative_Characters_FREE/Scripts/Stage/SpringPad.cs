using UnityEngine;

public class SpringPad : MonoBehaviour
{
    [Header("Spring Settings")]
    public float springJumpHeight = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bot"))
        {
            // Player1
            Player1_Move p1 = other.GetComponent<Player1_Move>();
            if (p1 != null)
            {
                p1.SetSpringJump(springJumpHeight);
                return;
            }

            // Player2
            Player2_Move p2 = other.GetComponent<Player2_Move>();
            if (p2 != null)
            {
                p2.SetSpringJump(springJumpHeight);
                return;
            }

           
        }
    }
}