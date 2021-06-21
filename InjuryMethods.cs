using UnityEngine;
using System.Collections;
using TMPro;

public class InjuryMethods : MonoBehaviour
{
    public void HologramInjuryIndicator(float bodyPartHealth, float bodyPartMaxHealth, GameObject bodyPartObject, ref bool bodyPartBool)
    {
        float ratio = bodyPartHealth / bodyPartMaxHealth;

        if ((bodyPartHealth >= 80 & bodyPartHealth < 100))
        {
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.1098039f, 0.3137255f, 0.282353f));
        }
        if ((bodyPartHealth >= 60 & bodyPartHealth < 80))
        {
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2924528f, 0.2620723f, 0.07035421f));
        }
        if ((bodyPartHealth >= 40 & bodyPartHealth < 60))
        {
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2941177f, 0.1984426f, 0.07058822f));
        }
        if ((bodyPartHealth >= 20 & bodyPartHealth < 40))
        {
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2941177f, 0.1389249f, 0.07058822f));
        }
        if ((bodyPartHealth < 20) && !bodyPartBool)
        {
            bodyPartBool = true;
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2941177f, 0.07267015f, 0.07058822f));
        }
    }

    public void HologramInjuryIndicatorPause(float bodyPartHealth, float bodyPartMaxHealth, GameObject bodyPartObject, ref bool bodyPartBool)
    {
        float ratio = bodyPartHealth / bodyPartMaxHealth;

        if ((bodyPartHealth >= 80 & bodyPartHealth < 100))
        {
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.1098039f, 0.3137255f, 0.282353f));
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.1098039f, 0.3137255f, 0.282353f));
        }
        if ((bodyPartHealth >= 60 & bodyPartHealth < 80))
        {
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2924528f, 0.2620723f, 0.07035421f));
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.2924528f, 0.2620723f, 0.07035421f));
        }
        if ((bodyPartHealth >= 40 & bodyPartHealth < 60))
        {
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2941177f, 0.1984426f, 0.07058822f));
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.2941177f, 0.1984426f, 0.07058822f));
        }
        if ((bodyPartHealth >= 20 & bodyPartHealth < 40))
        {
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2941177f, 0.1389249f, 0.07058822f));
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.2941177f, 0.1389249f, 0.07058822f));
        }
        if ((bodyPartHealth < 20) && !bodyPartBool)
        {
            bodyPartBool = true;
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.2941177f, 0.07267015f, 0.07058822f));
            bodyPartObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.2941177f, 0.07267015f, 0.07058822f));
        }
    }

    public void TypeWriteText(TMP_Text typewriteText, string text)
    {
        typewriteText.GetComponent<UITextTypeWriter>().EraseText();
        typewriteText.GetComponent<UITextTypeWriter>().story = text;
        if (typewriteText.GetComponent<UITextTypeWriter>().typeCoroutine != null)
        {
            StopCoroutine(typewriteText.GetComponent<UITextTypeWriter>().PlayText());
        }
        typewriteText.GetComponent<UITextTypeWriter>().typeCoroutine = StartCoroutine(typewriteText.GetComponent<UITextTypeWriter>().PlayText());
    }

    public void TypeWriteTextRealtime(TMP_Text typewriteText, string text)
    {
        typewriteText.GetComponent<UIPauseScreenTextTypeWriter>().EraseText();
        typewriteText.GetComponent<UIPauseScreenTextTypeWriter>().story = text;
        if (typewriteText.GetComponent<UIPauseScreenTextTypeWriter>().typeCoroutine != null)
        {
            StopCoroutine(typewriteText.GetComponent<UIPauseScreenTextTypeWriter>().PlayText());
        }
        typewriteText.GetComponent<UIPauseScreenTextTypeWriter>().typeCoroutine = StartCoroutine(typewriteText.GetComponent<UIPauseScreenTextTypeWriter>().PlayText());
    }
}
