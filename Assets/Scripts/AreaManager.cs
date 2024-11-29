using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AreaManager : MonoBehaviour
{
    [SerializeField] Tilemap maps;

    private Vector3 bottomLimit;
    private Vector3 topLimit;
     private Vector3 offset = new Vector3(.5f, .1f, 0f);
    // Start is called before the first frame update
    void Start()

    {
       
    
        bottomLimit = maps.localBounds.min + offset;
        topLimit = maps.localBounds.max + -offset;
        PlayerController.instance.SetBounds(bottomLimit, topLimit);
       
    }

    
}
