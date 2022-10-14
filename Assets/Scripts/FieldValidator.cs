using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VolumeBox.Toolbox;

[RequireComponent(typeof(TMP_InputField))]
public class FieldValidator : MonoCached
{
    //TODO: add support for string and decimal types
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    private TMP_InputField field;

    public override void Rise()
    {
        field = GetComponent<TMP_InputField>();
        field.onValueChanged.AddListener(Validate);
    }

    public void Validate(string text)
    {
        float val;
        if (float.TryParse(text, out val))
        {
            val = Mathf.Clamp(val, minValue, maxValue);
            field.text = val.ToString();
        }
        else
        {
            field.text = minValue.ToString();
        }
    }    
}

