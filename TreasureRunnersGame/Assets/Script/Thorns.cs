using UnityEngine;

public class Thorns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Animator.SetBool("isAlive", false);

                player.IsAlive = false;
            }
        }
    }
}
