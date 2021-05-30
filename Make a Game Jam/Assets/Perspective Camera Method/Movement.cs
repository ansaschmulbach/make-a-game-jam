using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float refSpeed;
    [SerializeField] private int dest;
    [SerializeField] private List<GameObject> phones;
    [SerializeField] private float yJumpHeight;

    #region Private Jump Variables

    private bool isJumping;
    private Vector3 targetPosition;
    private Vector3 startPosition;
    private float gravity;
    private float yVel;
    private float zSpeed;
    private float xSpeed;

    #endregion

    #region Cached Variables

    private SliderUIController uiScript;

    #endregion
    
    void Start()
    {
        uiScript = FindObjectOfType<SliderUIController>();
        uiScript.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            startPosition = this.transform.position;
            targetPosition = phones[dest].transform.position;
            isJumping = true;
            calcJumpVars();
            uiScript.StartFlight();

        }
        JumpHandler();
    }

    void calcJumpVars()
    {
        float xdiff = (targetPosition.x - startPosition.x);
        float zdiff = targetPosition.z - startPosition.z;
        if (xdiff == 0 && zdiff == 0)
        {
            return;
        } else if (zdiff == 0)
        {
            zSpeed = 0;
            xSpeed = refSpeed * Math.Sign(xdiff);
            yVel = (2 * yJumpHeight * xSpeed)/(xdiff / 2);
            gravity = (-2 * yJumpHeight * xSpeed * xSpeed) / ((xdiff / 2) * (xdiff / 2));
        }
        else if (xdiff == 0)
        {
            zSpeed = refSpeed * Math.Sign(zdiff);
            xSpeed = 0;
            yVel = (2 * yJumpHeight * zSpeed)/(zdiff / 2);
            gravity = (-2 * yJumpHeight * zSpeed * zSpeed) / ((zdiff / 2) * (zdiff / 2));
        } 
        else
        {
            float diff = (float) Math.Sqrt(xdiff * xdiff + zdiff * zdiff);
            xSpeed = (xdiff) / (diff / refSpeed);
            zSpeed = (zdiff)/ ((diff) / refSpeed);
            yVel = (2 * yJumpHeight * refSpeed)/(diff / 2);
            gravity = (-2 * yJumpHeight * refSpeed * refSpeed) / ((diff / 2) * (diff / 2));
        }
        
    }

    void JumpHandler()
    {
        if (!isJumping) return;
        Vector3 diff = targetPosition - this.transform.position;
        if (diff.x * diff.x + diff.z * diff.z <= 0.1f)
        {
            isJumping = false;
            this.transform.position = targetPosition;
            uiScript.gameObject.SetActive(false);
            return;
        }
        this.transform.position += Vector3.right * (xSpeed * Time.deltaTime);
        this.transform.position += Vector3.forward * (zSpeed * Time.deltaTime);
        this.transform.position += Vector3.up * (yVel * Time.deltaTime);
        this.transform.position += (0.5f * gravity * Time.deltaTime * Time.deltaTime) * Vector3.up;
        yVel += gravity * Time.deltaTime;

    }
    
    
}
