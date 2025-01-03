
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class VirtualMouseScript : MonoBehaviour
{
   
    [SerializeField] private PlayerActions playActions;
    private Mouse virtualMouse;

    void OnEnable()
    {
        if(virtualMouse == null)
        {
            virtualMouse = (Mouse) InputSystem.AddDevice("VirtualMouse");
        }
    }
    void OnDisable()
    {
        
    }
}
