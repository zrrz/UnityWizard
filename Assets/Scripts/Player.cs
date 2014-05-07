using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	BaseInput input;

	public float moveSpeed = 3.0f;
	public float sprintSpeedMod = 1.8f;
	public float turnSpeed = 0.6f;

	public bool grounded;

	const float GROUND_CHECK_DISTANCE = 1.1f;

	public LayerMask mask;

	public float jumpStrength = 3.0f;

	public Transform cameraObj;

	public GameObject projectile;

	public Transform shootPos;
	
	void Start () {
		input = GetComponent<BaseInput>();
	}

	void Update () {
		//---------------------Movement----------------------//
		float speedMod = input.sprint ? sprintSpeedMod : 1.0f;
		rigidbody.angularVelocity = Vector3.zero;

		if (input.dir.magnitude > 0.0f) {
			rigidbody.MovePosition(transform.position + transform.forward * moveSpeed * speedMod * Time.deltaTime);

			Vector3 lookDir = Vector3.zero;
			if(Mathf.Abs(input.dir.z) > 0.0f)
				lookDir += (transform.position - cameraObj.transform.position).normalized * Mathf.Sign(input.dir.z);
			if(Mathf.Abs(input.dir.x) > 0.0f)
				lookDir += Vector3.Cross(transform.up, (transform.position - cameraObj.transform.position).normalized) * Mathf.Sign(input.dir.x);
			lookDir.Normalize();
			lookDir.y = 0.0f;

			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation (lookDir), turnSpeed);
		}

		if (grounded) {
			if(input.jump) {
				rigidbody.AddForce(Vector3.up * jumpStrength);
			}
		}
		//--------------------------------------------------//
		//----------------------Attack----------------------//
		if(input.attack)
		{
			RaycastHit hit;
			if(Physics.Raycast(cameraObj.transform.position, cameraObj.transform.forward, out hit, 500f)) {
				Vector3 target = hit.point;
				GameObject t_obj = (GameObject)Instantiate(projectile, shootPos.position, shootPos.rotation);
				t_obj.GetComponent<Projectile>().dir = (shootPos.position - target).normalized;
			}
		}
	}

	bool CheckGrounded() {
		Debug.DrawRay (transform.position + (Vector3.up * 0.1f), Vector3.down, Color.red, 1.0f);
		return Physics.Raycast (transform.position + Vector3.up, Vector3.down, GROUND_CHECK_DISTANCE, mask);
	}

	void OnGUI() {
		GUI.Box(new Rect(0.0f, 0.0f, 100.0f, 60.0f), "WASD to move\nShift to sprint\nSpace to jump"); 
	}
}
