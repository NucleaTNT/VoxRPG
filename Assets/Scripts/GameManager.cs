using System;
using UnityEngine;

namespace Dev.NucleaTNT.VoxRPG.Utilities
{
	public class GameManager : MonoBehaviour
	{
		private static GameManager s_instance;
		public static GameManager Instance => s_instance;

		[SerializeField] private Camera _mainCamera;
		[SerializeField] private CameraRaycaster _cameraRaycaster;

		public Camera MainCamera => _mainCamera;
		public CameraRaycaster CameraRaycaster => _cameraRaycaster;

		private void Awake()
		{
			SingletonCheck();

			if (!_mainCamera) _mainCamera = Camera.main;
			if (!_cameraRaycaster) 
				if (!_mainCamera.gameObject.TryGetComponent<CameraRaycaster>(out _cameraRaycaster)) 
					_cameraRaycaster = _mainCamera.gameObject.AddComponent<CameraRaycaster>();
		}

        private void SingletonCheck()
        {
			if (!Instance) s_instance = this;
            if (Instance != this) Destroy(this);
        }
    }
}
