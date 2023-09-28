using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO make buttons and text into Array
// TODO hide UI on building active
public class BuildingView : MonoBehaviour, IBuildingView
{
    public Button buttonTower1;
    public Button buttonTower2;
    
    private BuildingController prefabController;

    public void Initialize(BuildingController controller)
    {
        prefabController = controller;

        buttonTower1.onClick.AddListener(prefabController.OnButton1Click);
        buttonTower2.onClick.AddListener(prefabController.OnButton2Click);
    }
    
    public void HideUI()
    {
        buttonTower1.gameObject.SetActive(false);
        buttonTower2.gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        buttonTower1.gameObject.SetActive(true);
        buttonTower2.gameObject.SetActive(true);
    }
}
