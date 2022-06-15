using Dev.NucleaTNT.VoxRPG.CameraUtils;
using UnityEngine;

namespace Dev.NucleaTNT.VoxRPG
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance { get; private set; }
		public Camera GameCamera { get; private set; }

		private void Awake()
		{
			SingletonCheck();
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			if (GameCamera == null) GameCamera = Camera.main;
		}

		private void SingletonCheck()
        {
			if (Instance == null) Instance = this;
            if (Instance != this) Destroy(this);
        }
	}
}
