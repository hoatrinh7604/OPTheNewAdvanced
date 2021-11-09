using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ham nay luu lai thong tin cua nhan vat dang duoc chon de su dung lai trong cac Scene ma khong phai load lai thong tin
public class GameInfo : MonoBehaviour {
	
	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}

	public static int Id { get; set;}
	public static string Name { get; set;}
	public static int Level { get; set;}
	public static int CurrentEx { get; set;}
	public static BaseClass PlayerClass { get; set;}

	public static int Health { get; set;}
	public static int Energy { get; set;}
	public static int Strength { get; set;}
	public static int Armor { get; set;}
	public static int Speed { get; set;}
	public static int Critical { get; set;}
	public static int Points { get; set;}
	public static int Bounty { get; set;}
	public static string Biography{ get; set;}
	//public static int HitPoints { get; set;}
	//public static int Regeneration { get; set;}

	public static int NumEnemyAlive { get; set;}

	public static BaseClass getBaseClass(){
		BaseClass newPlayer = new BaseClass ();

		newPlayer.Id = Id;
		newPlayer.Level = Level;
		newPlayer.CurrentEx = CurrentEx;
		newPlayer.Name = Name;

		newPlayer.Strength = Strength;
		newPlayer.Health = Health;
		newPlayer.Energy = Energy;
		newPlayer.Armor = Armor;
		newPlayer.Speed = Speed;
		newPlayer.Critical = Critical;
		newPlayer.Points = Points;
		newPlayer.Bounty = Bounty;
		newPlayer.Biography = Biography;

		return newPlayer;
	}
}
