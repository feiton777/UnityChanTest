//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Utage
{

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Sprite2D))]
	public class Sprite2DInspector : Node2DInspector
	{
		public override void DrawProperties()
		{
			Sprite2D obj = target as Sprite2D;
			//スプライト
			UtageEditorToolKit.BeginGroup("Sprite");
			UtageEditorToolKit.PropertyField(serializedObject, "sprite", "Sprite");
			UtageEditorToolKit.PropertyField(serializedObject, "sizeType", "Type");

			bool isCustomSize = obj.SizeType != Sprite2D.SpriteSizeType.Default;
			if (isCustomSize)
			{
				EditorGUILayout.BeginHorizontal();
				UtageEditorToolKit.PropertyField(serializedObject, "customSize", "Size");
				if (GUILayout.Button("Reset", GUILayout.Width(50f)))
				{
					Undo.RecordObject(obj, "isCustomSize Change");
					obj.Size = obj.BaseSize;
					EditorUtility.SetDirty(target);
				}
				EditorGUILayout.EndHorizontal();
			}

			EditorGUILayout.LabelField("Texture Size", obj.BaseSize.x + " x " + obj.BaseSize.y);

			UtageEditorToolKit.EndGroup();

			DrawNode2DProperties();
		}
	}
}