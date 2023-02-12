using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedScript : MonoBehaviour
{
    public float speed = 5.0f;
    private float startTime;
    [SerializeField] GameObject Pared;

    void Start()
    {
        startTime = Time.time + Random.Range(15.0f, 30.0f);
    }

    void Update()
    {
        if (Time.time >= startTime)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
            transform.position += randomDirection.normalized * speed * Time.deltaTime;
            Debug.Log("Cambio");
            Pared.SetActive(!Pared.activeSelf); 
            startTime = Time.time + Random.Range(10.0f, 15.0f);
        }
    }
}
