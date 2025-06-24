using System.Collections;
using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    public Transform Player1;
    public Transform Player2;

    public GameObject Portal;
    public Portal CurrentPortal;
    public float Distance;
    public float Speed;
    public string nextScene;

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

        if (SaveLevel.Instance != null && SaveLevel.Instance.IsSave)
        {
            SaveLevel.Instance.RestorePlayerPositions(Player1, Player2);

            StartCoroutine(PlayerActivation());

            if (Portal != null)
            {
                Portal.SetActive(true);
            }

            if (CurrentPortal?.Animator != null)
            {
                CurrentPortal.Animator.SetBool("isFull", false);
            }

            if (SaveLevel.Instance.IsReturn)
            {
                IsActive = false;
                LoadScene = true;
            }
            else
            {
                IsActive = true;
                LoadScene = false;
            }

            SaveLevel.Instance.IsSave = false;
            SaveLevel.Instance.IsReturn = false;
            SaveLevel.Instance.Player1Pulled = false;
            SaveLevel.Instance.Player2Pulled = false;
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
            if (!Player1Pulled && Vector2.Distance(transform.position, Player1.position) < Distance)
            {
                PullingIntoPortal(Player1, ref Player1Pulled);
            }
            if (!Player2Pulled && Vector2.Distance(transform.position, Player2.position) < Distance)
            {
                PullingIntoPortal(Player2, ref Player2Pulled);
            }

            if (Player1Pulled && Player2Pulled && !LoadScene)
            {
                LoadScene = true;

                SaveLevel.Instance?.SavePlayerPositions(Player1.position, Player2.position);

                SaveLevel.Instance.IsSave = true;
                SaveLevel.Instance.IsReturn = false;

                if (CurrentPortal?.Animator != null)
                {
                    CurrentPortal.Animator.SetBool("isFull", false);
                }

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
            ChangeScene.SwapScene(nextScene);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }

    private IEnumerator PlayerActivation()
    {
        yield return null;
        Player1.gameObject.SetActive(true);
        Player2.gameObject.SetActive(true);
    }
}

