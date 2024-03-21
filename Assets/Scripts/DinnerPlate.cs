using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinnerPlate : MonoBehaviour, IFInteractable
{

   
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public bool plateReady = false;
    public AudioSource src1;
    public AudioSource src2;

    public GameObject Plate;

    void Start() {
        Plate.SetActive(false);
    }
  
    public bool Interact(InteractableObject interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.HasPlate) {
            Debug.Log("Placing Plate!");
            inventory.HasPlate = false;
            Plate.SetActive(true);
            plateReady = true;
            src1.Play();
            return true;
        }

        if (inventory.HasMeat && plateReady) {
            Debug.Log("Grabbing Dinner!");
            inventory.HasMeat = false;
            Plate.SetActive(false);
            inventory.HasDinner = true;
            plateReady = false;
            src2.Play();
            return true;
        }

        Debug.Log("Plate First then Meat!");
        return false;

        
    }
}
