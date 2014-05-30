using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float distance = 5.0f;
	public float height = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position + (-Vector3.forward * distance) + (Vector3.up * height);
		transform.LookAt (target);
	}
}
