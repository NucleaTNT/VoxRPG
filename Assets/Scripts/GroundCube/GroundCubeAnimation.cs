using UnityEngine;

namespace Dev.NucleaTNT.VoxRPG.GroundCube
{
	public class GroundCubeAnimation : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private BoxCollider _collider;
		private bool _isHidden = false;

		public bool IsHidden => _isHidden;

		private void Awake()
		{
			if (!_animator) _animator = gameObject.GetComponent<Animator>();
			if (!_collider) _collider = gameObject.GetComponent<BoxCollider>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.H)) 
			{
				if (_isHidden) ShowCube();
				else HideCube();
			}
		}

		public void HideCube() 
		{
			_animator.SetTrigger("HideCube");
			_collider.enabled = false;
			_isHidden = true;
		}

		public void ShowCube()
		{
			_animator.SetTrigger("ShowCube");
			_collider.enabled = true;
			_isHidden = false;
		}
	}
}
