using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay chua cac gia tri thuoc tinh co ban cua Enemy, phuc vu viec khoi tao Enemy
public class NPC {
	[SerializeField] int idEnemy;

	public string nameEnemy { get; set;}
	public float baseLevel { get; set;}
	public float baseHealth { get; set;}
	public float baseMana { get; set;}
	public float baseDmg { get; set;}
	public float baseArmor { get; set;}

	public int baseScore { get; set;}
	public int baseXp { get; set;}

	public void setBaseInfo(int idEnemy){
		if (idEnemy == 1) {
			baseHealth = 300; baseMana = 0; baseDmg = 30; baseArmor = 20; baseScore = 10000; baseXp = 80; nameEnemy = "Pirate";
		} else if(idEnemy == 2){
			baseHealth = 310; baseMana = 0; baseDmg = 35; baseArmor = 25; baseScore = 15000; baseXp = 90; nameEnemy = "Pirate";
		} else if(idEnemy == 3){
			baseHealth = 350; baseMana = 0; baseDmg = 45; baseArmor = 28; baseScore = 25000; baseXp = 110; nameEnemy = "Pirate";
		} else if(idEnemy == 4){
			baseHealth = 1000; baseMana = 300; baseDmg = 50; baseArmor = 30; baseScore = 30000; baseXp = 200; nameEnemy = "Chew";
		} else if(idEnemy == 5){
			baseHealth = 1100; baseMana = 320; baseDmg = 53; baseArmor = 33; baseScore = 31000; baseXp = 500; nameEnemy = "Kurrobi";
		} else if(idEnemy == 6){
			baseHealth = 1600; baseMana = 360; baseDmg = 55; baseArmor = 36; baseScore = 53000; baseXp = 1000; nameEnemy = "Mr.3";
		} else if(idEnemy == 7){
			baseHealth = 1750; baseMana = 370; baseDmg = 60; baseArmor = 39; baseScore = 57000; baseXp = 1700; nameEnemy = "Mr.1";
		} else if(idEnemy == 8){
			baseHealth = 1900; baseMana = 400; baseDmg = 65; baseArmor = 42; baseScore = 85000; baseXp = 3000; nameEnemy = "Kaori";
		} else if(idEnemy == 9){
			baseHealth = 2000; baseMana = 410; baseDmg = 70; baseArmor = 45; baseScore = 90000; baseXp = 3500; nameEnemy = "Shura";
		} else if(idEnemy == 10){
			baseHealth = 2100; baseMana = 460; baseDmg = 75; baseArmor = 48; baseScore = 110000; baseXp = 4100; nameEnemy = "Blueno";
		} else if(idEnemy == 11){
			baseHealth = 2200; baseMana = 470; baseDmg = 80; baseArmor = 51; baseScore = 120000; baseXp = 4300; nameEnemy = "Kaku";
		} else if(idEnemy == 12){
			baseHealth = 2300; baseMana = 510; baseDmg = 85; baseArmor = 54; baseScore = 160000; baseXp = 6000; nameEnemy = "Hock Back";
		} else if(idEnemy == 13){
			baseHealth = 950; baseMana = 550; baseDmg = 90; baseArmor = 57; baseScore = 180000; baseXp = 7000; nameEnemy = "Perona";
		} else if(idEnemy == 14){
			baseHealth = 1500; baseMana = 350; baseDmg = 95; baseArmor = 60; baseScore = 50000; baseXp = 1000; nameEnemy = "Arlong";
		} else if(idEnemy == 15){
			baseHealth = 1700; baseMana = 390; baseDmg = 100; baseArmor = 63; baseScore = 80000; baseXp = 3000; nameEnemy = "Crocodile";
		} else if(idEnemy == 16){
			baseHealth = 1900; baseMana = 450; baseDmg = 105; baseArmor = 66; baseScore = 100000; baseXp = 5000; nameEnemy = "Enel";
		} else if(idEnemy == 17){
			baseHealth = 2200; baseMana = 500; baseDmg = 110; baseArmor = 70; baseScore = 150000; baseXp = 9000; nameEnemy = "Lucci";
		} else if(idEnemy == 18){
			baseHealth = 3000; baseMana = 600; baseDmg = 150; baseArmor = 80; baseScore = 200000; baseXp = 12000; nameEnemy = "Moria";
		} else {
			baseHealth = 250; baseMana = 0; baseDmg = 20; baseArmor = 10; baseScore = 10; baseXp = 100;
		}

		baseLevel = 1;
	}
}
