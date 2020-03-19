using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class Data_GameData : ScriptableObject
{
    [Header("CREDIT")]
    [Range(0, 120)]
    public int _credit = 0;

    [Header("SCORE")]
    public int _score = 0;

    [Header("LEADERBOARD")]

    public int[] _highscoreScore = new int[5] { 10000, 8000, 6000, 5000, 3000};

    public string[] _highscoreNames = new string[5] { "ARD", "LUV", "THV", "LOV", "NOB" };

}