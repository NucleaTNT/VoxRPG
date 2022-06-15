using UnityEngine;

namespace Dev.NucleaTNT.VoxRPG.CameraUtils
{
	public static class CameraRaycaster
	{
		public static bool CheckForTile(out GameObject hitTile) 
		{
			Ray ray = GameManager.Instance.GameCamera.ScreenPointToRay(Input.mousePosition);

			// Layer mask of 1 << 8 for Ground Layer
			if (Physics.Raycast(ray, out RaycastHit hit, 100, 1 << 8))
			{
				hitTile = hit.transform.gameObject;
				Debug.Log($"Hit cube at ({hitTile.transform.position.x}, {hitTile.transform.position.y}, {hitTile.transform.position.z})!"); 
				return true;
			}

			Debug.Log("Nothing hit.");
			hitTile = null;
			return false;
		}
	}
}
