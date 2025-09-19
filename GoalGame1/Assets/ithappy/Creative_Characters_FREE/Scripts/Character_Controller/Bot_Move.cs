using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Bot_AI : MonoBehaviour
{
    public Transform goal; // �S�[���n�_

    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (goal != null)
        {
            agent.SetDestination(goal.position); // �S�[����ړI�n�ɂ���
        }
    }

    void Update()
    {
        if (agent.velocity.magnitude > 0.1f)
        {
            animator.SetFloat("Speed", 0.5f); // ����
        }
        else
        {
            animator.SetFloat("Speed", 0f); // ��~
        }
    }

    // �o�l�Ŕ�΂��Ƃ��p�iNavMesh�̓W�����v���Ȃ�����O�����䂷��j
    public void SetSpringJump(float jumpPower)
    {
        // NavMeshAgent���ꎞ��~
        agent.enabled = false;

        // �W�����v�����iRigidbody�Ȃ��Ȃ̂�CharacterController���ɂ��Ȃ�ʏ������K�v�j
        // �V���v���� transform.Translate ���g���Ă�OK
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

        // NavMeshAgent�𕜊�������
        agent.enabled = true;
        agent.SetDestination(goal.position);
    }
}