using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
   
    [SerializeField] public Slider healthSlider;
    [SerializeField] public Image fillImage;
    [SerializeField] public int maxHealth;
    [SerializeField] private Gradient gradient;
    [SerializeField] private float loseHealthSpeed;
    private float healthValue;
    
   
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        fillImage.color = gradient.Evaluate(1);
        healthValue = maxHealth;
    }

    public void LoseHealth(float deltaTime)
    {
        this.healthValue -= deltaTime * loseHealthSpeed;
        if (healthValue <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            UpdateHealthBar();
        }
    }

    public void UpdateHealthBar()
    {
        healthSlider.value = healthValue;
        fillImage.color = gradient.Evaluate(healthValue/maxHealth);
    }

    // public void Die()
    // {
    //     GameManager.instance.GameOver();   
    // }

    public IEnumerator Die()
    {
        SoundManager soundManager = FindObjectOfType<SoundManager>();
        soundManager.Play("Death");
        yield return new WaitForSeconds(2);
        GameManager.instance.GameOver();
        yield return null;
    }

}
