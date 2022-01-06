using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderBarController : MonoBehaviour
{

    #region Inspector Variables

    [SerializeField] private float minYVel;
    [SerializeField] private float maxYVel;
    [SerializeField] private float minSeconds;
    [SerializeField] private float maxSeconds;
    [SerializeField] private float maxYPos;
    private float minYPos;
    [SerializeField] private float shrinkSpeed;
    [SerializeField] private float sizeMultiplier = 1;

    #endregion

    #region Cached Components

    [NonSerialized]
    private RectTransform rectTransform;

    #endregion

    #region Private Variables

    private float velocity;
    private Vector3 rawLocalScale;
    private float scaledMinYPos;
    private float scaledMaxYPos;

    #endregion

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rawLocalScale = rectTransform.localScale;
        scaledMaxYPos = maxYPos / sizeMultiplier;
        scaledMinYPos = minYPos / sizeMultiplier;
    }

    void Start()
    {
        minYPos = -maxYPos;
        StartCoroutine(RandomVelocity());
    }

    void Update()
    {
        Vector3 currPos = rectTransform.anchoredPosition;
        if (currPos.y <= scaledMinYPos)
        {
            velocity = Math.Max(0, velocity);
            rectTransform.anchoredPosition = new Vector3(currPos.x, scaledMinYPos, currPos.z);
        } else if (currPos.y >= scaledMaxYPos)
        {
            velocity = Math.Min(0, velocity);
            rectTransform.anchoredPosition = new Vector3(currPos.x, scaledMaxYPos, currPos.z);
        }
        rectTransform.position += Vector3.up * (velocity * Time.deltaTime);
        rawLocalScale -= Vector3.up * (shrinkSpeed * Time.deltaTime);
        rectTransform.localScale = new Vector3(rawLocalScale.x, rawLocalScale.y * sizeMultiplier, rawLocalScale.z);
        scaledMinYPos = minYPos / sizeMultiplier;
        scaledMaxYPos = maxYPos / sizeMultiplier;
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

    public bool InYBounds(float y)
    {
        float yCenter = rectTransform.position.y;
        float yHeight = rectTransform.rect.height/2;
        return (y <= yCenter + yHeight && y >= yCenter - yHeight);

    }

    public void EndFlight()
    {
        this.sizeMultiplier = 1;
    }

}
