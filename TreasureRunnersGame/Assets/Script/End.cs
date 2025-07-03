using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject WinUI;
    public string Id;

    private bool Player1Inside = false;
    private bool Player2Inside = false;

    private GameObject Player1;
    private GameObject Player2;

    private Collider2D DoorCollider;

    private bool IsEndPlay = false;

    private void Start()
    {
        DoorCollider = GetComponent<Collider2D>();

        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Player1Inside = true;
        }

        if (other.CompareTag("Player2"))
        {
            Player2Inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Player1Inside = false;
        }

        if (other.CompareTag("Player2"))
        {
            Player2Inside = false;
        }
    }

    private void Update()
    {
        if (Player1Inside && Player2Inside && Player1 != null && Player2 != null)
        {
            if (IsFullyInside2D(Player1) && IsFullyInside2D(Player2))
            {
                WinLevel();
            }
        }
    }

    private bool IsFullyInside2D(GameObject player)
    {
        Collider2D playerCollider = player.GetComponent<Collider2D>();

        if (playerCollider == null)
        {
            return false;
        }

        Bounds doorBounds = DoorCollider.bounds;
        Bounds playerBounds = playerCollider.bounds;

        return doorBounds.Contains(playerBounds.min) && doorBounds.Contains(playerBounds.max);
    }

    private void WinLevel()
    {
        WinUI.SetActive(true);

        if (!IsEndPlay)
        {
            Audio.Instance.PlayEnd();

            IsEndPlay = true;
        }
        
        SaveLevel.Instance.AddLevel(Id);
        SaveLevel.Instance.MoveArtifactsToGlobal();
    }
}
