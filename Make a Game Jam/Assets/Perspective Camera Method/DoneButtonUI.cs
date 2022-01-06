using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButtonUI : MonoBehaviour
{

    public void FinishJump()
    {
        FindObjectOfType<JumpSceneManager>().EndJump();
    }
    
}
