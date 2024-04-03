namespace Game.Ecs.UI.HealthBar.Models
{
	using System;
	using UniGame.UiSystem.Runtime;
	using UniModules.UniGame.Core.Runtime.Rx;
	using UnityEngine;

	[Serializable]
	public class HealthBarViewModel : ViewModelBase
	{
		public ReactiveValue<float> health = new ReactiveValue<float>();
		public ReactiveValue<float> maxHealth = new ReactiveValue<float>();
		public ReactiveValue<float> shield = new ReactiveValue<float>();
		public ReactiveValue<bool> isShow = new ReactiveValue<bool>(false);
		public ReactiveValue<Vector3> position = new ReactiveValue<Vector3>();
		public ReactiveValue<Color> color = new ReactiveValue<Color>();
	}
}