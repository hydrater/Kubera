using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class SpellManager : MonoBehaviour {
	public GameObject affinityParticle;
	public SpellBlueprint[] spellList = new SpellBlueprint[12];
	string[,] tempSpell = new string[,]
	{
		{"teo", "test_","test",null},
		{"teo", "test_","test",null},
		{"teo", "test_","test",null},
		{"teo", "test_","test",null},

		{"teo", "test_","test",null},
		{"teo", "test_","test",null},
		{"teo", "test_","test",null},
		{"teo", "test_","test",null},

		{"teo", "test_","test",null},
		{"teo", "test_","test",null},
		{"teo", "test_","test",null},
		{"aru", "dos","saru","nia"}
	};

	byte affinitySelected = 0;
	bool isCasting = false;

	void Update()
	{
		if (!isCasting)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				//for future melee
				if (affinitySelected != 0 && spellList[affinitySelected - 1].spellName != "")
					StartCoroutine(cast(affinitySelected*1 - 1));
			}

			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (affinitySelected == 0)
				{
					StartCoroutine(resetAffinity());
					affinitySelected = 1;
					Instantiate(Resources.Load("Others/spellCircle"), transform.position, transform.rotation);
				}
				else if (spellList[affinitySelected*2 - 1].spellName != "")
					StartCoroutine(cast(affinitySelected*2 - 1));
			}

			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				if (affinitySelected == 0)
				{
					StartCoroutine(resetAffinity());
					affinitySelected = 2;
					Instantiate(Resources.Load("Others/spellCircle"), transform.position, transform.rotation);
				}
				else if (spellList[affinitySelected*3 - 1].spellName != "")
					StartCoroutine(cast(affinitySelected*3 - 1));
			}

			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				if (affinitySelected == 0)
				{
					StartCoroutine(resetAffinity());
					affinitySelected = 3;
					Instantiate(Resources.Load("Others/spellCircle"), transform.position, transform.rotation);
				}
				else if (spellList[affinitySelected*4 - 1].spellName != "")
					StartCoroutine(cast(affinitySelected*4 - 1));
			}
			if (Input.GetKeyDown(KeyCode.BackQuote))
				affinitySelected = 0;
		}
	}

	IEnumerator resetAffinity()
	{
		affinityParticle.SetActive(true);
		yield return new WaitForSeconds(2f);
		affinityParticle.SetActive(false);
		affinitySelected = 0;
	}

	public void castInterrupt()
	{
		StopCoroutine("cast");
		isCasting = false;
		//play animation until it's finished
		GetComponent<FirstPersonController>().enabled = true;
	}

	IEnumerator cast(int spellToCast)
	{
		isCasting = true;
		GetComponent<FirstPersonController>().canMove = false;
		Debug.Log("spell is casting" + isCasting);
		float tempCast = spellList[spellToCast].castTime;
		yield return new WaitForSeconds(tempCast);
		isCasting = false;
		GetComponent<FirstPersonController>().canMove = true;
		affinitySelected = 0;
		StopCoroutine(resetAffinity());
		affinityParticle.SetActive(false);
		Debug.Log("spell finished casting " + isCasting);
		GameObject temp = Instantiate(spellList[spellToCast].projectile, transform.position, Camera.main.transform.rotation) as GameObject;
		temp.GetComponent<SpellStat>().damage = spellList[spellToCast].damage;
	}

	void Start()
	{
		addSpell(tempSpell);
	}

	void addSpell (string[,] spellsToAdd)
	{
		for (int i = 0; i < spellsToAdd.GetLength (0); ++i) 
		{
			if (spellsToAdd [i,3] == null)
				continue;
			//Name
			string spellName = string.Format ("{0}{1}{2}{3}", spellsToAdd [i, 0], spellsToAdd [i, 1], spellsToAdd [i, 2], spellsToAdd [i, 3]);
			spellName = spellName.Replace ("_", " ");
			spellName = char.ToUpper (spellName [0]) + spellName.Substring (1);
			for (int j = 2; j < spellName.Length; ++j) 
			{
				if (spellName [j] == ' ') 
				{
					spellName = string.Format ("{0}{1}{2}", spellName.Substring (0, j + 1), char.ToUpper (spellName [j + 1]), spellName.Substring (j + 2));
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
			spellList[i] = new SpellBlueprint(spellName, damage, cost, castTime, size, spellsToAdd[i,3], temp1.element, temp1.mat, temp3.type);
		}
	}
}
