using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   
    private const int Low_HP = 3;
    [SerializeField]
    private Image image;
    [SerializeField]
    private RectTransform healthBarreRect;
    [SerializeField]
    private Text healthBarText;
    [SerializeField]
    private Color colorLowHealth;
    private Color colorHealth;



    public Text HealthBarText { get { return healthBarText; } }
    private void Start()
    {
        colorHealth = GetComponentInChildren<Image>().color;
    }
    

    public void SetHealth( float cur, float max)
    {
       
        float value = cur / max;
        healthBarreRect.localScale = new Vector3(value, healthBarreRect.localScale.y, healthBarreRect.localScale.z);

        // changement couleur barre si endessous de 50
       if( cur <= Low_HP)
        {
            image.color = colorLowHealth;
        }
        if (cur >= Low_HP)
        {
            image.color = colorHealth;
        }
        healthBarText.text = $"{cur}/{max} HP";
    }
}
