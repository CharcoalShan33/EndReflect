using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] characters;
    [SerializeField] List<GameObject> enemies;
    [SerializeField] Transform[] playerPositions;
    [SerializeField] Transform[] enemyPositions;

    Vector3 offset = new(0f, 1, 0f);
    WaitForSeconds waitFor = new(.5f);
    WaitForSeconds reallyWaitFor = new(1f);

    public bool isSummon;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N) && isSummon == false)
        {
            StartCoroutine(OneAtATime());
            StartCoroutine(OneAtATimeForEnemies());
            isSummon = true;
        }
        if(isSummon)
        {
            StopAllCoroutines();
            //StopCoroutine(OneAtATime());
        }


    }


   public IEnumerator OneAtATime()
    {
        yield return  waitFor;
        for( int i = 0; i< characters.Length;  i++)
        {

            Instantiate(characters[i].gameObject, playerPositions[i].position + offset, quaternion.identity);
            characters[i].gameObject.SetActive(false);
            yield return reallyWaitFor;
            characters[i].gameObject.SetActive(true);
            continue;
            
            
        }
        yield return null;
    }


    public IEnumerator OneAtATimeForEnemies()
    {
        yield return  waitFor;
        for( int i = 0; i< characters.Length;  i++)
        {

            Instantiate(enemies[i].gameObject, enemyPositions[i].position + offset, quaternion.identity);
            enemies[i].gameObject.SetActive(false);
            yield return reallyWaitFor;
            enemies[i].gameObject.SetActive(true);
            continue;
            
            
        }
        yield return null;
    }

    
    
}
