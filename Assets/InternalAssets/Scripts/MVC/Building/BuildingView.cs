using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingView : MonoBehaviour
{
    public Button button;
    private BuildingController buildingController;

    public void Initialize(BuildingController controller, GameObject prefab)
    {
        buildingController = controller;
        button.onClick.AddListener(OnClick);
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Building 1";
        // Настройте отображение кнопки в соответствии с префабом здания, например, установите текст кнопки или изображение.
    }

    private void OnClick()
    {
        buildingController.OnBuildingSelected();
    }
}
