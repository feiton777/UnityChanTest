//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace Utage
{

	/// <summary>
	/// システム系のUI処理
	/// </summary>
	[AddComponentMenu("Utage/Lib/UI/SystemUi")]
	public class SystemUi : MonoBehaviour
	{
		/// <summary>
		/// シングルトンなインスタンスの取得
		/// </summary>
		/// <returns></returns>
		public static SystemUi GetInstance()
		{
			return instance;
		}
		static SystemUi instance;


		void Awake()
		{
			if (null == instance)
			{
				instance = this;
			}
			else
			{
				Debug.LogError(LanguageErrorMsg.LocalizeTextFormat(ErrorMsg.SingletonError));
				Destroy(this);
			}
		}

		[SerializeField]
		Dialog2Button dialogGameExit;

		public CameraManager CameraManager { get { return this.cameraManager ?? (this.cameraManager = FindObjectOfType<CameraManager>() as CameraManager); } }
		[SerializeField]
		CameraManager cameraManager;

		[SerializeField]
		Dialog1Button dialog1Button;

		[SerializeField]
		Dialog2Button dialog2Button;

		[SerializeField]
		Dialog3Button dialog3Button;

		[SerializeField]
		IndicatorIcon indicator;

		/// <summary>
		/// Escapeボタンの入力有効か
		/// </summary>
		public bool IsEnableInputEscape
		{
			get { return isEnableInputEscape; }
			set { isEnableInputEscape = value; }
		}
		[SerializeField]
		bool isEnableInputEscape = true;


		/// <summary>
		/// 1ボタンのダイアログを開く
		/// </summary>
		/// <param name="text">表示テキスト</param>
		/// <param name="buttonText1">ボタン1のテキスト</param>
		/// <param name="target">ボタン1を押したときのメッセージの送り先</param>
		/// <param name="func1">ボタン1を押したときに送られるメッセージ</param>
		public void OpenDialog1Button(string text, string buttonText1, GameObject target, string func1)
		{
			dialog1Button.Open(text, buttonText1, target, func1 );
		}

		/// <summary>
		///  2ボタンのダイアログを開く
		/// </summary>
		/// <param name="text">表示テキスト</param>
		/// <param name="buttonText1">ボタン1用のテキスト</param>
		/// <param name="buttonText2">ボタン2用のテキスト</param>
		/// <param name="target">ボタンを押したときのメッセージの送り先</param>
		/// <param name="func1">ボタン1を押したときに送られるメッセージ</param>
		/// <param name="func2">ボタン2を押したときに送られるメッセージ</param>
		public void OpenDialog2Button(string text, string buttonText1, string buttonText2, GameObject target, string func1, string func2)
		{
			dialog2Button.Open(text, buttonText1, buttonText2, target, func1, func2);
		}
		
		/// <summary>
		/// 3ボタンのダイアログを開く
		/// </summary>
		/// <param name="text">表示テキスト</param>
		/// <param name="buttonText1">ボタン1用のテキスト</param>
		/// <param name="buttonText2">ボタン2用のテキスト</param>
		/// <param name="buttonText3">ボタン3用のテキスト</param>
		/// <param name="target">ボタンを押したときのメッセージの送り先</param>
		/// <param name="func1">ボタン1を押したときに送られるメッセージ</param>
		/// <param name="func2">ボタン2を押したときに送られるメッセージ</param>
		/// <param name="func3">ボタン3を押したときに送られるメッセージ</param>
		public void OpenDialog3Button(string text, string buttonText1, string buttonText2, string buttonText3, GameObject target, string func1, string func2, string func3)
		{
			dialog3Button.Open(text, buttonText1, buttonText2, buttonText3, target, func1, func2, func3 );
		}

		/// <summary>
		/// はい、いいえダイアログを開く
		/// </summary>
		/// <param name="text">表示テキスト</param>
		/// <param name="target">ボタンを押したときのメッセージの送り先</param>
		/// <param name="yesFunc">yesを押したときに送られるメッセージ</param>
		/// <param name="noFunc">noを押したときに送られるメッセージ</param>
		public void OpenDialogYesNo(string text, GameObject target, string yesFunc, string noFunc)
		{
			OpenDialog2Button(text, LanguageSystemText.LocalizeText(SystemText.Yes), LanguageSystemText.LocalizeText(SystemText.No), target, yesFunc, noFunc);
		}

		/// <summary>
		/// 1ボタンのダイアログを開く（テキストを複数ページで表示）
		/// </summary>
		/// <param name="textArray">表示テキスト。配列要素ごとに複数ページに対応</param>
		/// <param name="buttonText1">ボタン1のテキスト</param>
		/// <param name="target">最終ページでボタン1を押したときのメッセージの送り先</param>
		/// <param name="func1">最終ページでボタン1を押したときに送られるメッセージ</param>
		public void OpenDialog1Button(string[] textArray, string buttonText1, GameObject target, string func1)
		{
			dialog1Button.Open(textArray, buttonText1, target, func1 );
		}

		/// <summary>
		/// インジケーターの表示開始
		/// 表示要求しているオブジェクトはあちこちから設定できる。
		/// 全ての要求が終了しない限りは表示を続ける
		/// </summary>
		/// <param name="obj">表示を要求してるオブジェクト</param>
		public void StartIndicator(Object obj)
		{
			indicator.StartIndicator(obj);
		}

		/// <summary>
		/// インジケーターの表示終了
		/// 表示要求しているオブジェクトはあちこちから設定できる。
		/// 全ての要求が終了しない限りは表示を続ける
		/// </summary>
		/// <param name="obj">表示を要求していたオブジェクト</param>
		public void StopIndicator(Object obj)
		{
			indicator.StopIndicator(obj);
		}

		void Update()
		{
			//Android版・バックキーでアプリ終了確認
			if (IsEnableInputEscape)
			{
				if (Input.GetKeyDown(KeyCode.Escape))
				{
					IsEnableInputEscape = false;
					dialogGameExit.Open(
						LanguageSystemText.LocalizeText(SystemText.QuitGame),
						LanguageSystemText.LocalizeText(SystemText.Yes),
						LanguageSystemText.LocalizeText(SystemText.No),
						this.gameObject, "OnDialogExitGameYes", "OnDialogExitGameNo"
						);
				}
			}
		}

		//ゲーム終了確認「はい」
		void OnDialogExitGameYes()
		{
			IsEnableInputEscape = true;
			StartCoroutine(CoGameExit());
		}
		//ゲーム終了確認「いいえ」
		void OnDialogExitGameNo()
		{
			IsEnableInputEscape = true;
		}

		//ゲーム終了
		IEnumerator CoGameExit()
		{
			yield return StartCoroutine(CameraManager.CoGameExit());
			Application.Quit();
		}
	}

}