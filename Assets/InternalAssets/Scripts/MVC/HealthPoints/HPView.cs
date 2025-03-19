using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPView : MonoBehaviour, IHPView
{

    private HPController hpController;
    public TextMeshProUGUI hpText;
    
    public void Initialize(HPController controller)
    {
        hpController = controller;
    }

    public void HideUI()
    {
        hpText.transform.gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        hpText.transform.gameObject.SetActive(true);
    }

    public void UpdateUI(int currentHp)
    {
       hpText.text = currentHp + " / " + GameManager.instance.MaxhHealthPoints;
    }
    
}
