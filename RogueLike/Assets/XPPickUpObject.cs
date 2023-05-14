using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPPickUpObject : MonoBehaviour, iPickUpObject
{
    [SerializeField] int xpAmount;
    public void OnPickUp(Character character)
    {
        character.AddExperience(xpAmount);
    }
}
