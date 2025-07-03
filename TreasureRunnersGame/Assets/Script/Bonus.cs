using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject Question1;
    public GameObject Question2;
    public GameObject Question3;
    public GameObject Question4;
    public GameObject Question5;
    public GameObject BonusArtefact;

    void Update()
    {
        if (!Question1.activeSelf && !Question2.activeSelf &&
            !Question3.activeSelf && !Question4.activeSelf)
        {
            Question5.SetActive(false);
            BonusArtefact.SetActive(true);
        }
    }
}