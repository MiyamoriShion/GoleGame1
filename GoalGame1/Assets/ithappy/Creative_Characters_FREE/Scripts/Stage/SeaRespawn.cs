using UnityEngine;

public class SeaRespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn pr = other.GetComponent<PlayerRespawn>();
            if (pr != null)
            {
                pr.Respawn();
            }
        }
    }
}