using UnityEngine;

public class BuildingMerge : MonoBehaviour
{
    private BuildingMerge objectToMerge;
    
    public void MergeBuildings()
    {
        if (objectToMerge == null) return;
        BuildingController.intstance.ShowUI();
        
        BuildingSystem.current.RestoreArea(objectToMerge.GetComponent<PlaceableObject>());

        var mergedStrategy = AttackStrategyFactory.CreateMergedStrategy(objectToMerge.GetComponent<AAttackTower>().AttackType,
            this.GetComponent<AAttackTower>().AttackType);

        var mergedPrefab = BuildingStrategy.current.CreateObject(AttackStrategyFactory.MAttackType(objectToMerge.GetComponent<AAttackTower>().AttackType,
            this.GetComponent<AAttackTower>().AttackType));

        Instantiate(mergedPrefab);
        
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
