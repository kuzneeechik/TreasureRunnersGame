using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool IsTapped = false;

    private GameObject PlayerInRange = null;

    private Animator Animator;
    public Door Door;

    public string Id;

    public bool IsPlayDoor = false;

    private void Start()
    {
        Animator = GetComponent<Animator>();

        if (SaveLevel.Instance != null && SaveLevel.Instance.Levers.Contains(Id))
        {
            IsTapped = true;
            Animator.SetBool("isTapped", true);

            if (Door != null)
            {
                Door.Animator.SetBool("isOpen", true);
            }
        }
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

        if (!IsPlayDoor)
        {
            Audio.Instance.PlayDoor();

            IsPlayDoor = true;
        }

        Door.Animator.SetBool("isOpen", true);

        IsTapped = true;

        if (SaveLevel.Instance != null)
        {
            SaveLevel.Instance.AddLever(Id);
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
