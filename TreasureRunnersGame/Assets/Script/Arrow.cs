using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            Destroy(gameObject);
        }

        else if (other.CompareTag("Player1") ||
            other.CompareTag("Player2"))
        {
            Destroy (gameObject);

            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Animator.SetBool("isAlive", false);

                player.IsAlive = false;
            }
        }
    }
}
