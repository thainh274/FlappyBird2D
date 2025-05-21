using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighScoreUi : MonoBehaviour
{
    public GameObject panel;
    public Text[] scoreTexts;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void ShowHighScores()
    {
        List<HighScoreEntry> scores = HighScoreManager.instance.GetHighScores();
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scores.Count)
                scoreTexts[i].text = $"{i + 1}. {scores[i].score}";
            else
                scoreTexts[i].text = $"{i + 1}. ---";
        }

        panel.SetActive(true);
    }

    public void CloseHighScores()
    {
        panel.SetActive(false);
    }
}
