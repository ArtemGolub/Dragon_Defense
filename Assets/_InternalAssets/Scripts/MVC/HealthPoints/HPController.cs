using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public static HPController intstance;

    private HpModel _hpModel;
    private IHPView hpView;

    private void Awake()
    {
        intstance = this;

        _hpModel = new HpModel();
        hpView = GetComponent<IHPView>();
        hpView.Initialize(this);
    }

    public void ShowUI()
    {
        hpView.ShowUI();
    }

    public void HideUI()
    {
        hpView.HideUI();
    }

    public void UpdateText(int currentHp)
    {
        hpView.UpdateUI(currentHp);
    }
}