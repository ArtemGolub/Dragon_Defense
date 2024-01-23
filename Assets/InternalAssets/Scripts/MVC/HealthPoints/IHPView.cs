using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHPView
{
    void Initialize(HPController controller);
    void HideUI();
    void ShowUI();
    void UpdateUI(int currentHp);
}
