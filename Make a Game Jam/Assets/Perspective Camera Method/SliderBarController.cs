using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SliderBarController : MonoBehaviour
{

    [SerializeField] private float velocity;
    [SerializeField] private float minYVel;
    [SerializeField] private float maxYVel;
    [SerializeField] private float minSeconds;
    [SerializeField] private float maxSeconds;
    [SerializeField] private float maxYPos;
    [SerializeField] private float minYPos;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        StartCoroutine(RandomVelocity());
    }

    void Update()
    {
        Vector3 currPos = rectTransform.anchoredPosition;
        if (currPos.y <= minYPos)
        {
            velocity = Math.Max(0, velocity);
            rectTransform.anchoredPosition = new Vector3(currPos.x, minYPos, currPos.z);
        } else if (currPos.y >= maxYPos)
        {
            velocity = Math.Min(0, velocity);
            rectTransform.anchoredPosition = new Vector3(currPos.x, maxYPos, currPos.z);
        }
        rectTransform.position += Vector3.up * (velocity * Time.deltaTime);   
        
    }

    IEnumerator RandomVelocity()
    {
        velocity = Random.Range(minYVel, maxYVel);
        velocity *= new System.Random().Next(0, 2) * 2 - 1;
        float randSeconds = Random.Range(minSeconds, maxSeconds);
        yield return new WaitForSeconds(randSeconds);
        yield return RandomVelocity();
    }

    public void StartFlight()
    {
        float aPosX = rectTransform.anchoredPosition.x;
        rectTransform.anchoredPosition = new Vector2(aPosX, -50);
    }
    
}
