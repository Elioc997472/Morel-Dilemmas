using UnityEngine;
using System.Collections.Generic;

public class MushroomSpawningManager : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;
    [SerializeField] private List<MushroomItem> collectibleMushrooms;
    [SerializeField] private List<ForagingProp> foragingProps;
    [SerializeField] private List<ForagingProp> ground;

    private void Start()
    {
        LoadMushrooms();
    }

    // currently just flat memorized 
    private void LoadMushrooms()
    {
        int numMushrooms = 10;
        for (int i = 0; i < numMushrooms; i++)
        {
            int index = (int) (Random.value * collectibleMushrooms.Count);
            MushroomItem mushroomData = collectibleMushrooms[index];
            Debug.Log(mushroomData.name);
            Mushroom mushroom;

            if (mushroomData.lookalikeName != "")
            {
                if (Random.value >= 0.4)   // hardcoded atm, can be adjusted idk help T_T
                {
                    //regualr
                    mushroom = new Mushroom(mushroomData, false);
                }
                else
                {
                    //lookalike
                    mushroom = new Mushroom(mushroomData, true);
                }
            }
            else
            {
                mushroom = new Mushroom(mushroomData, false);
            }

            //needs to differentiate from tree guys and non tree guys
            Transform posTransform = GetSpawnSpot(mushroomData.isGrounded);
            if (posTransform != null)
            {
                GameObject mushroomObj = Instantiate(pickupPrefab, posTransform.position, Quaternion.identity);
                mushroomObj.GetComponent<MushroomPickup>().SetPickupItem(mushroom);
            }
        }
    }

    private Transform GetSpawnSpot(bool isGrounded)
    {
        List<ForagingProp> props;
        if (isGrounded)
        {
            props = ground;
        }
        else
        {
            props = foragingProps;

        }
        // loop through props and determine a spot
        int propIndex = Random.Range(0, props.Count);
        Transform spot = props[propIndex].GetOpenSpot();
        return spot;
        // foreach (ForagingProp foragingProp in props)
        // {
        //     Transform spot = foragingProp.GetOpenSpot();
        //     if (spot != null)
        //     {
        //         return spot;
        //     }
        // }

        // return null;
        
    }
}
