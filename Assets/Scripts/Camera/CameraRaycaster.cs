using UnityEngine;

namespace Dev.NucleaTNT.VoxRPG.Utilities
{
	public class CameraRaycaster : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetMouseButtonDown(0)) CheckForGroundTile();
		}

		private void CheckForGroundTile() 
		{
			Ray ray = GameManager.Instance.MainCamera.ScreenPointToRay(Input.mousePosition);

			// Layer mask of 1 << 8 for Ground Layer
			if (Physics.Raycast(ray, out RaycastHit hit, 100, 1 << 8)) 
			{
				GameObject objectHit = hit.transform.gameObject;
				Debug.Log($"Hit cube at ({objectHit.transform.position.x}, {objectHit.transform.position.y}, {objectHit.transform.position.z})!");
			} else Debug.Log("Nothing hit.");
		}
	}
}
