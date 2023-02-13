using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryRoot : MonoBehaviour
{

    [SerializeField] GameObject overlayPrefab;
    [SerializeField] RectTransform pictureTransform;
    [SerializeField, Range(0,2)] float growSpeed = 1;
    [SerializeField, Range(0,1)] float minScale = 0.25f;
    CollectManager collectManager;
    void Start()
    {
        collectManager = FindObjectOfType<CollectManager>();
        pictureTransform.localScale = Vector3.one * minScale;
        cleanChildren(pictureTransform);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        OverlayImages();
        StopAllCoroutines();
        StartCoroutine(fadeIn());
    }
    void OnTriggerExit2D(Collider2D other)
    {
        StopAllCoroutines();
        StartCoroutine(fadeOut());
    }
    void OverlayImages(){
        cleanChildren(pictureTransform);

        foreach(MemoryItem item in collectManager.list){
            if(item.collected){
                GameObject go = Instantiate(overlayPrefab,pictureTransform);
                go.GetComponent<Image>().sprite = item.memoryRootSprite;
            }
        } 
    }
    IEnumerator fadeIn(){
        float scale = minScale;
        while(scale < 1f){
            scale += Time.unscaledDeltaTime * growSpeed;
            yield return null;
            pictureTransform.localScale = Vector3.one * scale;
        }
        pictureTransform.localScale = Vector3.one;
    }
    IEnumerator fadeOut(){
        float scale = 1;
        while(scale > minScale){
            scale -= Time.unscaledDeltaTime * growSpeed;
            pictureTransform.localScale = Vector3.one * scale;
            yield return null;
        }
        pictureTransform.localScale = Vector3.one * minScale;
    }
    private void cleanChildren(RectTransform parent)
    {
        foreach (RectTransform child in parent){
            Destroy(child.gameObject);
        }
    }
}
