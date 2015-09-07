using UnityEngine;
using System.Collections;

public class Fridge : MonoBehaviour
{

    private int level;
    private Transform parent;

    public Inventory inventory = null;

    // Use this for initialization
    void Start()
    {
        level = 1;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");


        parent = GameObject.FindGameObjectWithTag("HUB").transform;

        inventory = Instantiate(inventory) as Inventory;

        //new Vector3(-40,-170)
        inventory.transform.SetParent(parent);
        RectTransform rect = inventory.GetComponent<RectTransform>();
        inventory.StartInventory("Barinventory");

        rect.localPosition = new Vector3(-270, 0);

    }
}
