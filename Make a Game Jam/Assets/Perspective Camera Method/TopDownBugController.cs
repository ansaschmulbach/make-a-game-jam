using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownBugController : MonoBehaviour
{
    
    void Awake()
    {
        int index = GameManager.instance.CurrentPersonIndex;
        Vector3 targetPosRot = GameManager.instance.currentPeople[index].position;
        this.transform.position = targetPosRot;
    }

}
