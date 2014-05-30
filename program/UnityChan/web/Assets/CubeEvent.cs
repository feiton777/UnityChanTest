using UnityEngine;
using Utage;
using System.Collections;

public class CubeEvent : MonoBehaviour {

	/// <summary>ADVエンジン</summary>
	public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
	[SerializeField]
	AdvEngine engine;

	public AdvEngineStarter EngineStarter { get { return this.engineStarter ?? (this.engineStarter = FindObjectOfType<AdvEngineStarter>() as AdvEngineStarter); } }
	[SerializeField]
	AdvEngineStarter engineStarter;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			EngineStarter.StartEngine();
		}
	}


}
