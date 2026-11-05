using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        Debug.Log("Player killed!");
        GameManager.Instance.RestartLevel();
    }
}
