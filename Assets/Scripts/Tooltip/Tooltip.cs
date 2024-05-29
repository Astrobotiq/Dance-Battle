using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;

    public LayoutElement layoutElement;
    public int characterWrapLimit;
    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header = ""){
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive (true);
            headerField.text = header;
        }

        contentField.text = content;
        

    } 
    private void Update() 
    {
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length; 
            int contentlength = contentField.text.Length;
        
            layoutElement.enabled = (headerLength > characterWrapLimit || contentlength > characterWrapLimit) ? true : false; 
        }
        
        
        
        
    } 
}
