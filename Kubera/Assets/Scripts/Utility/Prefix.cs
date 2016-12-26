﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Words/Prefix")]
public class Prefix : ScriptableObject {
	public string mat;
	public int baseDamage, baseCost, baseCastTime;
	public char element, effect;
}
