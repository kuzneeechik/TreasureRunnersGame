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
        SaveLevel.Instance.ResetAll();

        SceneManager.LoadScene("NewGame");
    }
    public void Back()
    {
        SaveLevel.Instance.SaveToDisk();

        SceneManager.LoadScene("Menu");
    }
    public void Book()
    {
        if (IsBookSceneActive())
            SceneManager.LoadScene("NewGame");
        else
        {
            SceneManager.LoadScene("Book");
        }
    }
    public void Setting(GameObject objPrefab)
    {
        Instantiate(objPrefab);
    }
    public void Continue()
    {
        SaveLevel.Instance.LoadFromDisk();

        SceneManager.LoadScene("NewGame");
    }
    public void Level1()
    {
        Time.timeScale = 1f;
        SaveLevel.Instance?.ResetLevel();
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        Time.timeScale = 1f;
        SaveLevel.Instance?.ResetLevel();
        SceneManager.LoadScene("Level2");
    }
    public void ReturnL3()
    {
        Time.timeScale = 1f;
        SaveLevel.Instance?.ResetLevel();
        SceneManager.LoadScene("Level3");
    }
}
