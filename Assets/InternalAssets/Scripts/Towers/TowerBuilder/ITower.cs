
using UnityEngine;

public interface ITower
{
    public TowerType TowerType { get; set; }
    GameObject model { get; set; }
    void InitTower();
}
