using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    public Transform Player1;
    public Transform Player2;

    public GameObject Portal;
    public Portal CurrentPortal;
    public float Distance;
    public float Speed;

    private bool IsActive = false;
    private bool Player1Pulled = false;
    private bool Player2Pulled = false;
    private bool LoadScene = false;

    public ChangeScene ChangeScene;

    private void Start()
    {
        if (Portal != null)
        {
            Portal.SetActive(false);
        }
    }

    private void Update()
    {
        if (!IsActive &&
            (Vector2.Distance(transform.position, Player1.position) < Distance ||
            Vector2.Distance(transform.position, Player2.position) < Distance))
        {
            Portal.SetActive(true);

            IsActive = true;
        }

        if (IsActive)
        {
            if (Vector2.Distance(transform.position, Player1.position) < Distance)
            {
                PullingIntoPortal(Player1, ref Player1Pulled);
            }
            else if (Vector2.Distance(transform.position,Player2.position) < Distance)
            {
                PullingIntoPortal(Player2, ref Player2Pulled);
            }

            if (Player1Pulled &&  Player2Pulled && !LoadScene)
            {
                LoadScene = true;
                Invoke("LoadNextScene", 1f);
            }
        }
    }

    private void PullingIntoPortal(Transform player, ref bool isPulled)
    {
        player.position = Vector2.MoveTowards(player.position, transform.position, Speed * Time.deltaTime);

        if (Vector2.Distance(player.position, transform.position) < 0.5f)
        {
            player.gameObject.SetActive(false);

            isPulled = true;
        }
    }

    private void LoadNextScene()
    {
        if (ChangeScene != null)
        {
            ChangeScene.SwapScene("SplitLevel1");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SplitLevel1");
        }
    }
}

