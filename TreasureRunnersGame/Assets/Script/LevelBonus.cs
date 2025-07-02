using UnityEngine;

public class LevelBonus : MonoBehaviour
{
    public GameObject bonus1;
    public GameObject bonus2;
    public GameObject bonus3;
    public GameObject bonus4;
    public GameObject bonus5;
    public GameObject level;

    void Update()
    {
        if (bonus1.activeSelf && bonus2.activeSelf &&
            bonus3.activeSelf && bonus4.activeSelf && bonus5.activeSelf)
        {
            level.SetActive(true);
        }
    }
}