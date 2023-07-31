using UnityEngine;

public abstract class ATower : MonoBehaviour, ITower
{
    public STower preset;
    public TowerType TowerType { get; set; }
    public GameObject model { get; set; }

    public void InitTower()
    {
        TowerType = preset.TowerType;
        model = preset.model;
    }

}
