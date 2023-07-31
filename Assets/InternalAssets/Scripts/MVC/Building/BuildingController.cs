using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private BuildingModel buildingModel;
    private BuildingView buildingView;

    public void InitializeWithObject(GameObject prefab)
    {
        buildingModel = new BuildingModel(prefab);
        buildingView.Initialize(this, prefab);
    }

    public void OnBuildingSelected()
    {
        // Обработайте событие выбора здания, например, создайте объект здания на сцене.
        // Вы можете использовать buildingModel.Prefab для получения префаба здания.
    }
}
