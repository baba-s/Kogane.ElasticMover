using System;
using UnityEngine;

namespace Kogane
{
	/// <summary>
	/// ぼよよんと出る動きを管理するクラス
	/// </summary>
	public sealed class ElasticMover
	{
		//==============================================================================
		// プロパティ
		//==============================================================================
		public float Amplitude    { get; set; } // 振幅を取得または設定します
		public float Deceleration { get; set; } // 減速度を取得または設定します
		public float Friction     { get; set; } // 摩擦力を取得または設定します
		public float TargetScale  { get; set; } // 目標値を取得または設定します
		public float Scale        { get; set; } // 現在値を取得または設定します

		//==============================================================================
		// 関数
		//==============================================================================
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