using UnityEngine;

public class DoubleLever : MonoBehaviour
{
    private int tapCount = 0;
    private GameObject playerInRange = null;
    private Animator animator;
    public Door door;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (tapCount >= 2 || playerInRange == null) return;

        string tag = playerInRange.tag;

        if ((tag == "Player1" && Input.GetKeyDown(KeyCode.RightShift)) ||
            (tag == "Player2" && Input.GetKeyDown(KeyCode.LeftShift)))
        {
            UseLever();
        }
    }

    private void UseLever()
    {
        tapCount++;

        if (tapCount == 1)
        {
            animator.SetBool("isTapped", true);
            door.animator.SetBool("isOpen", true);
        }
        else if (tapCount == 2)
        {
            animator.SetBool("isTapped", false);
            door.animator.SetBool("isOpen", false);
        }
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