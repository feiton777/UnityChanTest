//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------
using UnityEngine;

namespace Utage
{

	/// <summary>
	/// コマンド：ELSE IF処理
	/// </summary>
	internal class AdvCommandElseIf : AdvCommand
	{

		public AdvCommandElseIf(StringGridRow row, AdvSettingDataManager dataManager)
		{
			this.exp = dataManager.DefaultParam.CreateExpressionBoolean(AdvParser.ParseCell<string>(row, AdvColumnName.Arg1));
			if (this.exp.ErrorMsg != null)
			{
				Debug.LogError(row.ToErrorString(this.exp.ErrorMsg));
			}
		}

		public override void DoCommand(AdvEngine engine)
		{
			engine.ScenarioPlayer.IfManager.ElseIf(engine.Param, exp);
		}

		//IF文タイプのコマンドか
		public override bool IsIfCommand { get { return true; } }

		ExpressionParser exp;
	}
}