using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class InputManager : MonoBehaviour
{
	[Header("Character Input Values")]
	public Vector2 MoveVector;
	public Vector2 LookVector;
	public bool Jump;
	public bool Sprint;
	public bool Action1;
	public bool Action2;
	public bool Action3;

	[Header("Movement Settings")]
	public bool UseAnalogMovement;

	[Header("Mouse Cursor Settings")]
	public bool CursorLocked = true;
	public bool CursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
	public void OnMove(InputValue value)
	{
		MoveInput(value.Get<Vector2>());
	}
	public void OnLook(InputValue value)
	{
		if (CursorInputForLook)
		{
			LookInput(value.Get<Vector2>());
		}
	}
	public void OnJump(InputValue value)
	{
		JumpInput(value.isPressed);
	}
	public void OnSprint(InputValue value)
	{
		SprintInput(value.isPressed);
	}
	public void OnAction1(InputValue value)
	{
		Action1Input(value.isPressed);
	}
	public void OnAction2(InputValue value)
	{
		Action2Input(value.isPressed);
	}
	public void OnAction3(InputValue value)
	{
		Action3Input(value.isPressed);
	}
#endif


	public void MoveInput(Vector2 newMoveDirection)
	{
		MoveVector = newMoveDirection;
	}
	public void LookInput(Vector2 newLookDirection)
	{
		LookVector = newLookDirection;
	}
	public void JumpInput(bool newState)
	{
		Jump = newState;
	}
	public void SprintInput(bool newState)
	{
		Sprint = newState;
	}
	public void Action1Input(bool newState)
	{
		Action1 = newState;
	}
	public void Action2Input(bool newState)
	{
		Action2 = newState;
	}
	public void Action3Input(bool newState)
	{
		Action2 = newState;
	}
	private void OnApplicationFocus(bool hasFocus)
	{
		SetCursorState(CursorLocked);
	}
	private void SetCursorState(bool newState)
	{
		Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
	}
}