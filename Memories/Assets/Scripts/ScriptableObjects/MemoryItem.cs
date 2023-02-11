using UnityEngine;

[CreateAssetMenu(menuName = "Memories/MemoryItem")]
public class MemoryItem : ScriptableObject
{
    public Sprite sprite;
    public bool collected = false;
}