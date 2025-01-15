

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;

public class VirtualMouseScript : MonoBehaviour
{
   
   private VirtualMouseInput virtualMouseInput;
   // [SerializeField] private PlayerActions playActions;
   // private Mouse virtualMouse;

   private void Awake()
   {

    virtualMouseInput = GetComponent<VirtualMouseInput>();

   }
   private  void LateUpdate()
   {
     Vector2 vMousePosition = virtualMouseInput.virtualMouse.position.value;
     vMousePosition.x = Mathf.Clamp(vMousePosition.x, 0f, Screen.width);
     vMousePosition.y = Mathf.Clamp(vMousePosition.y, 0f, Screen.height);
     InputState.Change(virtualMouseInput.virtualMouse.position, vMousePosition);
   }
}
