//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------

using UnityEditor;
using UnityEngine;
using System.IO;

namespace Utage
{

	public class MeuToolOpen : ScriptableObject
	{
		public const string MeuToolRoot = "Tools/Utage/";

		/// <summary>
		/// シナリオデータビルダーを開く
		/// </summary>
		[MenuItem(MeuToolRoot + "Scenario Data Builder", priority = 0)]
		static public void AdvExcelEditorWindow()
		{
			EditorWindow.GetWindow(typeof(AdvScenarioDataBuilderWindow), false, "Scenario Data");
		}
	}
}