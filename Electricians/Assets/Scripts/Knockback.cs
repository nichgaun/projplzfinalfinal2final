using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {
	public float force;
	public enum KillType {Melee, Gun, Cannon};
	public KillType myType;
}
