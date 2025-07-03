using UnityEngine;

public class DoubleLever : MonoBehaviour
{
    private int TapCount = 0;

    private GameObject PlayerInRange = null;
    private Animator Animator;

    public Door Door;

    public string Id;

    private bool IsPlayDoor = false; 

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (TapCount >= 2 || PlayerInRange == null)
        {
            return;
        }

        string tag = PlayerInRange.tag;

        if ((tag == "Player1" && Input.GetKeyDown(KeyCode.RightShift)) ||
            (tag == "Player2" && Input.GetKeyDown(KeyCode.LeftShift)))
        {
            UseLever();
        }
    }

    private void UseLever()
    {
        TapCount++;

        if (TapCount == 1)
        {
            Animator.SetBool("isTapped", true);

            if (!IsPlayDoor)
            {
                Audio.Instance.PlayDoor();
            }

            Door.Animator.SetBool("isOpen", true);
        }
        else if (TapCount == 2)
        {
            Animator.SetBool("isTapped", false);

            if (!IsPlayDoor)
            {
                Audio.Instance.PlayDoor();

                IsPlayDoor = true;
            }

            Door.Animator.SetBool("isOpen", false);
        }
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