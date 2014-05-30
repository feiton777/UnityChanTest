using UnityEngine;
using Utage;
using System.Collections;

public class CubeEventRed : MonoBehaviour {

	/// <summary>ADVエンジン</summary>
	public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
	[SerializeField]
	AdvEngine engine;

	/// <summary>
	/// 設定データ
	/// </summary>
	[SerializeField]
	AdvSettingDataManager settingDataManager;
	
	/// <summary>
	/// エクスポートしたシナリオデータがあればここに設定可能
	/// </summary>
	[SerializeField]
	AdvScenarioDataExported[] exportedScenarioDataTbl;


	/// <summary>リソースディレクトリのルートパス</summary>
	[SerializeField]
	string rootResourceDir;

	[SerializeField]
	string ResourceDir { get { return (rootResourceDir); } }


	// Use this for initialization
	void Start () {
		if (settingDataManager == null) { Debug.LogError("Not set SettingDataManager", this); return; }
		if (exportedScenarioDataTbl.Length <= 0) { Debug.LogError("Not set ExportedScenarioDataTbl", this); return; }
		if (string.IsNullOrEmpty(ResourceDir)) { Debug.LogError("Not set ResourceData", this); return; }
		Engine.BootFromExportData(settingDataManager, exportedScenarioDataTbl, ResourceDir);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			StartEngine();
		}
	}

	public void StartEngine()
	{
		StartCoroutine(CoPlayEngine());
	}
	
	IEnumerator CoPlayEngine()
	{
		while (Engine.IsWaitBootLoading) yield return 0;
		Engine.StartGame();
	}

}
