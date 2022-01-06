using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour
{

    [NonSerialized]
    public Person person;

    private PersonController pController;

    void Start()
    {
        pController = FindObjectOfType<PersonController>();
    }

    private void OnMouseDown()
    {
        if (pController.isTopDown && GameManager.instance != null && person != null)
        {
            GameManager.instance.NextIndex = person.index;   
        }
    }
    
}
