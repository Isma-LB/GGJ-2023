using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    [SerializeField] GameObject enemigo;
    public List<MemoryItem> list;
    CollectableUI ui;
    DialogManager dialog;
    void Start()
    {
        ui = FindObjectOfType<CollectableUI>();
        dialog = FindObjectOfType<DialogManager>();
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
        float delay = 0;
        foreach (MemoryItem item in list)
        {
            if (item.name == collectable.memoryName)
            {
                item.collected = true;
                dialog.DisplayDialog(item.dialog);
                delay = item.dialog? item.dialog.displayTime : 0;
                collectable.Collect();
                Draw();
            }
            if(!item.collected){
                completed = false;
            }
        }
        if(completed){
            enemigo.SetActive(false);
            TriggerWinEvent();
        }
    }

    void Draw(){
        if(ui != null){
            ui.DisplayList(list);
        }
    }
    void TriggerWinEvent(){
        FindObjectOfType<GameManager>().winGame();
    }
}
