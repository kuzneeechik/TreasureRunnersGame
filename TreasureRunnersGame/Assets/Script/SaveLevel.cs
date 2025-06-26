using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
    public static SaveLevel Instance;

    public HashSet<string> Artifacts = new HashSet<string>();
    public HashSet<string> Levels = new HashSet<string>();

    public HashSet<string> Levers = new HashSet<string>();
    public HashSet<string> LocalArtifacts = new HashSet<string>();

    public Vector3 Player1Position;
    public Vector3 Player2Position;

    public bool IsSave = false;
    public bool IsReturn = false;

    public bool Player1Pulled = false;
    public bool Player2Pulled = false;

    private string path;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            path = Path.Combine(Application.persistentDataPath, "save.json");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddLever(string leverId)
    {
        if (!Levers.Contains(leverId))
        { 
            Levers.Add(leverId); 
        }
    }

    public void AddArtifact(string artifactId)
    {
        if (!Artifacts.Contains(artifactId))
        {
            LocalArtifacts.Add(artifactId);
            Artifacts.Add(artifactId);
        }
    }

    public void AddLevel(string levelId)
    {
        if (!Levels.Contains(levelId))
        {
            Levels.Add(levelId);
        }
    }

    public void SavePlayerPositions(Vector3 player1, Vector3 player2)
    {
        Player1Position = player1;
        Player2Position = player2;
        IsSave = true;
    }

    public void RestorePlayerPositions(Transform player1, Transform player2)
    {
        if (!IsSave) return;

        player1.position = Player1Position;
        player2.position = Player2Position;
    }

    public void ResetLevel()
    {
        Levers.Clear();
        LocalArtifacts.Clear();

        IsSave = false;
        IsReturn = false;

        Player1Pulled = false;
        Player2Pulled = false;
    }

    public void ResetAll()
    {
        Levers.Clear();
        LocalArtifacts.Clear();
        Artifacts.Clear();
        Levels.Clear();

        IsSave = false;
        IsReturn = false;

        Player1Pulled = false;
        Player2Pulled = false;
    }

    private class SaveData
    {
        public List<string> Artifacts;
        public List<string> Levels;
    }

    public void SaveToDisk()
    {
        var data = new SaveData
        {
            Artifacts = new List<string>(Artifacts),
            Levels = new List<string>(Levels),
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public void LoadFromDisk()
    {
        if (!File.Exists(path))
        { 
            return; 
        }

        string json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<SaveData>(json);

        Levers.Clear();
        Artifacts.Clear();
        Levels.Clear();

        Artifacts = new HashSet<string>(data.Artifacts);
        Levels = new HashSet<string>(data.Levels);
    }
}