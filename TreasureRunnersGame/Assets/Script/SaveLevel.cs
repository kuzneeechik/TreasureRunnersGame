using System.Collections.Generic;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
    public static SaveLevel Instance;

    public HashSet<string> Levers = new HashSet<string>();
    public HashSet<string> Artifacts = new HashSet<string>();
    public HashSet<string> Doors = new HashSet<string>();

    public Vector3 Player1Position;
    public Vector3 Player2Position;

    public bool IsSave = false;
    public bool IsReturn = false;

    public bool Player1Pulled = false;
    public bool Player2Pulled = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
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
        Artifacts.Clear();
        Doors.Clear();
        IsSave = false;
        IsReturn = false;
    }
}
