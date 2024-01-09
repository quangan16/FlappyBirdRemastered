using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu_Manager : MonoBehaviour
{
    private static string playScene = "GamePlay";
    [SerializeField] private Button playButton;
    [SerializeField] private Animator fadeAnim;
    private static readonly int fade = Animator.StringToHash("FadeEfx");
    private static readonly int fadeDirection = Animator.StringToHash("fadeDirection");

    public void Awake()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(StartGame);
        }
        
    }

    private void Start()
    {
        
        fadeAnim.Play(fade, -1, 0.1f);
    }

  
    
    private void StartGame()
    {
        fadeAnim.SetFloat(fadeDirection, -1);
        fadeAnim.Play(fade, -1, 1.0f);
        
    }

    
}
