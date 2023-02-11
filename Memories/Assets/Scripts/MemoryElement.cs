using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MemoryElement : MonoBehaviour
{
    [SerializeField] private MemoryItem item;
    SpriteRenderer spriteRenderer;

    public string memoryName { get => item.name; }

    void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.sprite;
    }
    public void Collect()
    {
        Destroy(gameObject);
    }
}
