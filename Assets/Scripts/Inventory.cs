using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Inventory : NetworkBehaviour
{
    public GameObject mugUI;
    public GameObject brewUI;
    public GameObject greenUI;
    public GameObject brownUI;
    public GameObject goldUI;
    public GameObject keyUI;
    public GameObject plateUI;
    public GameObject meatUI;

    public GameObject dinnerUI;
    
    
    public GameObject Mug;
    public GameObject Brew;
    public GameObject Key;
    public GameObject Plate;
    public GameObject GreenBottle;
    public GameObject BrownBottle;
    public GameObject Meat;
    public GameObject Gold;

    public GameObject Dinner;


    public bool HasMug = false;
    public bool HasBrew = false;
    public bool HasKey = false;
    public bool HasPlate = false;
    public bool HasGreenBottle = false;
    public bool HasBrownBottle = false;
    public bool HasMeat = false;
    public bool HasGold = false;

    public bool HasDinner = false;

    


    private void Update() {
        if (Input.GetButton("Fire3")) {
            HasMug = false;
            HasBrew = false;
            HasKey = false;
            HasPlate = false;
            HasGreenBottle = false;
            HasBrownBottle = false;
            HasMeat = false;
            HasGold = false;
            HasDinner = false;
        }


        // Models

        if (HasMeat == true) Meat.SetActive(true);
        if (HasMeat == false) Meat.SetActive(false);

        if (HasMug == true) Mug.SetActive(true);
        if (HasMug == false) Mug.SetActive(false);

        if (HasBrew == true) Brew.SetActive(true);
        if (HasBrew == false) Brew.SetActive(false);

        if (HasKey == true) Key.SetActive(true);
        if (HasKey == false) Key.SetActive(false);

        if (HasPlate == true) Plate.SetActive(true);
        if (HasPlate == false) Plate.SetActive(false);

        if (HasGreenBottle == true) GreenBottle.SetActive(true);
        if (HasGreenBottle == false) GreenBottle.SetActive(false);

        if (HasBrownBottle == true) BrownBottle.SetActive(true);
        if (HasBrownBottle == false) BrownBottle.SetActive(false);

        if (HasGold == true) Gold.SetActive(true);
        if (HasGold == false) Gold.SetActive(false);

        if (HasDinner == true) Dinner.SetActive(true);
        if (HasDinner == false) Dinner.SetActive(false);


        // UI

        if (HasMeat == true) meatUI.SetActive(true);
        if (HasMeat == false) meatUI.SetActive(false);

        if (HasMug == true) mugUI.SetActive(true);
        if (HasMug == false) mugUI.SetActive(false);

        if (HasBrew == true) brewUI.SetActive(true);
        if (HasBrew == false) brewUI.SetActive(false);

        if (HasKey == true) keyUI.SetActive(true);
        if (HasKey == false) keyUI.SetActive(false);

        if (HasPlate == true) plateUI.SetActive(true);
        if (HasPlate == false) plateUI.SetActive(false);

        if (HasGreenBottle == true) greenUI.SetActive(true);
        if (HasGreenBottle == false) greenUI.SetActive(false);

        if (HasBrownBottle == true) brownUI.SetActive(true);
        if (HasBrownBottle == false) brownUI.SetActive(false);

        if (HasGold == true) goldUI.SetActive(true);
        if (HasGold == false) goldUI.SetActive(false);

        if (HasDinner == true) dinnerUI.SetActive(true);
        if (HasDinner == false) dinnerUI.SetActive(false);



    }
}
