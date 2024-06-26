using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBottle : MonoBehaviour, IFInteractable
{
    
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

     public AudioSource src;


    public bool Interact(InteractableObject interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        
        if (!inventory.HasMug && !inventory.HasKey && !inventory.HasBrew && !inventory.HasPlate && !inventory.HasGreenBottle && !inventory.HasBrownBottle && !inventory.HasMeat && !inventory.HasGold) {
            Debug.Log("Grabbing a Green Bottle!");
            inventory.HasGreenBottle = true;
            src.Play();
            return true;
        }
            
            Debug.Log("Your Hands are Full!");
            return false;
        }


    }
