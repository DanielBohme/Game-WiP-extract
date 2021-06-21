using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    public class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
        public int maxAmmoAmount = 300;
        public int magCapacity = 6;
        public int magAmmoAmount = 6;
        public float reloadTime = 1f;
    }

    public int GetCurrentMagAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).magAmmoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount - GetAmmoSlot(ammoType).magCapacity;
    }

    public void ReduceCurrentMagAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).magAmmoAmount--;
    }

    public void RefillMagAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).magAmmoAmount = GetAmmoSlot(ammoType).magCapacity;
        ReduceCurrentAmmo(ammoType);
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }

    public AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
