using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO make buttons and text into Array
// TODO hide UI on building active
public class BuildingView : MonoBehaviour, IBuildingView
{
    public Button buttonTower1;
    public Button buttonTower2;
    
    public TextMeshProUGUI buttonText1;
    public TextMeshProUGUI buttonText2;

    private BuildingController prefabController;

    public void Initialize(BuildingController controller)
    {
        prefabController = controller;
        buttonTower1.onClick.AddListener(prefabController.OnButton1Click);
        buttonTower2.onClick.AddListener(prefabController.OnButton2Click);
    }
    
    public void UpdateButtonText(string text1, string text2)
    {
        buttonText1.text = text1;
        buttonText2.text = text2;
    }
}
