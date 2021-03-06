using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int sceneProblem;



    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    
    public Text ScoreNumber;
    private double _totalScore;

    public void ScoreIncrement(double value)
    {
        _totalScore += value;
        ScoreNumber.text = $"{_totalScore.ToString("0")}";
        
        if (sceneProblem == 9)
        {
            AchievementController.Instance.UnlockAchievement(AchievementType.ScoreAchievement, _totalScore);
        }

    }


}
