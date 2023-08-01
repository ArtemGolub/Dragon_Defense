using UnityEngine;

public abstract class ATower : MonoBehaviour, ITower
{
    public STower preset;
    public string TowerName { get; set; }
    public TowerType TowerType { get; set; }
    public GameObject model { get; set; }

    public void InitTower()
    {
        TowerName = preset.TowerName;
        TowerType = preset.TowerType;
        model = preset.model;
    }

}
