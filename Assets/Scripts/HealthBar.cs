using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Image _image;
    
    void Start()
    {

    }

    
    public void UpdateHealthBar(int health,int maxHealth)
    {
        _image.fillAmount = Mathf.Clamp((float)health / (float)maxHealth, 0f, 1f);
    }
}
