using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpeedClass : BaseClass {

	public BaseSpeedClass(){
		Id = 2;
		Name = "Sanji";
		Level = 1;
		CurrentEx = 100;
		Health = 20;
		Energy = 20;
		Armor = 20;
		Strength = 20;
		Speed = 35;
		Critical = 500;
		Points = 5;

		Bounty = 0;
		Biography = "\t Vinsmoke Sanji sinh ra ở vùng biển Tây nhưng lại lớn lên ở biển Đông, cậu là một đầu bếp tài năng và trân trọng đôi tay của mình. Không dùng tay khi chiến đấu. Ước mơ là tìm thấy vùng biển All Blue - nơi chứa đựng mọi món quà của biển cả...";
		//Regeneration = 0;
	}
}
