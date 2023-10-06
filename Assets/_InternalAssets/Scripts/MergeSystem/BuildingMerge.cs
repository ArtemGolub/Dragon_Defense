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

            //objectToMerge.GetComponent<AtackTower>().DisableTower();

        BuildingSystem.current.RestoreArea(transform.GetComponent<PlaceableObject>());
        BuildingSystem.current.RestoreArea(objectToMerge.GetComponent<PlaceableObject>());
        
        var mergedPrefab = BuildingStrategy.current.CreateObject(AttackStrategyFactory.MAttackType(objectToMerge.GetComponent<AAttackTower>().AttackType,
            this.GetComponent<AAttackTower>().AttackType));
        
        
        
        
        BuildingSystem.current.InitMergedPrefab(mergedPrefab, transform);
        mergedPrefab.GetComponent<MergedTower>().type1 = objectToMerge.GetComponent<AAttackTower>().AttackType;
        mergedPrefab.GetComponent<MergedTower>().type2 = this.GetComponent<AAttackTower>().AttackType;

        doOnce = true;
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