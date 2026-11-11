using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreCount;
    [SerializeField] TextMeshProUGUI Timer;
    int score = 0;
    float survivalTime = 0f;

    void Start()
    {
        UpdateScoreUI();
    }

    
    void Update()
    {
        survivalTime += Time.deltaTime;
        Timer.text = survivalTime.ToString();

    }
    public void AddScore(int v)
    {
        score += v;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if(ScoreCount != null)
        {
            ScoreCount.text = score.ToString();
        }
    }
}
