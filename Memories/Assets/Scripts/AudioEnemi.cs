using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnemi : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] GameObject targetSelector;
    [SerializeField] AudioManager audioManager;
    public float alcance = 16f;
    Collider2D jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SeleccionarObjetivo();
    }
    private void SeleccionarObjetivo()
    {
        jugador = Physics2D.OverlapCircle(targetSelector.transform.position, alcance, playerLayer);

        if (jugador != null)
        {
            audioManager.IsChasing = true;
        }
        else
        {
            audioManager.IsChasing = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (targetSelector == null)
            return;

        Gizmos.DrawWireSphere(targetSelector.transform.position, alcance);
    }

}
