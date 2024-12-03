using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Stamina : MonoBehaviour
{

    //stamina variables
    public float currentStamina;
    public float maxStamina = 100f;
    public Slider staminaBar;

    public float decreaseStamina;
    // Use this for initialization
    void Start()
    {

        currentStamina = maxStamina;
        displayStamina();
        decreaseStamina = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        displayStamina();

    }

    public void displayStamina()
    {

        float ratio = 0f;
        ratio = currentStamina / maxStamina;

        staminaBar.value = ratio;
        if (currentStamina <= 0)
        {
            currentStamina = 0;
        }
        InvokeRepeating("generateStamina", 5f, 10f);

        generateStamina();



    }
    public void generateStamina()
    {
        if (currentStamina <= maxStamina)
            {
                currentStamina += 0.03f;
           
            }
        if (currentStamina <= 0f)
        {
            currentStamina += 0.05f;
        }
    }
    public void useStamina()
    {
        currentStamina -= decreaseStamina;
    }
}
