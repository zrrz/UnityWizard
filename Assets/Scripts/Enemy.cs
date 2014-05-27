using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float moveSpeed = 2.0f;

	BaseInput input;

	float health = 3.0f;

	void Start () {
		input = GetComponent<BaseInput>();
	}

	void Update () {
		if (input.dir.magnitude > 0.0f) {
			rigidbody.MovePosition(transform.position + input.dir * moveSpeed * Time.deltaTime);
			
			//Vector3 lookDir = Vector3.zero;
			//if(Mathf.Abs(input.dir.z) > 0.0f)
			//	lookDir += (transform.position - cameraObj.transform.position).normalized * Mathf.Sign(input.dir.z);
			//if(Mathf.Abs(input.dir.x) > 0.0f)
			//	lookDir += Vector3.Cross(transform.up, (transform.position - cameraObj.transform.position).normalized) * Mathf.Sign(input.dir.x);
			//lookDir.Normalize();
			//lookDir.y = 0.0f;
			
			//transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation (lookDir), turnSpeed);
		}
		if(input.attack)
		{

		}
	}

	public void Hit() {
		health--;
		if(health < 0)
			Destroy(gameObject);
	}
}
