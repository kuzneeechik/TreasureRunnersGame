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

            if (artefact == null)
            {
                continue;
            }

            bool shouldBeActive = SaveLevel.Instance.ArtifactsBook.Contains(artefact.Id);

            child.gameObject.SetActive(shouldBeActive);

            if (artefact.StoredObject != null)
            {
                GameObject targetObject = null;

                if (artefact.StoredObject is GameObject gameObj)
                {
                    targetObject = gameObj;
                }
                else if (artefact.StoredObject is Component component)
                {
                    targetObject = component.gameObject;
                }

                if (targetObject != null)
                {
                    targetObject.SetActive(!shouldBeActive);
                }
            }
        }
    }
}