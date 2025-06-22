using UnityEngine;

public class L3_2Lever : MonoBehaviour
{
    private int tapCount = 0; // Счетчик нажатий (0 - не нажато, 1 - открыли, 2 - закрыли)
    private GameObject playerInRange = null;
    private Animator animator;
    public Door door;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Если уже сделали 2 действия (открыли и закрыли) - выходим
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

        // Первое нажатие - открываем дверь
        if (tapCount == 1)
        {
            animator.SetBool("isTapped", true);
            door.animator.SetBool("isOpen", true);
        }
        // Второе нажатие - закрываем дверь
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