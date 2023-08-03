public interface IBuildingView
{
    void Initialize(BuildingController controller);
    void UpdateButtonText(string text1, string text2);

    void HideUI();
    void ShowUI();
}
