using UnityEngine;
using System.Collections;
using TMPro;

public class InjurySystem : InjuryMethods
{
    [SerializeField] private bool injuryBlink;
    [SerializeField] public bool leftLegInjured;
    [SerializeField] public bool rightLegInjured;
    [SerializeField] public bool bothLegsInjured;
    [SerializeField] public bool leftArmInjured;
    [SerializeField] public bool rightArmInjured;
    [SerializeField] public bool torsoInjured;
    [SerializeField] public bool headInjured;

    [SerializeField] private bool leftLegInjuredTWBool;
    [SerializeField] private bool rightLegInjuredTWBool;
    [SerializeField] private bool leftArmInjuredTWBool;
    [SerializeField] private bool rightArmInjuredTWBool;
    [SerializeField] private bool torsoInjuredTWBool;
    [SerializeField] private bool headInjuredTWBool;

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

    [SerializeField] private bool _80100InjuriesBool = false;
    [SerializeField] private bool _6080InjuriesBool = false;
    [SerializeField] private bool _4060InjuriesBool = false;
    [SerializeField] private bool _2040InjuriesBool = false;
    [SerializeField] private bool _120InjuriesBool = false;

    // Collision body parts
    [SerializeField] private Transform leftLegObj;
    [SerializeField] private Transform rightLegObj;
    [SerializeField] private Transform leftArmObj;
    [SerializeField] private Transform rightArmObj;
    [SerializeField] private Transform torsoObj;
    [SerializeField] private Transform headObj;

    // Hologram body parts
    [SerializeField] private GameObject leftLegHologramObj;
    [SerializeField] private GameObject rightLegHologramObj;
    [SerializeField] private GameObject leftArmHologramObj;
    [SerializeField] private GameObject rightArmHologramObj;
    [SerializeField] private GameObject torsoHologramObj;
    [SerializeField] private GameObject headHologramObj;

    // Text objects
    [SerializeField] private TMP_Text injuryText;

    [SerializeField] private TMP_Text _80100InjuryText;
    [SerializeField] private TMP_Text _6080InjuryText;
    [SerializeField] private TMP_Text _4060InjuryText;
    [SerializeField] private TMP_Text _2040InjuryText;
    [SerializeField] private TMP_Text _120InjuryText;

    [SerializeField] private TMP_Text injuryBlinkText;
    [SerializeField] private TMP_Text injuryLeftLegText;
    [SerializeField] private TMP_Text injuryRightLegText;
    //[SerializeField] private TMP_Text injuryBothLegsText;
    [SerializeField] private TMP_Text injuryLeftArmText;
    [SerializeField] private TMP_Text injuryRightArmText;
    [SerializeField] private TMP_Text injuryTorsoText;
    [SerializeField] private TMP_Text injuryHeadText;

    [SerializeField] private GameObject HealthFunctionUI;
    //[SerializeField] private TMP_Text functionText;
    [SerializeField] private TMP_Text functionLeftLegText;
    [SerializeField] private TMP_Text functionRightLegText;
    [SerializeField] private TMP_Text functionBothLegsText;
    [SerializeField] private TMP_Text functionLeftArmText;
    [SerializeField] private TMP_Text functionRightArmText;
    [SerializeField] private TMP_Text functionTorsoText;
    [SerializeField] private TMP_Text functionHeadText;

    // Scripts
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Weapon weapon;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private Dash dash;
    [SerializeField] private JumpController jumpController;

    // Injury texts
    string injuryBlinkString = "INJURY";
    string leftLegInjuries = "Left leg injured";
    string leftArmInjuries = "Left arm injured";
    string rightLegInjuries = "Right leg injured";
    string rightArmInjuries = "Right arm injured";
    string torsoInjuries = "Torso injured";
    string headInjuries = "Head injured";

    // Injury function texts
    string legInjuryFunction = "Speed will be slower";
    string bothLegsInjuryFunction = "Can't run, dash or jump";
    string leftArmInjuryFunction = "Can't use flashlight";
    string rightArmInjuryFunction = "Shooting will be slower";
    string torsoInjuryFunction = "Stamina will be lower";
    string headInjuryFunction = "Accuracy will be lower";

    // No injuries status text
    string _80100Injuries = "No physical \ninjuries detected";
    string _6080Injuries = "Some physical \ninjuries";
    string _4060Injuries = "Bad physical \ninjuries";
    string _2040Injuries = "Physical injuries \nnear critical";
    string _120Injuries = "Physical injuries \ncritical!";

    private void Update()
    {
        LeftArmInjured();
        RightArmInjured();
        LeftLegInjured();
        RightLegInjured();
        BothLegsInjured();
        TorsoInjured();
        HeadInjured();

        UpdateStatusText();
    }

    private void UpdateStatusText()
    {
        bool noInjuries = !leftArmInjured && !rightArmInjured && !leftLegInjured && !rightLegInjured && !torsoInjured && !headInjured;

        if (noInjuries)
        {
            NoInjuryStatusText();
            InjuryBlink();
        }
        else
        {
            InjuryStatusText();
            InjuryBlink();
        }
    }

    private void InjuryBlink()
    {
        bool noInjuries = !leftArmInjured && !rightArmInjured && !leftLegInjured && !rightLegInjured && !torsoInjured && !headInjured;

        if (!noInjuries && !injuryBlink)
        {
            TypeWriteText(injuryBlinkText, injuryBlinkString);
            StartCoroutine(BlinkRoutine());
        }
    }

    private IEnumerator BlinkRoutine()
    {
        bool noInjuries = !leftArmInjured && !rightArmInjured && !leftLegInjured && !rightLegInjured && !torsoInjured && !headInjured;
        injuryBlink = true;
        while (!noInjuries)
        {
            injuryBlinkText.color = new Color(0.7169812f, 0.7169812f, 0.7169812f, 1);
            yield return new WaitForSeconds(0.5f);
            injuryBlinkText.color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void InjuryStatusText()
    {
        _80100InjuriesBool = false;
        _6080InjuriesBool = false;
        _4060InjuriesBool = false;
        _2040InjuriesBool = false;
        _120InjuriesBool = false;

        _80100InjuryText.gameObject.SetActive(false);
        _6080InjuryText.gameObject.SetActive(false);
        _4060InjuryText.gameObject.SetActive(false);
        _2040InjuryText.gameObject.SetActive(false);
        _120InjuryText.gameObject.SetActive(false);

        if (leftLegInjured && !leftLegInjuredTWBool)
        {
            leftLegInjuredTWBool = true;
            TypeWriteText(injuryLeftLegText, leftLegInjuries);
        }
        if (rightLegInjured && !rightLegInjuredTWBool)
        {
            rightLegInjuredTWBool = true;
            TypeWriteText(injuryRightLegText, rightLegInjuries);
        }
        if (leftArmInjured && !leftArmInjuredTWBool)
        {
            leftArmInjuredTWBool = true;
            TypeWriteText(injuryLeftArmText, leftArmInjuries);
        }
        if (rightArmInjured && !rightArmInjuredTWBool)
        {
            rightArmInjuredTWBool = true;
            TypeWriteText(injuryRightArmText, rightArmInjuries);
        }
        if (torsoInjured && !torsoInjuredTWBool)
        {
            torsoInjuredTWBool = true;
            TypeWriteText(injuryTorsoText, torsoInjuries);
        }
        if (headInjured && !headInjuredTWBool)
        {
            headInjuredTWBool = true;
            TypeWriteText(injuryHeadText, headInjuries);
        }
    }

    private void NoInjuryStatusText()
    {
        var injuryTextTW = injuryText.GetComponent<UITextTypeWriter>();
        
        if ((playerHealth.hitPoints >= 80 & playerHealth.hitPoints <= 100) && !_80100InjuriesBool)
        {
            _80100InjuriesBool = true;
            _6080InjuriesBool = false;
            _4060InjuriesBool = false;
            _2040InjuriesBool = false;
            _120InjuriesBool = false;

            _80100InjuryText.gameObject.SetActive(true);
            _6080InjuryText.gameObject.SetActive(false);
            _4060InjuryText.gameObject.SetActive(false);
            _2040InjuryText.gameObject.SetActive(false);
            _120InjuryText.gameObject.SetActive(false);

            TypeWriteText(_80100InjuryText, _80100Injuries);
        }
        if ((playerHealth.hitPoints >= 60 & playerHealth.hitPoints < 80) && !_6080InjuriesBool)
        {
            _80100InjuriesBool = false;
            _6080InjuriesBool = true;
            _4060InjuriesBool = false;
            _2040InjuriesBool = false;
            _120InjuriesBool = false;

            _80100InjuryText.gameObject.SetActive(false);
            _6080InjuryText.gameObject.SetActive(true);
            _4060InjuryText.gameObject.SetActive(false);
            _2040InjuryText.gameObject.SetActive(false);
            _120InjuryText.gameObject.SetActive(false);

            TypeWriteText(_6080InjuryText, _6080Injuries);
        }
        if ((playerHealth.hitPoints >= 40 & playerHealth.hitPoints < 60) && !_4060InjuriesBool)
        {
            _80100InjuriesBool = false;
            _6080InjuriesBool = false;
            _4060InjuriesBool = true;
            _2040InjuriesBool = false;
            _120InjuriesBool = false;

            _80100InjuryText.gameObject.SetActive(false);
            _6080InjuryText.gameObject.SetActive(false);
            _4060InjuryText.gameObject.SetActive(true);
            _2040InjuryText.gameObject.SetActive(false);
            _120InjuryText.gameObject.SetActive(false);

            TypeWriteText(_4060InjuryText, _4060Injuries);
        }
        if ((playerHealth.hitPoints >= 20 & playerHealth.hitPoints < 40) && !_2040InjuriesBool)
        {
            _80100InjuriesBool = false;
            _6080InjuriesBool = false;
            _4060InjuriesBool = false;
            _2040InjuriesBool = true;
            _120InjuriesBool = false;

            _80100InjuryText.gameObject.SetActive(false);
            _6080InjuryText.gameObject.SetActive(false);
            _4060InjuryText.gameObject.SetActive(false);
            _2040InjuryText.gameObject.SetActive(true);
            _120InjuryText.gameObject.SetActive(false);

            TypeWriteText(_2040InjuryText, _2040Injuries);
        }
        if ((playerHealth.hitPoints >= 1 & playerHealth.hitPoints < 20) && !_120InjuriesBool)
        {
            _80100InjuriesBool = false;
            _6080InjuriesBool = false;
            _4060InjuriesBool = false;
            _2040InjuriesBool = false;
            _120InjuriesBool = true;

            _80100InjuryText.gameObject.SetActive(false);
            _6080InjuryText.gameObject.SetActive(false);
            _4060InjuryText.gameObject.SetActive(false);
            _2040InjuryText.gameObject.SetActive(false);
            _120InjuryText.gameObject.SetActive(true);

            TypeWriteText(_120InjuryText, _120Injuries);
        }
    }

    private void LeftArmInjured()
    {
        HologramInjuryIndicator(leftArmHealth, leftArmMaxHealth, leftArmHologramObj, ref leftArmInjured);
    }

    private void RightArmInjured()
    {
        HologramInjuryIndicator(rightArmHealth, rightArmMaxHealth, rightArmHologramObj, ref rightArmInjured);

        if (rightArmHealth < 20)
        {
            // shoot slower
            weapon.timeBetweenShots = 1f;
        }
        else
        {
            weapon.timeBetweenShots = 0.5f;
        }
    }

    private void BothLegsInjured()
    {
        if (leftLegInjured && rightLegInjured)
        {
            bothLegsInjured = true;
            // now can't run and can't jump or dash
            playerMovementController.oneHandRunSpeed = playerMovementController.oneHandWalkSpeed;
            playerMovementController.twoHandsRunSpeed = playerMovementController.twoHandsWalkSpeed;
            dash.canDash = false;
            jumpController.canJump = false;
        }
        else
        {
            playerMovementController.oneHandRunSpeed = 10f;
            playerMovementController.twoHandsRunSpeed = 9f;
            dash.canDash = true;
            jumpController.canJump = true;
        }
    }

    private void LeftLegInjured()
    {
        HologramInjuryIndicator(leftLegHealth, leftLegMaxHealth, leftLegHologramObj, ref leftLegInjured);

        if (leftLegHealth < 20)
        {
            // slow down player a bit
            if (bothLegsInjured) return;
            playerMovementController.oneHandWalkSpeed = 4f;
            playerMovementController.twoHandsWalkSpeed = 3f;
            playerMovementController.oneHandRunSpeed = 9f;
            playerMovementController.twoHandsRunSpeed = 8f;
        }
        else
        {
            playerMovementController.oneHandWalkSpeed = 5f;
            playerMovementController.twoHandsWalkSpeed = 4f;
            playerMovementController.oneHandRunSpeed = 10f;
            playerMovementController.twoHandsRunSpeed = 9f;
        }
    }

    private void RightLegInjured()
    {
        HologramInjuryIndicator(rightLegHealth, rightLegMaxHealth, rightLegHologramObj, ref rightLegInjured);

        if (rightLegHealth < 20)
        {
            // slow down player a bit
            if (bothLegsInjured) return;
            playerMovementController.oneHandWalkSpeed = 4f;
            playerMovementController.twoHandsWalkSpeed = 3f;
            playerMovementController.oneHandRunSpeed = 9f;
            playerMovementController.twoHandsRunSpeed = 8f;
        }
        else
        {
            playerMovementController.oneHandWalkSpeed = 5f;
            playerMovementController.twoHandsWalkSpeed = 4f;
            playerMovementController.oneHandRunSpeed = 10f;
            playerMovementController.twoHandsRunSpeed = 9f;
        }
    }

    private void TorsoInjured()
    {
        HologramInjuryIndicator(torsoHealth, torsoMaxHealth, torsoHologramObj, ref torsoInjured);

        if (torsoHealth < 20)
        {
            // shorter stamina?
        }
    }

    private void HeadInjured()
    {
        HologramInjuryIndicator(headHealth, headMaxHealth, headHologramObj, ref headInjured);

        if (headHealth < 20)
        {
            // lower accuracy on handgun
        }
    }
}
