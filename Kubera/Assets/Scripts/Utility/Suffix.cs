﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Words/Suffix")]
public class Suffix : ScriptableObject {
	public int baseDamage, baseCost;
	public float baseCastTime;
	public float speed;
	public char type;

}
