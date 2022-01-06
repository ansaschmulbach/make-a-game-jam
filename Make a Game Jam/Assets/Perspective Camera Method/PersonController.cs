using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{

    [SerializeField] public bool isTopDown;
    [SerializeField] private GameObject personPrefab;
    [SerializeField] private GameObject furniturePrefab;
    [SerializeField] private Vector3 scale;
    // private List<PersonScript> peopleGOs;

    void Start()
    {
        CreatePeople();
        CreateFurniture();
    }

    void CreatePeople()
    {
        for (int i = 0; i < GameManager.instance.currentPeople.Count; i++)
        {
            Person p = GameManager.instance.currentPeople[i];
            p.index = i;
            GameObject go = Instantiate(personPrefab);
            PersonScript ps = go.AddComponent<PersonScript>();
            ps.person = p;
            go.transform.position = GetPosition(p);
            go.transform.rotation = Quaternion.identity;
            go.transform.localScale = scale;
            go.GetComponent<SpriteRenderer>().sprite = getSprite(p);
        }
    }

    void CreateFurniture()
    {
        for (int i = 0; i < GameManager.instance.furniture.Count; i++)
        {
            Furniture f = GameManager.instance.furniture[i];
            GameObject go = Instantiate(furniturePrefab);
            go.transform.position = GetPosition(f);
            go.transform.rotation = Quaternion.identity;
            go.transform.localScale = scale;
            go.GetComponent<SpriteRenderer>().sprite = getSprite(f);
        }
    }
    

    private Sprite getSprite(BarObject barObject)
    {
        if (isTopDown)
        {
            return barObject.TopDownSprite();
        }
        else
        {
            return barObject.FrontSprite();
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

    private Vector3 GetPosition(BarObject barObject)
    {
        if (isTopDown)
        {
            return barObject.GetPosition();
        }
        else
        {
            Vector3 pos = barObject.GetPosition();
            return new Vector3(pos.x, pos.z, pos.y);
        }
    }
    

}
