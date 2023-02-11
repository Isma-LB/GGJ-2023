using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<MemoryItem> list;
    CollectableUI ui;
    void Start()
    {
        ui = FindObjectOfType<CollectableUI>();
        Draw();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        MemoryElement collectable;
        if(other.TryGetComponent<MemoryElement>(out collectable)){
            Debug.Log("Collide with: "+ collectable.memoryName);
            foreach (MemoryItem item in list){
                if(item.name == collectable.memoryName){
                    item.collected = true;
                    collectable.Collect();
                    Draw();
                }
            }
        }
    }
    void Draw(){
        if(ui != null){
            ui.DisplayList(list);
        }
    }
}
