using UnityEngine;
using System.Collections;

public class DamageSource {
	public int damageAmount;
	public Vector3 hitPoint;

	/// <summary>
	/// Initializes a new instance of the <see cref="DamageSource"/> class.
	/// </summary>
	/// <param name="amount">The amount of damage applied.</param>
	/// <param name="point">The hit point of the damage source.</param>
	public DamageSource(int amount, Vector3 point) {
		damageAmount = amount;
		hitPoint = point;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
