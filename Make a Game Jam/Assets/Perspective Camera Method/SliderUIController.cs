using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUIController : MonoBehaviour
{

    [SerializeField] private Image slider;
    private SliderBarController insideBar;
    private SliderController buggy;
    
    void Start()
    {
        insideBar = slider.GetComponentInChildren<SliderBarController>();
        buggy = slider.GetComponentInChildren<SliderController>();
    }

    public void StartFlight()
    {
        this.gameObject.SetActive(true);
        insideBar.StartFlight();
        buggy.StartFlight();
    }

    public void EndFlight()
    {
        insideBar.EndFlight();
    }
    
}
