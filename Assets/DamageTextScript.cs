using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Xml;

public class DamageTextScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dText;
   [SerializeField] float lifetime = 1f;
    [SerializeField]float vibrationTime;

    [SerializeField] float moveSpeed = 1f;
   

    // Start is called before the first frame update
    void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, lifetime);
        transform.position += new Vector3(0f, moveSpeed * Time.deltaTime, 0f);
    }

    public void SetDamage(int amount)
    {
       dText.text = amount.ToString();
        float jitter = Random.Range(-vibrationTime, vibrationTime);
   
        
        transform.position += new Vector3(jitter, jitter, 0f);
    }
}
