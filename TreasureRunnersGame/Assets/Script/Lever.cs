using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool IsTapped = false;

    private GameObject PlayerInRange = null;

    private Animator Animator;
    public Door Door;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsTapped || PlayerInRange == null) return;

        string tag = PlayerInRange.tag;

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
        Animator.SetBool("isTapped", true);
        Door.Animator.SetBool("isOpen", true);

        IsTapped = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            PlayerInRange = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (PlayerInRange == other.gameObject)
        {
            PlayerInRange = null;
        }
    }
}
