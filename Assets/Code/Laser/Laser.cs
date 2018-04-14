﻿using System;
using UnityEngine;
using Zenject;

namespace Code
{
	public class Laser : MonoBehaviour
	{
		private SpriteRenderer _spriteRenderer;
		
		public bool IsFiring { private get; set; }

		private PlayerFacade _player;

		private Settings _settings;

		[Inject]
		public void Construct(
			Settings settings,
			PlayerFacade player)
		{
			_settings = settings;
			_player = player;
		}
		
		private void Start()
		{
			_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
			_spriteRenderer.enabled = false;
		}

		private void Update()
		{
			UpdateLaser();
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (!IsFiring) return;
			
			var damagableGo = other.GetComponent<Damageable>();

			if (damagableGo != null)
			{
				damagableGo.ReceiveDamage(_settings.Damage);
			}
		}

		private void UpdateLaser()
		{
			transform.rotation = _player.IsFacingLeft ? new Quaternion(0, 180f, 0, 0) : new Quaternion(0, 0, 0, 0);
			transform.position = _player.Position;
			_spriteRenderer.enabled = IsFiring;
		}
		
		[Serializable]
		public class Settings
		{
			public int Damage;
		}
	}
}