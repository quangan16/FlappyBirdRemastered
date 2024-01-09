using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "EnvironmentData", fileName = "EnvironmentData")]
public class EnvironmentSO : ScriptableObject
{
    public Environment[] environments;
}

[Serializable]
public class Environment
{
     [SerializeField] public Texture backgroundImg;
     [SerializeField] public GameObject obstaclePrefab;
     [SerializeField] public Color32 scoreColor;
     [SerializeField] public DailyTime dailyTime;
}

public enum DailyTime
{
    DAY = 0,
    NIGHT = 1
} 
