using UnityEngine;
using System.Collections;

public class EnemyInput : BaseInput {
	
	public Transform player;

	public float attackRange = 2.0f;

	public float attackCD = 1.0f;

	float attackTimer = 0.0f;

	void Update () {
		dir = (player.position - transform.position).normalized;
		//sprint = Input.GetButton("Sprint");
		//jump = Input.GetButtonDown("Jump");
		if(attackTimer > 0.0f)
			attackTimer -= Time.deltaTime;
		if(Vector3.Distance(transform.position, player.position) < 2.0f) {
			if(attackTimer <= 0.0f) {
				attack = Input.GetButtonDown("Fire2");
				attackTimer = attackCD;
			}
		}
	}
}