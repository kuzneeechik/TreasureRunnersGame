using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    public Image Image;
    public float TimeToChange;

    public void SwapScene(string scene)
    {
        StartCoroutine(Swap(scene));
    }

    private IEnumerator Swap(string scene)
    {
        float timer = 0f;
        Color color = Image.color;

        while (timer < TimeToChange)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / TimeToChange);
            Image.color = color;

            yield return null;
        }

        SceneManager.LoadScene(scene);
    }
}
