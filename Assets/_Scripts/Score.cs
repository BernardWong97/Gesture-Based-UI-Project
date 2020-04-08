using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> entryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("Container");
        entryTemplate = entryContainer.Find("Entry");

        entryTemplate.gameObject.SetActive(false);

        AddEntry((int) Food.score);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreList.Sort((a, b) => (a.CompareTo(b)));
        highscores.highscoreList.Reverse();

        if (highscores.highscoreList.Count > 8)
            highscores.highscoreList.RemoveRange(8, highscores.highscoreList.Count - 8);

        entryTransformList = new List<Transform>();
        foreach(int score in highscores.highscoreList)
        {
            CreateEntry(score, entryContainer, entryTransformList);
        }
    }

    private void CreateEntry(int score, Transform container, List<Transform> transformList)
    {
        float templateHeight = 60f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;
            default:
                rankString = rank + "TH";
                break;
        }
        entryTransform.Find("Position").GetComponent<Text>().text = rankString;
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();

        transformList.Add(entryTransform);
    }

    public void AddEntry(int score)
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreList.Add(score);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<int> highscoreList;
    }
}
