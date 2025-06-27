using UnityEngine;

public class OpenLevel : MonoBehaviour
{
    private void Start()
    {
        if (SaveLevel.Instance == null) return;

        foreach (Transform child in transform)
        {
            Door_ID level = child.GetComponent<Door_ID>();
            if (level == null) continue;

            bool shouldBeActive = SaveLevel.Instance.Levels.Contains(level.Id);

            child.gameObject.SetActive(shouldBeActive);
        }
    }
}
