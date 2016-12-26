using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellManager : MonoBehaviour {

	SpellBlueprint[] spellList = new SpellBlueprint[12];
	string[,] tempSpell = new string[,]
	{
		{"teo", "test_","test","test"}
	};

	int affinitySelected = '0';

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			//for future melee
			if (affinitySelected != 0)
				cast(affinitySelected*1);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			if (affinitySelected == 0)
			{
				StartCoroutine(resetAffinity());
				affinitySelected = 1;
			}
			else
				cast(affinitySelected*2);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (affinitySelected == 0)
			{
				StartCoroutine(resetAffinity());
				affinitySelected = 2;
			}
			else
				cast(affinitySelected*3);
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			if (affinitySelected == 0)
			{
				StartCoroutine(resetAffinity());
				affinitySelected = 3;
			}
			else
				cast(affinitySelected*4);
		}

	}

	IEnumerator resetAffinity()
	{
		yield return new WaitForSeconds(1f);
		affinitySelected = 0;
	}

	void cast(int spellToCast)
	{
		spellList[spellToCast].executeSpell();
		StopCoroutine(resetAffinity());
		affinitySelected = 0;
	}


	void Start()
	{
		addSpell(tempSpell);
	}

	void addSpell (string[,] spellsToAdd)
	{
		for (int i = 0; i < spellsToAdd.GetLength (0); ++i) 
		{
			//Name
			string name = string.Format ("{0}{1}{2}{3}", spellsToAdd [i, 0], spellsToAdd [i, 1], spellsToAdd [i, 2], spellsToAdd [i, 3]);
			name = name.Replace ("_", " ");
			name = char.ToUpper (name [0]) + name.Substring (1);
			for (int j = 2; j < name.Length; ++j) 
			{
				if (name [j] == ' ') 
				{
					name = string.Format ("{0}{1}{2}", name.Substring (0, j + 1), char.ToUpper (name [j + 1]), name.Substring (j + 2));
					break;
				}
			}
			double damage, cost;
			float castTime;

			//Prefix import
			Prefix temp1 = Resources.Load (string.Format ("Prefix/{0}", spellsToAdd [i, 1])) as Prefix;
			damage = temp1.baseDamage;
			cost = temp1.baseCost;
			castTime = temp1.baseCastTime;

			bool isStem = false;

			//Stem import
			if (spellsToAdd [i, 2] != null) 
			{
				Stem temp2 = Resources.Load(string.Format("Stem/{0}", spellsToAdd[i,2])) as Stem;
				damage += temp2.baseDamage;
				cost += temp2.baseCost;
				castTime += temp2.baseCastTime;
				isStem = true;
			}

			//Suffix import
			Suffix temp3 = Resources.Load(string.Format("Suffix/{0}", spellsToAdd[i,3])) as Suffix;
			damage += temp3.baseDamage;
			cost += temp3.baseCost;
			castTime += temp3.baseCastTime;

			//Value finalisation
			damage /= isStem ? 3 : 2;
			cost /= isStem ? 3 : 2;
			castTime /= isStem ? 3 : 2;
			int size = 1;

			//Classification import
			if (spellsToAdd [i, 0] != null) 
			{
				Classification temp = Resources.Load (string.Format ("Classification/{0}", spellsToAdd [i, 0])) as Classification;
				damage *= temp.costMultiplier;
				cost *= temp.damageMultiplier;
				castTime *= temp.castTimeMultiplier;
				size = temp.size;
			}
			spellList[i] = new SpellBlueprint(name, damage, cost, castTime, size, spellsToAdd[i,3], temp1.element, temp1.mat, temp3.type);
		}
	}
}
