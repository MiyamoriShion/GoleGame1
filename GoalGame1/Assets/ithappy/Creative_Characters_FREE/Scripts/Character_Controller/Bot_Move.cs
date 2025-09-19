using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Bot_AI : MonoBehaviour
{
    public Transform goal; // ゴール地点

    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (goal != null)
        {
            agent.SetDestination(goal.position); // ゴールを目的地にする
        }
    }

    void Update()
    {
        if (agent.velocity.magnitude > 0.1f)
        {
            animator.SetFloat("Speed", 0.5f); // 歩き
        }
        else
        {
            animator.SetFloat("Speed", 0f); // 停止
        }
    }

    // バネで飛ばすとき用（NavMeshはジャンプしないから外部制御する）
    public void SetSpringJump(float jumpPower)
    {
        // NavMeshAgentを一時停止
        agent.enabled = false;

        // ジャンプ処理（RigidbodyなしなのでCharacterController風にやるなら別処理が必要）
        // シンプルに transform.Translate を使ってもOK
        StartCoroutine(JumpRoutine(jumpPower));
    }

    private System.Collections.IEnumerator JumpRoutine(float jumpPower)
    {
        float jumpTime = 0.5f;
        float timer = 0f;

        Vector3 start = transform.position;
        Vector3 end = transform.position + Vector3.up * jumpPower;

        while (timer < jumpTime)
        {
            timer += Time.deltaTime;
            float t = timer / jumpTime;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }

        // NavMeshAgentを復活させる
        agent.enabled = true;
        agent.SetDestination(goal.position);
    }
}