using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{

    public static event System.Action<Vector2> OnplayerMovement;

    public static event System.Action<bool> OnJump;

    public static event System.Action OnPause;

    public static event System.Action onWalk;
    [SerializeField] private PlayerInput playerInput;
   
   private void OnEnable()
   {

    playerInput.onActionTriggered += HandleInput;

   }

   private void OnDisable()
   {
    playerInput.onActionTriggered -= HandleInput;
   }

   private void HandleInput(InputAction.CallbackContext context)
   {

    string action = context.action.name;

    switch (action)
    {
        case "Move":

        Vector2 input = context.ReadValue<Vector2>();
        OnplayerMovement?.Invoke(input);
        break;

        case "Jump":
        if (context.started) OnJump?.Invoke(true);
		else if (context.canceled) OnJump?.Invoke(false);
		break;

        case "Pause" : 
        if (context.started) OnPause?.Invoke(); 
        break;

        case "Walk" :
        if (context.started) onWalk?.Invoke(); 
        break;



        


    }



   }
}
