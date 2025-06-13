using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonnewgame : MonoBehaviour
{
    bool IsBookSceneActive()
    {
        return SceneManager.GetActiveScene().name == "Book";
    }
    public void NewGame()
    {
        SceneManager.LoadScene("NewGame");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Book()
    {
        if (IsBookSceneActive()) 
            SceneManager.LoadScene("NewGame");
        else
            SceneManager.LoadScene("Book");
    }
}
