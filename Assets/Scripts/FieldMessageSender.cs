using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VolumeBox.Toolbox;

public class FieldMessageSender : MonoCached
{
    [SerializeField] private TMP_InputField field;
    [SerializeField] private FieldType fieldType;
    [SerializeField] private Message message;

    [Inject] private Messager msg;
    
    public void Send()
    {
        if(field == null) return;

        object data = null;

        switch (fieldType)
        {
            case FieldType.String:
                data = field.text;
                break;
            case FieldType.Integer:
                int integer;
                if (int.TryParse(field.text, out integer))
                {
                    data = integer;
                }
                else
                {
                    data = 0;
                }
                break;
            case FieldType.Decimal:
                float dec;
                if (float.TryParse(field.text, out dec))
                {
                    data = dec;
                }
                else
                {
                    data = 0;
                }
                break;
        }
        
        msg.Send(message, data);
    }
}

public enum FieldType
{
    String,
    Integer,
    Decimal,
}
