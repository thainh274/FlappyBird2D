using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;

    private const string HighScoreKey = "HighScoreTable";

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddNewScore(int score)
    {
        string jsonString = PlayerPrefs.GetString(HighScoreKey, "");
        HighScoreList scoreList = string.IsNullOrEmpty(jsonString)
            ? new HighScoreList { highScoreEntryList = new List<HighScoreEntry>() }
            : JsonUtility.FromJson<HighScoreList>(jsonString);

        scoreList.highScoreEntryList.Add(new HighScoreEntry { score = score });

        scoreList.highScoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));
        if (scoreList.highScoreEntryList.Count > 5)
            scoreList.highScoreEntryList.RemoveRange(5, scoreList.highScoreEntryList.Count - 5);

        PlayerPrefs.SetString(HighScoreKey, JsonUtility.ToJson(scoreList));
        PlayerPrefs.Save();
    }

    public List<HighScoreEntry> GetHighScores()
    {
        string jsonString = PlayerPrefs.GetString(HighScoreKey, "");
        if (string.IsNullOrEmpty(jsonString))
            return new List<HighScoreEntry>();

        return JsonUtility.FromJson<HighScoreList>(jsonString).highScoreEntryList;
    }
}
