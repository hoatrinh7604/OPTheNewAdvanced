using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass {

	private int id;
	private string name;
	private int level;
	private int currentEx;

	private int health;
	private int energy;
	private int strength;
	private int armor;
	private int speed;
	private int critical;

	private int bounty;
	private string biography;

	private int points;

	//private int hitPoints;

	//private int regeneration;

	public int Id{
		get {return id;}
		set {id = value;}
	}

	public string Name{
		get {return name;}
		set {name = value;}
	}

	public int Level{
		get {return level;}
		set {level = value;}
	}

	public int CurrentEx{
		get {return currentEx;}
		set {currentEx = value;}
	}

	public int Strength{
		get {return strength;}
		set {strength = value;}
	}

	public int Energy{
		get {return energy;}
		set {energy = value;}
	}

	public int Health{
		get {return health;}
		set {health = value;}
	}

	public int Armor{
		get {return armor;}
		set {armor = value;}
	}

	public int Speed{
		get {return speed;}
		set {speed = value;}
	}

	public int Critical{
		get {return critical;}
		set {critical = value;}
	}

	public int Bounty{
		get {return bounty;}
		set {bounty = value;}
	}

	public string Biography{
		get {return biography;}
		set {biography = value;}
	}

	public int Points{
		get {return points;}
		set {points = value;}
	}

	/*
	public int HitPoints{
		get {return hitPoints;}
		set {hitPoints = value;}
	}

	// times to reborn
	public int Regeneration{
		get {return regeneration;}
		set {regeneration = value;}
	}
	*/
}
