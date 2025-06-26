using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject question1;
    public GameObject question2;
    public GameObject question3;
    public GameObject question4;
    public GameObject question5;
    public GameObject bonus;

    void Update()
    {
        if (!question1.activeSelf && !question2.activeSelf &&
            !question3.activeSelf && !question4.activeSelf)
        {
            question5.SetActive(false);
            bonus.SetActive(true);
        }
    }
}