using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Fridge : MonoBehaviour
{

    private int level;
    private Transform parent;
    private Text itemText;
    private Image itemImage;
    private bool inFrontOf;

    private Inventory acutalInventory = null;
    public Inventory inventory = null;

    // Use this for initialization
    void Start()
    {
        level = 1;
        itemText = GameObject.FindGameObjectWithTag("Itemtext").GetComponent<Text>();
        itemImage = itemText.GetComponentInParent<Image>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        itemImage.enabled = true;
        itemText.enabled = true;
        itemText.text = "F: Kühlschrank öffnen";
        inFrontOf = true;


    }

    void OnTriggerExit2D(Collider2D other)
    {
        itemText.enabled = false;
        itemImage.enabled = false;
        inFrontOf = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inFrontOf)
        {
            showInventory();


        }
    }

    private void showInventory()
    {
        if (acutalInventory == null)
        {
            parent = GameObject.FindGameObjectWithTag("HUB").transform;

            acutalInventory = Instantiate(inventory) as Inventory;

            //new Vector3(-40,-170)
            acutalInventory.transform.SetParent(parent);
            RectTransform rect = acutalInventory.GetComponent<RectTransform>();
            acutalInventory.StartInventory("Barinventory");

            rect.localPosition = new Vector3(-270, 0);
        }
    }
}
