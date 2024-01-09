using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public bool isPlaying;
    public float gravityMagnitude;
    
    public UI_Ingame UIIngame;
    public PlayerController player;
    public List<GameObject> playerPrefabs;
    public int sessionScore;
    public Transform spawnPos;
    public UnityAction OnStartPlaying;
    public UnityAction OnGameOver;
    public void Awake()
    {
        
    }
    public void Init()
    {
        isPlaying = false;
        sessionScore = 0;
        int randomIndex = Random.Range(0, playerPrefabs.Count);
        player = Instantiate(playerPrefabs[randomIndex], spawnPos.position, Quaternion.identity).GetComponent<PlayerController>();
    }

    public void Start()
    {
        Init();
    }

    public void Update()
    {
        if (isPlaying == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartPlaying();
            }
        }
    }

    public void StartPlaying()
    {
        isPlaying = true;
        OnStartPlaying?.Invoke();
        UIIngame.HideReadyUI();
        UIIngame.ShowScore();
    }

    public void PlayFlashEfx()
    {
        UIIngame.Flash();
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
    }

    public void GetScore(int additionScore)
    {
        sessionScore += additionScore;
        UIIngame.UpdateScore(sessionScore);
        SoundManager.Instance.PlayOnce(SoundManager.scored);
    }

    public void GameOver()
    {
        DataManager.UpdateHighScore();
        DOVirtual.DelayedCall(1.0f, () => UIIngame.ShowGameOverUI(), true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
