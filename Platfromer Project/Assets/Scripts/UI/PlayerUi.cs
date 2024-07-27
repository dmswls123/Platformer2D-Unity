using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public Scrollbar scrollbar;
    public PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SliderValueChange(float currentHP)
    {
        scrollbar.size = currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
