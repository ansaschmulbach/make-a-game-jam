using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{

    [SerializeField] private bool isTopDown;
    [SerializeField] private GameObject personPrefab;
    private List<PersonScript> peopleGOs;

    void Start()
    {
        
        peopleGOs = new List<PersonScript>();

        for (int i = 0; i < GameManager.instance.currentPeople.Count; i++)
        {
            Person p = GameManager.instance.currentPeople[i];
            p.index = i;
            GameObject go = Instantiate(personPrefab);
            //go.transform.position = p.position;
            PersonScript ps = go.AddComponent<PersonScript>();
            ps.person = p;
            go.transform.position = GetPosition(p);
            go.transform.rotation = Quaternion.identity;
            go.GetComponent<SpriteRenderer>().sprite = getSprite(p);
        }

    }

    private Sprite getSprite(Person p)
    {
        if (isTopDown)
        {
            return p.topDownSprite;
        }
        else
        {
            return p.forwardSprite;
        }
    }
    
    private Quaternion getRotation(Person p)
    {
        if (isTopDown)
        {
            return Quaternion.Euler(0, 0, 0);
        }
        else
        {
            return Quaternion.Euler(-90, 0, 0);
        }
    }

    private Vector3 GetPosition(Person p)
    {
        if (isTopDown)
        {
            return p.position;
        }
        else
        {
            return new Vector3(p.position.x, p.position.z, p.position.y);
        }
    }
    

}
