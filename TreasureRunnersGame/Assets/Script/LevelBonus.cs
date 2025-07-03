using UnityEngine;

public class LevelBonus : MonoBehaviour
{
    public GameObject Bonus1;
    public GameObject Bonus2;
    public GameObject Bonus3;
    public GameObject Bonus4;
    public GameObject Bonus5;
    public GameObject Level;

    void Update()
    {
        if (Bonus1.activeSelf && Bonus2.activeSelf &&
            Bonus3.activeSelf && Bonus4.activeSelf && Bonus5.activeSelf)
        {
            Level.SetActive(true);
        }
    }
}