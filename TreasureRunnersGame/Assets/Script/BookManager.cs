using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public Transform artifactParent; 
    public GameObject artifactPrefab;

    private void Start()
    {
        if (SaveLevel.Instance == null) return;

        foreach (string artifactId in SaveLevel.Instance.Artifacts)
        {
            GameObject newArtifact = Instantiate(artifactPrefab, artifactParent);
            newArtifact.name = artifactId;

            var text = newArtifact.GetComponentInChildren<UnityEngine.UI.Text>();
            if (text != null)
            {
                text.text = artifactId;
            }
        }
    }
}
