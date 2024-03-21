using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKey : MonoBehaviour, IFInteractable
{
    
    [SerializeField] private string _prompt;

    public AudioSource src;
    

    public string InteractionPrompt => _prompt;

   

    public bool Interact(InteractableObject interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        
        if (!inventory.HasMug && !inventory.HasKey && !inventory.HasBrew && !inventory.HasPlate && !inventory.HasGreenBottle && !inventory.HasBrownBottle && !inventory.HasMeat && !inventory.HasGold) {
            Debug.Log("Grabbing a Key!");
            inventory.HasKey = true;
            src.Play();
            
            return true;
        }
            
            Debug.Log("Your Hands are Full!");
            return false;
        }


    }
