using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeMaxHealth(float MaxHeath)
    {
        slider.maxValue = MaxHeath;
    }

    public void ChangActualHealth(float CantHeath)
    {
        slider.value = CantHeath;
    }

    public void InicialiteHealthBar(float CantHealth)
    {
        ChangeMaxHealth(CantHealth);
        ChangActualHealth(CantHealth);
    }
}
