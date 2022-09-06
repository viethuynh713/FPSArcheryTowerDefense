using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAppearance : MonoBehaviour
{
    [SerializeField] private Renderer matRen;
    [SerializeField] private float[] metallicValue;
    [SerializeField] private float[] smoothnessValue;
    [SerializeField] private Text colorText;
    [SerializeField] private Text metallicText;
    [SerializeField] private Text smoothnessText;
    int a;
    int b;
    int c;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        switch (a)
        {
            case 0:
                matRen.material.color = Color.red;
                colorText.text = "CurrentColor: " + a;
                a++;
                
                break;
            case 1:
                matRen.material.color = Color.blue;
                colorText.text = "CurrentColor: " + a;
                a++;

                break;
            case 2:
                matRen.material.color = Color.green;
                colorText.text = "CurrentColor: " + a;
                a = 0;

                break;
        }      
    }

    public void ChangeMetallic()
    {
        switch (b)
        {
            case 0:
                matRen.material.SetFloat("_Metallic", 0);
                metallicText.text = "CurrentMetallic: " + b;
                b++;

                break;
            case 1:
                matRen.material.SetFloat("_Metallic", 0.5f);
                metallicText.text = "CurrentMetallic: " + b;
                b++;

                break;
            case 2:
                matRen.material.SetFloat("_Metallic", 1f);
                metallicText.text = "CurrentMetallic: " + b;
                b = 0;

                break;
        }     
            
    }

    public void ChangeSmoothness()
    {
        switch (c)
        {
            case 0:
                matRen.material.SetFloat("_Smoothness", 0);
                smoothnessText.text = "CurrentSmoothness: " + c;
                c++;

                break;
            case 1:
                matRen.material.SetFloat("_Smoothness", 0.5f);
                smoothnessText.text = "CurrentSmoothness: " + c;
                c++;

                break;
            case 2:
                matRen.material.SetFloat("_Smoothness", 1f);
                smoothnessText.text = "CurrentSmoothness: " + c;
                c = 0;

                break;
        }
    }


}
