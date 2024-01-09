using UnityEngine;


public class DataManager : MonoBehaviour
{
    public static int highScore;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        highScore = LoadHighScore();
    }
    
    public static void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public static int LoadHighScore()
    {
        
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        return highScore;
    }

    public static void UpdateHighScore()
    {
        if (GameManager.Instance.sessionScore > highScore)
        {
            SaveHighScore(GameManager.Instance.sessionScore);
            LoadHighScore();
        }
    }
    
    
}
