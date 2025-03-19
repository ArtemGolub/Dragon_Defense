using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Custom/New Item Data")]
public class ItemData : ScriptableObject
{
    public string Name;
    public int ID;
}
