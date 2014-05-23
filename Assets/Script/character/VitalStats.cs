using UnityEngine;
using System.Collections;

public class VitalStats : MonoBehaviour {

    public int rageMax = 100;
    public int rageModeTreshold = 50;
    public int vitalityMax = 100;
    public int armorMax = 5;

    private int armor;
    private int vitality;
    private int rage;

	// Use this for initialization
	void Start () {
        ResetStats();
	}

    private void ResetStats()
    {
        rage = 0;
        vitality = vitalityMax;
        armor = 0;
    }

    #region VITALITY

    public int Vitality
    {
        get { return vitality; }
    }

    private bool ReceiveDamage(int damage)
    {
        if (damage < 1) damage = 1; // Do not call ReceiveDamage if you dont actually want some blood to be shed
        return ((vitality -= (damage - armor > 1 ? damage - armor : 1 )) > 0 ? true : false );
    }

    private void GainHealt(int healt)
    {
        if (vitality < 1) vitality = 1;
        vitality = (vilality + healt < vitalityMax ? vilality + healt : vitalityMax);
    }

    private bool hasHealt()
    {
        return (vitality > 1 ? true : false);
    }

    #endregion

    #region RAGE

    private int Rage
    {
        get { return rage; }
    }

    private bool SpendRage(int spentRage)
    {
        if (spentRage < 1) spentRage = 1; // Do not call SpendRage if you dont actually want to
        return ((rage -= spentRage) > 0 ? true : false);
    }

    private void GainRage(int gainedRage)
    {
        if(gainedRage > 0) rage = (rage + gainedRage < rageMax ? rage + gainedRage : rageMax);
    }

    #endregion

    #region ARMOR

    public int Armor
    {
        get { return armor; }
    }

    public void gainArmor(int gainedArmor)
    {
        if (gainedArmor < 1) gainedArmor = 1;
        armor = (armor + gainedArmor < armorMax ? armor + gainedArmor : armorMax);
    }

    public void gainArmor(int gainedArmor)
    {
        if (gainedArmor < 1) gainedArmor = 1;
        armor = (armor + gainedArmor < armorMax ? armor + gainedArmor : armorMax);
    }

    #endregion
}
