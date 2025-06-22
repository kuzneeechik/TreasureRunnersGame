using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    private bool player1Touched = false;
    private bool player2Touched = false;
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            player1Touched = true;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Player2"))
        {
            player2Touched = true;
            collision.gameObject.SetActive(false);
        }

        CheckPortalCondition();
    }

    private void CheckPortalCondition()
    {
        if (player1Touched && player2Touched)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}