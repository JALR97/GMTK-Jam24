using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private Image backG;
    [SerializeField] private TMP_Text Text1;
    [SerializeField] private TMP_Text Text2;

    [SerializeField] private float fadeTime = 6;
    private float timer = 7;
    private void Update()
    {
        backG.color = new Color(backG.color.r, backG.color.g, backG.color.b, timer / fadeTime);
        Text1.color = new Color(Text1.color.r, Text1.color.g, Text1.color.b, timer / fadeTime);
        Text2.color = new Color(Text2.color.r, Text2.color.g, Text2.color.b, timer / fadeTime);
        
        timer -= Time.deltaTime;
    }
}
