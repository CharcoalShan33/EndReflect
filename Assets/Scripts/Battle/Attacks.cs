using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    [SerializeField] float delay = 1f;


    void Update()
    {

        Destroy(gameObject, delay);

    }


}
