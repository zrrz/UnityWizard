using UnityEngine;
using System.Collections;

public class BaseInput : MonoBehaviour {
	[System.NonSerialized]
	public Vector3 dir;
	[System.NonSerialized]
	public bool sprint;
	[System.NonSerialized]
	public bool jump;
	[System.NonSerialized]
	public bool grapple;
	[System.NonSerialized]
	public bool attack;
}