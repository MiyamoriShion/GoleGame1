using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var pr = other.GetComponent<PlayerRespawn>();
            if (pr != null)
            {
                pr.Respawn();
            }
        }
    }
}