using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedItemsManager : MonoBehaviour
{
    [SerializeField] List<EquipedItem> equipedItems;
    [SerializeField] List<EquipedItem> equipedWeapons;

    public void Start()
    {
        //disable the visibility of the fields
        for (int i = 0; i < equipedItems.Count; i++)
        {
            equipedItems[i].gameObject.SetActive(false);
        }


        for (int i = 0; i < equipedWeapons.Count; i++)
        {
            equipedWeapons[i].gameObject.SetActive(false);
        }
    }

    public List<EquipedItem> ReturnItemsIcons()
    {
        return equipedItems;
    }

    public List<EquipedItem> ReturnWeaponsIcons()
    {
        return equipedWeapons;
    }
}
