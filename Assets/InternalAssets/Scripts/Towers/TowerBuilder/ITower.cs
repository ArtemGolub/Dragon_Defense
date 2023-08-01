
using UnityEngine;

public interface ITower
{
    public string TowerName { get; set; }
    public TowerType TowerType { get; set; }
    GameObject model { get; set; }
    void InitTower();
}
