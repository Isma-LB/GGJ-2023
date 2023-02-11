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
        foreach(MemoryItem item in list){
            item.collected = false;
        }
        Draw();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        MemoryElement collectable;
        if(other.TryGetComponent<MemoryElement>(out collectable))
        {
            HandleCollectable(collectable);
        }
    }

    private void HandleCollectable(MemoryElement collectable)
    {
        bool completed = true;
        foreach (MemoryItem item in list)
        {
            if (item.name == collectable.memoryName)
            {
                item.collected = true;
                collectable.Collect();
                Draw();
            }
            if(!item.collected){
                completed = false;
            }
        }
        if(completed){
            FindObjectOfType<GameManager>().winGame();
        }
    }

    void Draw(){
        if(ui != null){
            ui.DisplayList(list);
        }
    }
}
