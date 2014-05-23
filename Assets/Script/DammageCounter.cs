using UnityEngine;
using System.Collections;

public class DamageCounter{

    private GameObject dealer;
    private int damage;

	// Use this for initialization
    public DamageCounter(GameObject dealer, int damage)
    {
        this.dealer = dealer;
        this.damage = damage;
		Debug.Log ("dc created + " + damage);
    }

    public GameObject Dealer
    {
        get { return dealer; }
    }

    public int Damage
    {
        get { return damage; }
    }

}
