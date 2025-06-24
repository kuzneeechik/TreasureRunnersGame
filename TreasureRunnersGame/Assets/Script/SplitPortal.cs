using UnityEngine;

public class SplitPortal : MonoBehaviour
{
    public Transform Player;
    public Portal Portal;
    public float Distance;
    public float Speed;
    public string nextScene;

    private bool IsPulled = false;
    private bool LoadScene = false;

    public ChangeScene ChangeScene;

    private void Update()
    {
        if (IsPulled || Player == null) return;

        if (Vector2.Distance(transform.position, Player.position) < Distance)
        {
            PullingIntoPortal(Player);
        }

        if (!LoadScene &&
            SaveLevel.Instance.Player1Pulled &&
            SaveLevel.Instance.Player2Pulled)
        {
            LoadScene = true;

            SaveLevel.Instance.IsSave = true;
            SaveLevel.Instance.IsReturn = true;

            Invoke("LoadNextScene", 1f);
        }
    }

    private void PullingIntoPortal(Transform player)
    {
        player.position = Vector2.MoveTowards(player.position, transform.position, Speed * Time.deltaTime);

        if (Vector2.Distance(player.position, transform.position) < 0.5f)
        {
            player.gameObject.SetActive(false);
            IsPulled = true;

            Portal.Animator.SetBool("isFull", true);

            if (player.CompareTag("Player1"))
            { 
                SaveLevel.Instance.Player1Pulled = true;
            }
            else if (player.CompareTag("Player2"))
            {
                SaveLevel.Instance.Player2Pulled = true;
            }
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
}
