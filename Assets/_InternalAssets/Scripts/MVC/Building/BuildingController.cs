using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public static BuildingController intstance;
    
    private BuildingModel prefabModel;
    private IBuildingView prefabView;
    
    public GameObject Tower1;
    public GameObject Tower2;
    public GameObject Tower3;

    private void Start()
    {
        intstance = this;
        
        prefabModel = new BuildingModel();
        prefabView = GetComponent<IBuildingView>();
        prefabView.Initialize(this);
        
        InitializeView();
    }
    
    private void InitializeView()
    {
        prefabView = GetComponent<IBuildingView>();
        prefabView.Initialize(this);
    }

    public void OnButton1Click()
    {
        prefabModel.BuildingPrefab = Tower1;
        prefabView.HideUI();
        InstantiateSelectedPrefab();
    }

    public void OnButton2Click()
    {
        prefabModel.BuildingPrefab = Tower2;
        prefabView.HideUI();
        InstantiateSelectedPrefab();
    }

    public void OnButton3Click()
    {
        prefabModel.BuildingPrefab = Tower3;
        prefabView.HideUI();
        InstantiateSelectedPrefab();
    }

    public void ShowUI()
    {
        prefabView.ShowUI();
    }

    private void InstantiateSelectedPrefab()
    {
        if (prefabModel.BuildingPrefab == null) return;
        if(BuildingSystem.current.objectToPlace != null) return;
        BuildingSystem.current.InitializeWithObject(prefabModel.BuildingPrefab);
    }
}
