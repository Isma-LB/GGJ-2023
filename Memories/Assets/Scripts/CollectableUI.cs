using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableUI : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Color tintColor = Color.grey;
    public void DisplayList(List<MemoryItem> list){
        cleanChildren();
        foreach (MemoryItem item in list)
        {
            GameObject go = Instantiate(itemPrefab,transform);
            Image img = go.GetComponent<Image>();
            img.sprite = item.sprite;
            img.color = item.collected? Color.white : tintColor;
        }
    }

    private void cleanChildren()
    {
        foreach (Transform child in transform){
            Destroy(child.gameObject);
        }
    }
}
