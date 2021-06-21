using UnityEngine;
using System.Collections;
using TMPro;

public class InjuryFunctionScreen : InjuryMethods
{
    [SerializeField] private InjurySystem injurySystem;

    //[SerializeField] private GameObject HealthFunctionUI;

    [SerializeField] private TMP_Text functionLeftLegText;
    [SerializeField] private TMP_Text functionRightLegText;
    [SerializeField] private TMP_Text functionBothLegsText;
    [SerializeField] private TMP_Text functionLeftArmText;
    [SerializeField] private TMP_Text functionRightArmText;
    [SerializeField] private TMP_Text functionTorsoText;
    [SerializeField] private TMP_Text functionHeadText;

    [SerializeField] public bool leftLegInjured;
    [SerializeField] public bool rightLegInjured;
    [SerializeField] public bool bothLegsInjured;
    [SerializeField] public bool leftArmInjured;
    [SerializeField] public bool rightArmInjured;
    [SerializeField] public bool torsoInjured;
    [SerializeField] public bool headInjured;

    // Hologram body parts
    [SerializeField] private GameObject leftLegHologramObj;
    [SerializeField] private GameObject rightLegHologramObj;
    [SerializeField] private GameObject leftArmHologramObj;
    [SerializeField] private GameObject rightArmHologramObj;
    [SerializeField] private GameObject torsoHologramObj;
    [SerializeField] private GameObject headHologramObj;
    
    [SerializeField] private TMP_Text injuryLeftLegText;
    [SerializeField] private TMP_Text injuryRightLegText;
    [SerializeField] private TMP_Text injuryLeftArmText;
    [SerializeField] private TMP_Text injuryRightArmText;
    [SerializeField] private TMP_Text injuryTorsoText;
    [SerializeField] private TMP_Text injuryHeadText;

    [SerializeField] private TMP_Text vitalsText;

    [SerializeField] public float leftLegHealth = 100;
    private float leftLegMaxHealth = 100;
    [SerializeField] public float rightLegHealth = 100;
    private float rightLegMaxHealth = 100;
    [SerializeField] public float leftArmHealth = 100;
    private float leftArmMaxHealth = 100;
    [SerializeField] public float rightArmHealth = 100;
    private float rightArmMaxHealth = 100;
    [SerializeField] public float torsoHealth = 100;
    private float torsoMaxHealth = 100;
    [SerializeField] public float headHealth = 100;
    private float headMaxHealth = 100;

    // Injury function texts
    string legInjuryFunction = "Speed will be slower";
    string bothLegsInjuryFunction = "Can't run, dash or jump";
    string leftArmInjuryFunction = "Can't use flashlight";
    string rightArmInjuryFunction = "Shooting will be slower";
    string torsoInjuryFunction = "Stamina will be lower";
    string headInjuryFunction = "Accuracy will be lower";

    // Injury texts
    string leftLegInjuries = "Left leg injury";
    string leftArmInjuries = "Left arm injury";
    string rightLegInjuries = "Right leg injury";
    string rightArmInjuries = "Right arm injury";
    string torsoInjuries = "Torso injury";
    string headInjuries = "Head injury";

    // Vitals texts
    string vitalsGood = "OK!";
    string vitalsBad = "CRITICAL CONDITION";

    private void Start()
    {
        //HealthFunctionUI.SetActive(false);
    }

    private void Awake()
    {
        injurySystem.GetComponent<InjurySystem>();
    }

    private void Update()
    {
        InjuryIndicator();
    }

    public void ActivateHealthScreen()
    {
        //HealthFunctionUI.SetActive(true);
        StartCoroutine(ActivateRoutine());
    }

    private void DeactivateHealthScreen()
    {
        //HealthFunctionUI.SetActive(false);
    }

    private IEnumerator ActivateRoutine()
    {
        Vitals();
        InjuryIndicator();
        InjuryStatusText();
        yield return new WaitForSecondsRealtime(0.5f);
        FunctionStatusText();
    }

    private void Vitals()
    {
        bool noInjuries = !injurySystem.leftArmInjured && !injurySystem.rightArmInjured && !injurySystem.leftLegInjured && !injurySystem.rightLegInjured 
            && !injurySystem.torsoInjured && !injurySystem.headInjured;

        if (noInjuries)
        {
            vitalsText.color = new Color(0.3453627f, 1, 0, 1);
            TypeWriteTextRealtime(vitalsText, vitalsGood);
        }
        else
        {
            vitalsText.color = new Color(1, 0.1503219f, 0, 1);
            TypeWriteTextRealtime(vitalsText, vitalsBad);
        }
    }

    private void InjuryIndicator()
    {
        HologramInjuryIndicator(injurySystem.leftArmHealth, leftArmMaxHealth, leftArmHologramObj, ref injurySystem.leftArmInjured);
        HologramInjuryIndicator(injurySystem.rightArmHealth, rightArmMaxHealth, rightArmHologramObj, ref injurySystem.rightArmInjured);
        HologramInjuryIndicator(injurySystem.leftLegHealth, leftLegMaxHealth, leftLegHologramObj, ref injurySystem.leftLegInjured);
        HologramInjuryIndicator(injurySystem.rightLegHealth, rightLegMaxHealth, rightLegHologramObj, ref injurySystem.rightLegInjured);
        HologramInjuryIndicator(injurySystem.torsoHealth, torsoMaxHealth, torsoHologramObj, ref injurySystem.torsoInjured);
        HologramInjuryIndicator(injurySystem.headHealth, headMaxHealth, headHologramObj, ref injurySystem.headInjured);
    }

    private void InjuryStatusText()
    {
        if (injurySystem.leftLegInjured)
        {
            TypeWriteTextRealtime(injuryLeftLegText, leftLegInjuries);
        }
        if (injurySystem.rightLegInjured)
        {
            TypeWriteTextRealtime(injuryRightLegText, rightLegInjuries);
        }
        if (injurySystem.leftArmInjured)
        {
            TypeWriteTextRealtime(injuryLeftArmText, leftArmInjuries);
        }
        if (injurySystem.rightArmInjured)
        {
            TypeWriteTextRealtime(injuryRightArmText, rightArmInjuries);
        }
        if (injurySystem.torsoInjured)
        {
            TypeWriteTextRealtime(injuryTorsoText, torsoInjuries);
        }
        if (injurySystem.headInjured)
        {
            TypeWriteTextRealtime(injuryHeadText, headInjuries);
        }
    }

    private void FunctionStatusText()
    {
        if (injurySystem.leftLegInjured)
        {
            TypeWriteTextRealtime(functionLeftLegText, legInjuryFunction);
        }
        if (injurySystem.rightLegInjured)
        {
            TypeWriteTextRealtime(functionRightLegText, legInjuryFunction);
        }
        if (injurySystem.leftLegInjured && injurySystem.rightLegInjured)
        {
            TypeWriteTextRealtime(functionBothLegsText, bothLegsInjuryFunction);
        }
        if (injurySystem.leftArmInjured)
        {
            TypeWriteTextRealtime(functionLeftArmText, leftArmInjuryFunction);
        }
        if (injurySystem.rightArmInjured)
        {
            TypeWriteTextRealtime(functionRightArmText, rightArmInjuryFunction);
        }
        if (injurySystem.torsoInjured)
        {
            TypeWriteTextRealtime(functionTorsoText, torsoInjuryFunction);
        }
        if (injurySystem.headInjured)
        {
            TypeWriteTextRealtime(functionHeadText, headInjuryFunction);
        }
    }
}
