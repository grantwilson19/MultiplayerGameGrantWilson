using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IFInteractable
{

   
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public AudioSource src;



    public bool Interact(InteractableObject interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasKey) {
            Debug.Log("Grabbing Gold From Chest!");
            inventory.HasKey = false;
            inventory.HasGold = true;
            src.Play();
            return true;
        }

        Debug.Log("You need a Key to Open to Chest!");
        return false;

        
    }
}
