using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> entryTransformList;
    private static List<int> scoreList;

    private void Awake()
    {
        entryContainer = transform.Find("Container");
        entryTemplate = entryContainer.Find("Entry");

        entryTemplate.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("highscoreTable"))
        {
            string jsonString = PlayerPrefs.GetString("highscoreTable");
            scoreList = JsonUtility.FromJson<List<int>>(jsonString);
        }
        else
        {
            scoreList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
            string jsonString = JsonUtility.ToJson(scoreList);
            PlayerPrefs.SetString("highscoreTable", jsonString);
            PlayerPrefs.Save();
        }

        AddEntry((int) Food.score);

        entryTransformList = new List<Transform>();
        foreach(int score in scoreList)
        {
            CreateEntry(score, entryContainer, entryTransformList);
        }
    }

    private void CreateEntry(int score, Transform container, List<Transform> transformList)
    {
        float templateHeight = 90f;
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
        scoreList.Add(score);
        scoreList.Sort((a, b) => (a.CompareTo(b)));
        scoreList.Reverse();

        if(scoreList.Count > 8)
            scoreList.RemoveRange(8, scoreList.Count - 8);

        string json = JsonUtility.ToJson(scoreList);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
}
