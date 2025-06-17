using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool isTapped = false;

    private GameObject playerInRange = null;

    private Animator animator;
    public Door door;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isTapped || playerInRange == null) return;

        string tag = playerInRange.tag;

        if (tag == "Player1" && Input.GetKeyDown(KeyCode.RightShift))
        {
            ActivateLever();
        }
        else if (tag == "Player2" && Input.GetKeyDown(KeyCode.LeftShift))
        {
            ActivateLever();
        }
    }

    private void ActivateLever()
    {
        animator.SetBool("isTapped", true);
        door.animator.SetBool("isOpen", true);

        isTapped = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            playerInRange = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (playerInRange == other.gameObject)
        {
            playerInRange = null;
        }
    }
}
