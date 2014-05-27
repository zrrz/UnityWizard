using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	[System.NonSerialized]
	public Vector3 dir;
	public float speed = 5.0f;

	void Start () {
		Destroy(gameObject, 10.0f);
	}

	void Update () {
		transform.position += dir * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision col) {
		Destroy(gameObject);
		col.gameObject.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
	}
}