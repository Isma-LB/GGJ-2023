using UnityEngine;

[CreateAssetMenu(menuName = "Memories/DialogMessage")]
public class DialogMessage : ScriptableObject
{
    public Sprite characterSprite;
    [Range(1,20)] public float displayTime = 10;
    [TextArea(2,10)] public string dialogText;
}
