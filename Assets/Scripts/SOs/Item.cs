using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items", order = 1)]
public class Item : ScriptableObject
{
    public GameObject Prefab;
    public string Name;
}
