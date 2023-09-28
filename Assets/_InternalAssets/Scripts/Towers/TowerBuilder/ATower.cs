using UnityEngine;

public abstract class ATower : MonoBehaviour, ITower
{
    public STower preset;
    public static int _Id;
    public string TowerName { get; set; }
    public TowerType TowerType { get; set; }
    //public GameObject model { get; set; }
    public bool builded;

    public void InitTower()
    {
        TowerName = preset.TowerName;
        TowerType = preset.TowerType;
     //   model = preset.model;

        transform.gameObject.name += _Id;
        _Id++;
    }

    public abstract void OnBuild();
}
