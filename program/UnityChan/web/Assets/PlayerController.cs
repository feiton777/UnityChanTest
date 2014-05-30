using UnityEngine;
using Utage;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/// <summary>ADVエンジン</summary>
	public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>() as AdvEngine); } }
	[SerializeField]
	AdvEngine engine;

	public float speed = 3.0f;
	public float jumpPower = 6.0f;

	private Vector3 direction = Vector3.zero;
	private CharacterController playerController;
	private Animator animator;
	private AnimatorStateInfo currentBaseState;	// Base Layer で使われるアニメータお現在の状態の参照

	// アニメーター各ステートへの参照
	static int idleState = Animator.StringToHash("Base Layer.Idle");
	static int locoState = Animator.StringToHash("Base Layer.Move");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");
	static int restState = Animator.StringToHash("Base Layer.Rest");

	// Use this for initialization
	void Start () {
		playerController = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator> ();

		//20140526:無理やりな感じなので要検証
		Engine.EndScenario ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!Engine.IsEndScenario) { return; }

		currentBaseState = animator.GetCurrentAnimatorStateInfo(0);	// 参照用のステート変数にBase Layer (0)の現在のステートを設定する

		if (playerController.isGrounded) {

			float inputX = Input.GetAxis("Horizontal");
			float inputZ = Input.GetAxis("Vertical");
			Vector3 inputDirection = new Vector3(inputX, 0, inputZ);
			direction = Vector3.zero;

			//アニメーションのステートがLocomotionの最中のみジャンプできる
			if (currentBaseState.nameHash == locoState || 
			    currentBaseState.nameHash == idleState )
			{
				if(inputDirection.magnitude > 0.1){
					transform.LookAt(transform.position + inputDirection);
					direction += transform.forward*speed;
					animator.SetFloat("Speed", direction.magnitude);
				}else{
					animator.SetFloat("Speed", 0);
				}

				//ステート遷移中でなかったらジャンプできる
				if (!animator.IsInTransition (0)) {
					animator.SetBool("Jump", false);

					if(Input.GetButtonDown("Jump")){
						direction.y += jumpPower;
						animator.SetBool("Jump", true);
						Debug.Log ("JumpStart");
					}
				}
			}
		}



		direction.y += Physics.gravity.y * Time.deltaTime;
		playerController.Move (direction * Time.deltaTime);
	}
}
