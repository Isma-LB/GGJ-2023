using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileWall : MonoBehaviour
{
    void OnEnable()
    {
        WallManager.onChangeState += UpdateWall;
    }
    void OnDisable()
    {
        WallManager.onChangeState -= UpdateWall;
    }
    void UpdateWall(bool isActive){
        Debug.Log("wall changed " + isActive);
        foreach(Transform child in transform){
            child.gameObject.SetActive(isActive);
        }
    }
}
