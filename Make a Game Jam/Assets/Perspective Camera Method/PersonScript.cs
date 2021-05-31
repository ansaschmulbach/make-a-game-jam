using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour
{

    [NonSerialized]
    public Person person;

    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        GameManager.instance.NextIndex = person.index;
        Debug.Log(person.index);
    }
    
}
