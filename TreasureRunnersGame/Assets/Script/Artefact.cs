using UnityEngine;

public class Artefact : MonoBehaviour
{
    public string Id;

    private void Start()
    {
        if (SaveLevel.Instance !=  null &&
            SaveLevel.Instance.Artifacts.Contains(Id))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            if (SaveLevel.Instance != null)
            {
                SaveLevel.Instance.AddArtifact(Id);
            }

            Destroy(gameObject);
        }
    }
}
