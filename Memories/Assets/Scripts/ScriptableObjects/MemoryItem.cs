using UnityEngine;

[CreateAssetMenu(menuName = "Memories/MemoryItem")]
public class MemoryItem : ScriptableObject
{
    public Sprite sprite;
    public Sprite memoryRootSprite;
    public bool collected = false;
    public DialogMessage dialog;
}