using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;
using static UnityEngine.Rendering.DebugUI.Table;

public class buttonAudio : MonoBehaviour
{

   public AudioSource sonido;


    // Start is called before the first frame update
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PlaySound);
    }
    void PlaySound()
    {
        sonido.Play();
    }
}
/*In this script, the Start() method gets a reference to the Button component attached to the same GameObject, and adds a listener for the onClick event. When the button is clicked, the PlaySound() method is called, which plays the audio clip.

Assign the Audio Source component to the script: In the Unity Editor, select the GameObject with the Audio Source component and the script attached to it. In the script component, drag and drop the Audio Source component from the Inspector to the sound field in the script.
Now, when you run your project, clicking the button will play the audio clip.*/






