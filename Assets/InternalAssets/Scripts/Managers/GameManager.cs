using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]public int CurHealthPoints;
    public int MaxhHealthPoints = 5;
    
    
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CurHealthPoints = MaxhHealthPoints;
        HPController.intstance.UpdateText(CurHealthPoints);
        
    }
}
