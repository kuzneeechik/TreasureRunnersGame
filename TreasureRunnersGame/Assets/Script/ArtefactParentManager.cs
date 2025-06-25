using UnityEngine;

public class ArtefactParentManager : MonoBehaviour
{
    private void Start()
    {
        if (SaveLevel.Instance == null)
        {
            return;
        }

        foreach (Transform child in transform)
        {
            Artefact_ID artefact = child.GetComponent<Artefact_ID>();
            if (artefact != null)
            {
                bool shouldBeActive = SaveLevel.Instance.Artifacts.Contains(artefact.Id);
                child.gameObject.SetActive(shouldBeActive);
            }
        }
    }
}
