using System;
using UnityEngine;

namespace Kogane
{
	/// <summary>
	/// ぼよよんと出る動きを管理するクラス
	/// </summary>
	[Serializable]
	public sealed class ElasticMover
	{
		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private float m_amplitude    = default;
		[SerializeField] private float m_deceleration = default;
		[SerializeField] private float m_friction     = default;
		[SerializeField] private float m_targetScale  = 1;
		[SerializeField] private float m_scale        = 1;

		//==============================================================================
		// プロパティ
		//==============================================================================
		/// <summary>
		/// 振幅を取得または設定します
		/// </summary>
		public float Amplitude
		{
			get => m_amplitude;
			set => m_amplitude = value;
		}

		/// <summary>
		/// 減速度を取得または設定します
		/// </summary>
		public float Deceleration
		{
			get => m_deceleration;
			set => m_deceleration = value;
		}

		/// <summary>
		/// 摩擦力を取得または設定します
		/// </summary>
		public float Friction
		{
			get => m_friction;
			set => m_friction = value;
		}

		/// <summary>
		/// 目標値を取得または設定します
		/// </summary>
		public float TargetScale
		{
			get => m_targetScale;
			set => m_targetScale = value;
		}

		/// <summary>
		/// 現在値を取得または設定します
		/// </summary>
		public float Scale
		{
			get => m_scale;
			set => m_scale = value;
		}

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ElasticMover()
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="deceleration">減速度</param>
		/// <param name="friction">摩擦力</param>
		/// <param name="targetScale">目標値</param>
		/// <param name="scale">現在値</param>
		public ElasticMover( float deceleration, float friction, float targetScale, float scale )
		{
			Deceleration = deceleration;
			Friction     = friction;
			TargetScale  = targetScale;
			Scale        = scale;
		}

		/// <summary>
		/// 更新します
		/// </summary>
		public void Update()
		{
			Update( null );
		}

		/// <summary>
		/// 更新します
		/// </summary>
		public void Update( Action onComplete )
		{
			Amplitude += TargetScale - Scale;
			Scale     += Amplitude * Friction;
			Amplitude *= Deceleration;

			if ( !( Mathf.Abs( TargetScale - Scale ) < 0.005f ) || !( Mathf.Abs( Amplitude ) < 0.001f ) ) return;

			Scale = TargetScale;
			onComplete?.Invoke();
		}
	}
}