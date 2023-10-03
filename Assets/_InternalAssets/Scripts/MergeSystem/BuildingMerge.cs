using UnityEngine;

public class BuildingMerge : MonoBehaviour
{
    private BuildingMerge objectToMerge;
    
    public void MergeBuildings()
    {
        if (objectToMerge == null) return;
        BuildingController.intstance.ShowUI();
        
        BuildingSystem.current.RestoreArea(objectToMerge.GetComponent<PlaceableObject>());

        AttackStrategyFactory.CreateMergedStrategy(objectToMerge.GetComponent<AAttackTower>().AttackType,
            this.GetComponent<AAttackTower>().AttackType);
        
        
        
        
        Destroy(objectToMerge.gameObject);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var placeableObject = other.transform.GetComponent<BuildingMerge>();
        if (placeableObject)
        {
            objectToMerge = placeableObject;
        }
    }
}
