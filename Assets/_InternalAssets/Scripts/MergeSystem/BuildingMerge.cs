using UnityEngine;

public class BuildingMerge : MonoBehaviour
{
    private BuildingMerge objectToMerge;
    private bool doOnce;
    
    public void MergeBuildings()
    {
        if (objectToMerge == null) return;
        if(transform.GetComponent<PlaceableObject>().Placed) return;
        if (doOnce) return;
        BuildingController.intstance.ShowUI();

        objectToMerge.GetComponent<AtackTower>().DisableTower();

        BuildingSystem.current.RestoreArea(transform.GetComponent<PlaceableObject>());
        BuildingSystem.current.RestoreArea(objectToMerge.GetComponent<PlaceableObject>());

        
        doOnce = true;
        Destroy(objectToMerge.gameObject);
        Destroy(this.gameObject);
        
        // var mergedStrategy = AttackStrategyFactory.CreateMergedStrategy(objectToMerge.GetComponent<AAttackTower>().AttackType,
        //     this.GetComponent<AAttackTower>().AttackType);
        //
        // var mergedPrefab = BuildingStrategy.current.CreateObject(AttackStrategyFactory.MAttackType(objectToMerge.GetComponent<AAttackTower>().AttackType,
        //     this.GetComponent<AAttackTower>().AttackType));

        // BuildingSystem.current.InitMergedPrefab(mergedPrefab, transform, mergedStrategy);
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