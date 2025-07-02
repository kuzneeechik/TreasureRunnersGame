using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public GameObject winUI;
    public string Id;

    private bool player1Inside = false;
    private bool player2Inside = false;

    private GameObject player1;
    private GameObject player2;

    private Collider2D doorCollider;

    private void Start()
    {
        doorCollider = GetComponent<Collider2D>();

        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
            player1Inside = true;

        if (other.CompareTag("Player2"))
            player2Inside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
            player1Inside = false;

        if (other.CompareTag("Player2"))
            player2Inside = false;
    }

    private void Update()
    {
        if (player1Inside && player2Inside && player1 != null && player2 != null)
        {
            if (IsFullyInside2D(player1) && IsFullyInside2D(player2))
            {
                WinLevel();
            }
        }
    }

    private bool IsFullyInside2D(GameObject player)
    {
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        if (playerCollider == null) return false;

        Bounds doorBounds = doorCollider.bounds;
        Bounds playerBounds = playerCollider.bounds;

        return doorBounds.Contains(playerBounds.min) && doorBounds.Contains(playerBounds.max);
    }

    private void WinLevel()
    {
        winUI.SetActive(true);
        
        SaveLevel.Instance.AddLevel(Id);
        SaveLevel.Instance.MoveArtifactsToGlobal();
    }
}
