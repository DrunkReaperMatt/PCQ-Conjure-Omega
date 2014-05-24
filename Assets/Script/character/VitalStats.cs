using UnityEngine;
using System.Collections;
using System;

public class VitalStats : MonoBehaviour {

    public int rageMax = 100;
    public int rageModeTreshold = 50;
    public int vitalityMax = 100;

    public int armorMax = 5;
    public int armorAtStart = 0;

    private int armor;
    private int vitality;
    private int rage;

	// Use this for initialization
	void Start () {
        ResetStats();
	}

    public void ResetStats()
    {
        rage = 0;
        vitality = vitalityMax;
        armor = armorAtStart;
    }

    #region VITALITY

    public int Vitality
    {
        get { return vitality; }
    }

    public bool ReceiveDamage(int damage)
    {
        if (damage < 1) damage = 1; // Do not call ReceiveDamage if you dont actually want some blood to be shed
        return ((vitality -= ((damage - armor > 1) ? damage - armor : 1 )) > 0 ? true : false );
    }

    public void GainHealt(int healt)
    {
        if (vitality < 1) vitality = 1;
        vitality = (vitality + healt < vitalityMax ? vitality + healt : vitalityMax);
    }

    public bool HasHealt()
    {
        return (vitality > 1);
    }

    #endregion

    #region RAGE

    public int Rage
    {
        get { return rage; }
    }

    public bool SpendRage(int spentRage)
    {
        if (spentRage < 1) spentRage = 1; // Do not call SpendRage if you dont actually want to
        return ((rage -= spentRage) > 0 ? true : false);
    }

    public void GainRage(int gainedRage)
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

    public void breakArmor(int reducedArmor)
    {
        if (reducedArmor < 1) reducedArmor = 1;
        armor = (armor - reducedArmor > 0 ? armor - reducedArmor : 0);
    }

    #endregion
}
