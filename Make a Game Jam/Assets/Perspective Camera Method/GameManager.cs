using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [NonSerialized] public int NextIndex;
    [NonSerialized] public int CurrentPersonIndex;
    [SerializeField] public Transform firstPosition;
    [SerializeField] public List<Person> peopleBlueprints;
    [NonSerialized] public List<Person> currentPeople;
    [SerializeField] public List<Furniture> furnitureBlueprints;
    [NonSerialized] public List<Furniture> furniture;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

        GameObject[] people = GameObject.FindGameObjectsWithTag("Person");
        currentPeople = new List<Person>();
        
        Person blueprintPerson = peopleBlueprints[0];
        Person newPerson = new Person(blueprintPerson.topDownSprite, blueprintPerson.forwardSprite);
        newPerson.position = firstPosition.position;
        currentPeople.Add(newPerson);
        
        for (int i = 0; i < people.Length; i++)
        {
            GameObject p = people[i];
            blueprintPerson = peopleBlueprints[i % peopleBlueprints.Count];
            newPerson = new Person(blueprintPerson.topDownSprite, blueprintPerson.forwardSprite);
            newPerson.position = p.transform.position;
            currentPeople.Add(newPerson);
            Destroy(p);
        }
        
        GameObject[] furnitureInScene = GameObject.FindGameObjectsWithTag("Furniture");
        furniture = new List<Furniture>();
        
        for (int i = 0; i < furniture.Count; i++)
        {
            GameObject f = furnitureInScene[i];
            Furniture blueprint = furnitureBlueprints[i % furnitureBlueprints.Count];
            Furniture newFurniture = new Furniture(blueprint.topDownSprite, blueprint.forwardSprite);
            newFurniture.position = f.transform.position;
            furniture.Add(newFurniture);
            Destroy(f);
        }

    }

    public void GameOver()
    {
        SceneManager.LoadScene("Top Down Screen");
    }
    
    
}
