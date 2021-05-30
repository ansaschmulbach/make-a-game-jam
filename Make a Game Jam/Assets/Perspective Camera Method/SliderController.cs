using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    
    [SerializeField] private float gravity;
    [SerializeField] private float clickVel;
    [SerializeField] private float holdVel;
    [SerializeField] private float maxDownVel;
    [SerializeField] private float maxYPos;
    [SerializeField] private float minYPos;
    private float yVel;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    
    private void FixedUpdate()
    {
        yVel -= gravity * Time.deltaTime;
        if (yVel <= maxDownVel) yVel = maxDownVel;
        if (Input.GetMouseButtonDown(0))
        {
            yVel += clickVel;
        }
        else if (Input.GetMouseButton(0))
        {
            yVel += holdVel * Time.deltaTime;
        }

        Vector3 currPos = rectTransform.anchoredPosition;
        if (currPos.y <= minYPos)
        {
            yVel = Math.Max(0, yVel);
            rectTransform.anchoredPosition = new Vector3(currPos.x, minYPos, currPos.z);
        } else if (currPos.y >= maxYPos)
        {
            yVel = Math.Min(0, yVel);
            rectTransform.anchoredPosition = new Vector3(currPos.x, maxYPos, currPos.z);
        }
        
        rectTransform.position += Vector3.up * (yVel * Time.deltaTime);

    }

    public void StartFlight()
    {
        float aPosX = rectTransform.anchoredPosition.x;
        rectTransform.anchoredPosition = new Vector2(aPosX, -42);
    }
    
}
