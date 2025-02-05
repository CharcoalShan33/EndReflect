using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationText : MonoBehaviour
{
    [SerializeField] float activeTime;
    [SerializeField] TextMeshProUGUI textNotice;
    // Start is called before the first frame update
    
    public string SetText(string text)
    {
        text = textNotice.text;
        return text;
    }
    public void ActivateNotification()
    {
        gameObject.SetActive(true);
        StartCoroutine(NoNotifications());
    }
    IEnumerator NoNotifications()
    {
        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
    }
}
