using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] Image charImage;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField, Range(0,2)] float fadeSpeed = 1;
    [SerializeField] List<DialogMessage> messages;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && messages.Count > 0){
            Debug.Log("Next dialog");

            DisplayDialog(messages[index % messages.Count]);
            index ++;
        }
    }
    public void DisplayDialog(DialogMessage dialog){
        StopAllCoroutines();
        charImage.sprite = dialog.characterSprite;
        dialogText.text = dialog.dialogText;
        StartCoroutine(fadeIn());
        StartCoroutine(fadeOut(dialog.displayTime));
    }
    IEnumerator fadeIn(){
        float alpha = 0;
        while(alpha < 1f){
            alpha += Time.unscaledDeltaTime * fadeSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }
    IEnumerator fadeOut(float delay = 0){
        yield return new WaitForSeconds(delay);
        float alpha = 1;
        while(alpha > 0){
            alpha -= Time.unscaledDeltaTime * fadeSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }
}
