using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBarrel : MonoBehaviour, IFInteractable
{

    public AudioSource src;
   
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

  
    public bool Interact(InteractableObject interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasMug) {
            Debug.Log("Filling with Brew!");
            inventory.HasMug = false;
            inventory.HasBrew = true;
            src.Play();
            return true;
        }

        Debug.Log("No Mug, No Brew!");
        return false;

        
    }
}
