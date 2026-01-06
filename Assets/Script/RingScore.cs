using UnityEngine;

public class RingScore : MonoBehaviour
{
    private bool counted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (counted) return;

        if (other.CompareTag("Player"))
        {
            counted = true;
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(1);
            }
        }
    }
}
