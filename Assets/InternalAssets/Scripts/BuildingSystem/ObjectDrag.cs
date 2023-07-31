using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 offSet;

    private void OnMouseDown()
    {
        offSet = transform.position - BuildingSystem.GetMosueWorldPosition();
        
    }

    private void OnMouseDrag()
    {
        Vector3 pos = BuildingSystem.GetMosueWorldPosition() + offSet;
        transform.position = BuildingSystem.current.SnapCoordinateToGrid(pos);
    }
    
    private void OnMouseUp()
    {
        BuildingSystem.current.TryPlaceBuilding(false);
    }
}