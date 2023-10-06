using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;
    
    [Header("System settings")] public GridLayout gridLayout;
    [SerializeField] private Tilemap MainTileMap;
    [SerializeField] private Tilemap TempTileMap;

    [Header("Additional Settings")]
    [SerializeField] private Tile normalTile;
    [SerializeField] private Tile alreadyBuilded;

    
    [HideInInspector]public PlaceableObject objectToPlace;
    private static Dictionary<TileType, TileBase> TileBases = new Dictionary<TileType, TileBase>();
    private Vector3 prevPos;
    private BoundsInt prevArea; 
    private BoundsInt prevBuildingArea = new BoundsInt(); // initialize to an empty area
    private TileBase[] prevTileArray;
    private GameObject confirmCanvas;
    private Grid _grid;
    
    #region UnityMethods

    private void Awake()
    {
        current = this;
        _grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Start()
    {
        TileBases.Add(TileType.Empty, null);
        TileBases.Add(TileType.NormalTile, Resources.Load<TileBase>(@"Tiles\Normal"));
        TileBases.Add(TileType.PossibleBuild, Resources.Load<TileBase>(@"Tiles\Possible"));
        TileBases.Add(TileType.CantBuild, Resources.Load<TileBase>(@"Tiles\NotPossible"));
        TileBases.Add(TileType.Null, Resources.Load<TileBase>(@"Tiles\Null"));
        TileBases.Add(TileType.AlreadyBuilded, Resources.Load<TileBase>(@"Tiles\AlreadyBuilded"));
    }

    private void Update()
    {
        if (!objectToPlace)
        {
            _grid.enabled = false;
            _grid.transform.GetChild(0).GetComponent<TilemapRenderer>().enabled = false;
            _grid.transform.GetChild(1).GetComponent<TilemapRenderer>().enabled = false;
            return;
        }
        else
        {
            _grid.enabled = true;
            _grid.transform.GetChild(0).GetComponent<TilemapRenderer>().enabled = true;
            _grid.transform.GetChild(1).GetComponent<TilemapRenderer>().enabled = true;
        }
        
        if (!objectToPlace.Placed)
        {
            FollowBuilding();
        }
    }
    
    public void TryPlaceBuilding(bool isCancel)
    {
        if (!isCancel)
        {
            if (objectToPlace == null) return;
            if (objectToPlace.CanBePlaced())
            {
                objectToPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                TakeArea(start, objectToPlace.area.size);
                ClearArea();
                objectToPlace = null;
            }
            else
            {
                ClearArea();
               // Destroy(objectToPlace.gameObject);
            }
        }
        else
        {
            ClearArea();
            FollowBuilding();
           // Destroy(objectToPlace.gameObject);
        }
    }



    #endregion

    #region Utils

    public static Vector3 GetMosueWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red); // Draw a red ray from the camera

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.green); // Draw a green ray to the hit point
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = _grid.GetCellCenterWorld(cellPos);
        return position;
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;
        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        return array;
    }
    
    


    private static void FillTiles(TileBase[] arr, TileType type)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != null && arr[i] != TileBases[type])
            {
                arr[i] = TileBases[type];
            }
        }
    }
    

    #endregion

    #region Building Placement

    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = GetMosueWorldPosition();
        position = SnapCoordinateToGrid(position);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        
        var cellSize = gridLayout.cellSize;
       
        Vector3 centerPosition = new Vector3(
            (obj.GetComponent<PlaceableObject>().area.size.x - 1) * cellSize.x * 0.5f + (cellSize.x * 0.5f),
            0,
            ((obj.GetComponent<PlaceableObject>().area.size.y - 1) * cellSize.y * 0.5f + (cellSize.y * 0.5f))
            );


        obj.transform.position -= centerPosition;
        
        obj.GetComponent<PlaceableObject>().CalculatePositions();
        
        

        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
        FollowBuilding();
    }

    public void InitMergedPrefab(GameObject prefab, Transform placePose, IAttackStrategy mergedStrategy)
    {
        var position = SnapCoordinateToGrid(placePose.position);
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        
        var cellSize = gridLayout.cellSize;
       
        Vector3 centerPosition = new Vector3(
            (obj.GetComponent<PlaceableObject>().area.size.x - 1) * cellSize.x * 0.5f + (cellSize.x * 0.5f),
            0,
            ((obj.GetComponent<PlaceableObject>().area.size.y - 1) * cellSize.y * 0.5f + (cellSize.y * 0.5f))
        );


        obj.transform.position -= centerPosition;
        
        obj.GetComponent<PlaceableObject>().CalculatePositions();
        
        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
        
        objectToPlace.GetComponent<MergedTower>().attackStrategy = mergedStrategy;

       // TryPlaceBuilding(false);
    }

    public bool CanBePlaced(BoundsInt area)
    {
        TileBase[] baseArray = GetTilesBlock(area, MainTileMap);
        foreach (var b in baseArray)
        {
            if (b != TileBases[TileType.NormalTile])
            {
                if (b == TileBases[TileType.AlreadyBuilded])
                {
                    objectToPlace.transform.GetComponent<BuildingMerge>().MergeBuildings();
                }
                return false;
            }
        }
        return true;
    }

    private void TakeArea(Vector3Int start, Vector3Int size)
    {
        MainTileMap.BoxFill(start, alreadyBuilded, start.x, start.y,
            start.x + size.x - 1, start.y + size.y - 1);
        
        
        TempTileMap.BoxFill(start, normalTile, start.x, start.y,
            start.x + size.x - 1, start.y + size.y - 1);
    }

    public void RestoreArea(PlaceableObject objectToPlace)
    {
        if (objectToPlace != null) ;
        var start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
        var size = objectToPlace.area.size;
        
        MainTileMap.BoxFill(start, normalTile, start.x, start.y,
            start.x + size.x - 1, start.y + size.y - 1);
        
        
        TempTileMap.BoxFill(start, alreadyBuilded, start.x, start.y,
            start.x + size.x - 1, start.y + size.y - 1);


        MergedClearArea(objectToPlace);
    }

    
    #endregion
    
    #region ColorTiles

    private void ClearArea()
    {
        // Clear the current building area on the TempTileMap
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, TileType.Null);
        TempTileMap.SetTilesBlock(prevArea, toClear);
    
        // Clear the previous building area on the TempTileMap
        TileBase[] prevToClear = new TileBase[prevBuildingArea.size.x * prevBuildingArea.size.y * prevBuildingArea.size.z];
        FillTiles(prevToClear, TileType.Null);
        TempTileMap.SetTilesBlock(prevBuildingArea, prevToClear);
    }

    private void MergedClearArea(PlaceableObject objectToPlace)
    {
        // Clear the current building area on the TempTileMap
        TileBase[] toClear = new TileBase[objectToPlace.area.size.x * objectToPlace.area.size.y * objectToPlace.area.size.z];
        FillTiles(toClear, TileType.Null);
        TempTileMap.SetTilesBlock(objectToPlace.area, toClear);
    }
    
    
    private void FollowBuilding()
    {
        // Store the previous building area
        BoundsInt prevArea = prevBuildingArea;
    
        objectToPlace.area.position = gridLayout.WorldToCell(objectToPlace.gameObject.transform.position);
        BoundsInt buildingArea = objectToPlace.area;
    
        TileBase[] baseArray = GetTilesBlock(buildingArea, MainTileMap);
        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];
        
        
        var meshRenderer = objectToPlace.transform.GetChild(0).GetComponent<MeshRenderer>();
        var material = meshRenderer.material;
        
        
        for (int i = 0; i < baseArray.Length; i++)
        {
            if (baseArray[i] == TileBases[TileType.NormalTile])
            {
                tileArray[i] = TileBases[TileType.PossibleBuild];
                material.color = Color.green;
            }
            else
            {
                FillTiles(tileArray, TileType.CantBuild);
                material.color = Color.red;
                break;
            }
        }
    
        // Reset the previous area to its base state on the TempTileMap
        TileBase[] prevTileArray = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(prevTileArray, TileType.NormalTile);
        
        TempTileMap.SetTilesBlock(prevArea, prevTileArray);
    
        // Update the TempTileMap with the new potential placement
        TempTileMap.SetTilesBlock(buildingArea, tileArray);
    
        // Store the current building area as the new previous area
        prevBuildingArea = buildingArea;
    }
    

    #endregion
}
