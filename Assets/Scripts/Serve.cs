using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serve : MonoBehaviour, IFInteractable
{

    public AudioSource src;
    public GameObject dinnerUI;
    public GameObject greenUI;
    public GameObject brownUI;
    public GameObject goldUI;
    public GameObject brewUI;

    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool shopOpen = false;

    public ScoreKeeper score;

    public int itemNum;
    
    public string sellItem;

    // Reference to the Inventory component of the targetObject


    private void Start(){
        itemNum = Random.Range(1, 6);
    }

    private void Update(){
        if (itemNum == 1) {
            sellItem = "Brew";
            brewUI.SetActive(true);
            greenUI.SetActive(false);
            brownUI.SetActive(false);
            goldUI.SetActive(false);
            dinnerUI.SetActive(false);
        }
        if (itemNum == 2) {
            sellItem = "Green Bottle";
            greenUI.SetActive(true);
            brewUI.SetActive(false);
            brownUI.SetActive(false);
            goldUI.SetActive(false);
            dinnerUI.SetActive(false);
            }
        if (itemNum == 3) {
            sellItem = "Brown Bottle";
            brownUI.SetActive(true);
            greenUI.SetActive(false);
            brewUI.SetActive(false);
            goldUI.SetActive(false);
            dinnerUI.SetActive(false);
        }
        if (itemNum == 4) {
            sellItem = "Gold";
            goldUI.SetActive(true);
            greenUI.SetActive(false);
            brownUI.SetActive(false);
            brewUI.SetActive(false);
            dinnerUI.SetActive(false);
        }
        if (itemNum == 5) {
            sellItem = "Dinner";
            dinnerUI.SetActive(true);
            greenUI.SetActive(false);
            brownUI.SetActive(false);
            goldUI.SetActive(false);
            brewUI.SetActive(false);
        }
    }
    public bool Interact(InteractableObject interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (itemNum == 1 && inventory.HasBrew){
            Debug.Log("Selling Brew!");
            inventory.HasBrew = false;
            itemNum = Random.Range(1, 6);
            score.IncreaseScore();
            src.Play();
            return true;
        }

        if (itemNum == 2 && inventory.HasGreenBottle){
            Debug.Log("Selling Green Bottle!");
            inventory.HasGreenBottle = false;
            itemNum = Random.Range(1, 6);
            score.IncreaseScore();
            src.Play();
            return true;
        }

        if (itemNum == 3 && inventory.HasBrownBottle){
            Debug.Log("Selling Brown Bottle!");
            inventory.HasBrownBottle = false;
            itemNum = Random.Range(1, 6);
            score.IncreaseScore();
            src.Play();
            return true;
        }

        if (itemNum == 4 && inventory.HasGold){
            Debug.Log("Selling Gold!");
            inventory.HasGold = false;
            itemNum = Random.Range(1, 6);
            score.IncreaseScore();
            src.Play();
            return true;
        }

        if (itemNum == 5 && inventory.HasDinner){
            Debug.Log("Selling Dinner!");
            inventory.HasDinner = false;
            itemNum = Random.Range(1, 6);
            score.IncreaseScore();
            src.Play();
            return true;
        }
        return false;
}
}