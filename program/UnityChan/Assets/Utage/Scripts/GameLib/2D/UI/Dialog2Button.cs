//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace Utage
{
	/// <summary>
	/// ボタン二つのダイアログ
	/// </summary>
	[AddComponentMenu("Utage/Lib/UI/Dialog2Button")]
	public class Dialog2Button : Dialog1Button
	{

		/// <summary>
		/// ボタン2用のテキストエリア
		/// </summary>
		[SerializeField]
		protected TextArea2D button2Label;

		/// <summary>
		/// ボタン2を押したときに送られるメッセージ
		/// </summary>
		[SerializeField]
		protected string func2;

		/// <summary>
		/// 二ボタンダイアログをダイアログを起動
		/// </summary>
		/// <param name="text">表示テキスト</param>
		/// <param name="buttonText1">ボタン1用のテキスト</param>
		/// <param name="buttonText2">ボタン2用のテキスト</param>
		/// <param name="target">ボタンを押したときのメッセージの送り先</param>
		/// <param name="func1">ボタン1を押したときに送られるメッセージ</param>
		/// <param name="func2">ボタン2を押したときに送られるメッセージ</param>
		public void Open(string text, string buttonText1, string buttonText2, GameObject target, string func1, string func2 )
		{
			button2Label.text = buttonText2;
			this.func2 = func2;
			base.Open(text, buttonText1, target, func1 );
		}

		/// <summary>
		/// ボタン2が押された
		/// </summary>
		protected void OnTapButton2()
		{
			UtageToolKit.SafeSendMessage(target, func2);
			Close();
		}
	}

}