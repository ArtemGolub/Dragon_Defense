using UnityEngine;

public class BuildingController : MonoBehaviour
{

    
    private BuildingModel prefabModel;
    private IBuildingView prefabView;

    public GameObject Tower1;
    public GameObject Tower2;

    private void Start()
    {
        prefabModel = new BuildingModel();
        prefabView = GetComponent<IBuildingView>();
        prefabView.Initialize(this);
        
       
        ATower parameters1 = Tower1.GetComponent<ATower>();
        ATower parameters2 = Tower2.GetComponent<ATower>();

        InitializeView(parameters1.preset.TowerName, parameters2.preset.TowerName);
    }
    
    private void InitializeView(string prefabName1, string prefabName2)
    {
        prefabView = GetComponent<IBuildingView>();
        prefabView.Initialize(this);
        prefabView.UpdateButtonText(prefabName1, prefabName2);
    }

    public void OnButton1Click()
    {
        prefabModel.BuildingPrefab = Tower1;
        InstantiateSelectedPrefab();
    }

    public void OnButton2Click()
    {
        prefabModel.BuildingPrefab = Tower2;
        InstantiateSelectedPrefab();
    }

    private void InstantiateSelectedPrefab()
    {
        if (prefabModel.BuildingPrefab == null) return;
        BuildingSystem.current.InitializeWithObject(prefabModel.BuildingPrefab);
    }
}
