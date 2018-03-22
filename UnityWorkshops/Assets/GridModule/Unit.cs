using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour 
{
    public Player OwnedBy;
    public Unit(Player owner)
    {
        this.OwnedBy = owner;
    }
}
