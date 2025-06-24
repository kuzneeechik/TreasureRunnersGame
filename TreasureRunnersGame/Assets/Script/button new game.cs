using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

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
    public void Setting(GameObject objPrefab)
    {
        Instantiate(objPrefab);
    }
    public void Continue()
    {
        SceneManager.LoadScene("NewGame");
    }
    public void Level1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
    public void ReturnL3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }
}
