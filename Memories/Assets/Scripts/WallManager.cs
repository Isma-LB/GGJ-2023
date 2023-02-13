using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public delegate void UpdateFunction(bool isActive);
    public static event UpdateFunction onChangeState;
    [SerializeField, Range(0,60)] float eventPeriod = 5;
    [SerializeField, Range(0,10)] float randomTime = 2.5f;
    [SerializeField] bool isActive = false;
    // Start is called before the first frame update
    float nextTime = 0;

    // Update is called once per frame
    void Update()
    {
        nextTime -= Time.deltaTime;
        if(nextTime < 0){
            //event
            isActive = !isActive;
            if(onChangeState != null){
                onChangeState(isActive);
            }
            nextTime = eventPeriod + Random.Range(-randomTime,randomTime);
        }
    }
}
