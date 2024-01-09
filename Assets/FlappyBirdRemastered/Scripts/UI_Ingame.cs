using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_Ingame : MonoBehaviour
{
    private static readonly int fadeEfx = Animator.StringToHash("FadeEfx");
    private static readonly int flashEfx = Animator.StringToHash("FlashEfx");
    
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject readyUI;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI finalScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    [SerializeField] private Image medalDisplay;
    [SerializeField] private Sprite[] medalSprites;
    [SerializeField] private RawImage environmentImg;
    [SerializeField] private EnvironmentSO environmentSo;
    [SerializeField] private DailyTime environmentTime;
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        FadeIn();
        SetRandomEnvironment();
        scoreTxt.gameObject.SetActive(false);
        medalDisplay.gameObject.SetActive(false);
        
    }

    public void SetRandomEnvironment()
    {
        int randomIndex = Random.Range(0, Enum.GetNames(typeof(DailyTime)).Length);
        environmentTime = environmentSo.environments[randomIndex].dailyTime;
        environmentImg.texture = environmentSo.environments[(int)environmentTime].backgroundImg;
        scoreTxt.color = environmentSo.environments[(int)environmentTime].scoreColor;
        SpawnerManager.obstaclePrefab = environmentSo.environments[(int)environmentTime].obstaclePrefab;
    }
    public void HideReadyUI()
    {
        readyUI.SetActive(false);
    }

    public void ShowScore()
    {
        scoreTxt.gameObject.SetActive(true);
    }

    public void FadeIn()
    {
        Debug.Log("cc");
        // anim.Play(fadeEfx, -1, 0.1f);
    }

    public void Flash()
    {
        anim.Play(flashEfx, -1, 0.0f);
    }

    public void UpdateScore(int currentScore)
    {
        scoreTxt.text = currentScore.ToString();
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        finalScoreTxt.text = GameManager.Instance.sessionScore.ToString();
        highScoreTxt.text = DataManager.highScore.ToString();
        if (GameManager.Instance.sessionScore >= 20)
        {
            medalDisplay.sprite = medalSprites[1];
            medalDisplay.gameObject.SetActive(true);
        }
        else if(GameManager.Instance.sessionScore >= 10)
        {
            medalDisplay.sprite = medalSprites[0];
            medalDisplay.gameObject.SetActive(true);
        }
        
    }

    public void Replay()
    {
        GameManager.Instance.Replay();
    }
    
  
}
