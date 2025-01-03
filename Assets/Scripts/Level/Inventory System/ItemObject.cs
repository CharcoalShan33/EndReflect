using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer spr;

    [SerializeField] private ItemData itemData;
    // Start is called before the first frame update
    private void OnValidate()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.icon;
        gameObject.name = itemData.displayName;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<LevelCharacter>() !=null)
        {
            Inventory.instance.AddItem(itemData);
            Destroy(this.gameObject);


        }
    }
}
