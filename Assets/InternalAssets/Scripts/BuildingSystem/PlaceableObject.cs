using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlaceableObject : MonoBehaviour
{
    public bool Placed { get; private set; }
    public Vector3Int Size { get; private set; }
    private Vector3[] Vertices;
    public BoundsInt area;

    private void GetColliderPositionLocal()
    {
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
        Vertices = new Vector3[4];
        Vertices[0] = b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f;
        Vertices[1] = b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f;
        Vertices[2] = b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f;
        Vertices[3] = b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f;

    }
    
    private void CalculateSizeInCells()
    {
        Vector3Int[] vertices = new Vector3Int[Vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldPose = transform.TransformPoint(Vertices[i]);

            vertices[i] = BuildingSystem.current.gridLayout.WorldToCell(worldPose);
        }

        Size = new Vector3Int(Math.Abs((vertices[0] - vertices[1]).x),
            Math.Abs((vertices[0] - vertices[3]).y),
            1);
    }

    public Vector3 GetStartPosition()
    {
        return transform.position;
    }

    
    public void CalculatePositions()
    {
        GetColliderPositionLocal();
        CalculateSizeInCells();
        changeModelPosition();
    }

    public virtual void Place()
    {
        var meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        var material = meshRenderer.material;
        material.color = Color.white;

        ObjectDrag drag = gameObject.GetComponent<ObjectDrag>();
        Destroy(drag);

        Placed = true;

        OnPlaceEvents();

    }
    
    private void OnPlaceEvents()
    {
        // On build
    }

    public bool CanBePlaced()
    {
        Vector3Int positionInt = BuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (BuildingSystem.current.CanBePlaced(areaTemp))
        {
            return true;
        }

        return false;
    }

    private void changeModelPosition()
    {
        var model = transform.GetChild(0);
        
        var cellSize = BuildingSystem.current.gridLayout.cellSize;
        Vector3 centerPosition = new Vector3(
            (area.size.x - 1) * cellSize.x * 0.5f + transform.position.x,
            (area.size.z - 1) * cellSize.z * 0.5f + transform.position.y,
            (area.size.y - 1) * cellSize.y * 0.5f + transform.position.z
        );
        model.transform.position = centerPosition;


        var collider = transform.GetComponent<BoxCollider>();
        collider.center = model.transform.localPosition;
    }
}
