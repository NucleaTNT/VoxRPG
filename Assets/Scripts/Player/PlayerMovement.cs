using Dev.NucleaTNT.VoxRPG.CameraUtils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dev.NucleaTNT.VoxRPG.Player
{
	public class PlayerMovement : PlayerMonoBehaviour
	{
		[SerializeField] private float _movementSpeed;
		[SerializeField] private Vector3 _targetPosition;

		public void HandleMoveAttempt(InputAction.CallbackContext callbackContext)
		{
			if (!callbackContext.performed || !CameraRaycaster.CheckForTile(out GameObject targetTile)) return;
			_targetPosition = targetTile.transform.position + (Vector3.up * 1.5f);
		}
		
		private new void Awake()
		{
			base.Awake();
			_targetPosition = transform.position;
		}

		private void FixedUpdate()
		{
			if (transform.position != _targetPosition)
				ThisPlayerController.PlayerRigidbody.MovePosition(
					Vector3.Lerp(
						transform.position, 
						new Vector3(_targetPosition.x, _targetPosition.y + 1.5f, _targetPosition.z), 
						_movementSpeed * Time.fixedDeltaTime
					));
		}
	}
}
