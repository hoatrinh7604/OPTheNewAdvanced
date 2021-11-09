using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Lop nay phu trach dan truyen theo tung man choi
public class StoryManager : MonoBehaviour {

	public static int idPiece = 1;

	private int idCurrentLevelScene;

	private BgSounds bgSound;

	[SerializeField] GameObject[] NoticeStory;

	[SerializeField] Text[] textStory;

	[SerializeField] GameObject storyParent;

	void Start(){
		
		PauseSystem.pauseGame ();
		idCurrentLevelScene = SceneManager.GetActiveScene ().buildIndex - 3;
		setListStoryById (idPiece);

		bgSound = GameObject.FindGameObjectWithTag ("Sounds").GetComponentInChildren<BgSounds> ();
		bgSound.playSound (2);
	}

	public void setListStoryById(int idStory){
		setDisableWithOut (idStory-1);
		//Debug.Log ("Idpiece = " + idPiece);
		NoticeStory [idStory - 1].SetActive (true);
		textStory [idStory -1].text = getStoryForEach (idCurrentLevelScene, NoticeStory.Length)[idStory -1];
	}

	public void setDisableWithOut(int id){
		for (int i = 0; i < NoticeStory.Length; i++) {
			if(id != i){
				NoticeStory [i].SetActive (false);
			}
		}
	}

	public void setEndStory(){
		bgSound.playSound (2);
		storyParent.SetActive (true);
		NoticeStory [idPiece-1].SetActive (true);
		textStory [idPiece-1].text = getStoryForEach (idCurrentLevelScene, NoticeStory.Length)[idPiece-1];
	}

	public void skipStory(){
		idPiece++;
		if (idPiece > NoticeStory.Length) {
			idPiece = 1;
			endOfGame ();
		} else if(idPiece == NoticeStory.Length){
			playGame ();
		}else {
			NoticeStory [idPiece - 1].SetActive (false);
			setListStoryById (idPiece);
		}
			
	}

	public void playGame(){
		PauseSystem.resumeGame ();
		for (int i = 0; i < NoticeStory.Length; i++) {
			NoticeStory [i].SetActive (false);
		}
		storyParent.SetActive (false);

		bgSound.playSound (1);
		//
	}

	public void endOfGame(){
		idPiece = 1;
		gameObject.GetComponent<FinishLevel> ().setStarScore ();
		bgSound.playSound (3);
	}


	public string[] getStoryForEach(int idLevelScene, int numPiece){
		
		string[] temp = new string[numPiece];
		switch(idLevelScene){
		case 1:
			temp[0] = "Màn 1-1: Đi đi, hãy tìm kiếm sự tự do cho chính bản thân mình...";
			temp [1] = "Chuyến hành trình đầu tiên của mình, ngươi thấy thế nào!"; 
			break;

		case 2:
			temp [0] = "Màn 1-2: So với trận chiến đầu tiên, kẻ thù đang trở nên nhiều hơn...";
			temp [1] = "Ngươi đã chạm vào thứ không nên chạm lấy!"; 
			break;

		case 3:
			temp [0] = "Màn 1-3: Ta sẽ trả thù cho anh em của ta!";
			temp [1] = "Tiếp tục đi, ông lớn đang đợi ngươi!"; 
			break;

		case 4:
			temp [0] = "Màn 1-4(Boss): Trận chiến đầu tiên với kẻ mạnh!";
			temp [1] = "Arlong là một người cá nguy hiểm có sức mạnh gấp 10 người bình thường. Hắn luôn coi thường con người vì cho rằng con người là sinh vật yếu đuối...";
			temp [2] = "Ta thấy ngươi đã sẵn sàng với chuyến hành trình của mình! Hahaha..."; 
			break;

		case 5:
			temp [0] = "Màn 2-1: Sự thống trị của một tổ chức nguy hiểm!";
			temp [1] = "Kẻ địch tiếp theo đang dần lộ diện... Quý ngài Mr.3???"; 
			break;

		case 6:
			temp [0] = "Màn 2-2: Tổ chức bí mật tên là Baroque Work!";
			temp [1] = "Ngươi đã tiêu diệt một phần trong số chúng, hãy cẩn thận hơn!"; 
			break;

		case 7:
			temp [0] = "Màn 2-3: Cánh tay phải đắc lực của kẻ cầm đầu ở phía trước, nhanh chân hơn đi!";
			temp [1] = "Ngươi đã nghe thấy cái tên \"Crocodile\" bao giờ chưa?"; 
			break;

		case 8:
			temp [0] = "Màn 2-4(Boss): Kẻ ngươi đang đối đầu thật sự là ai?";
			temp [1] = "Crocodile hay Cá sấu chúa là một trong những tên cướp biển khá cẩn thận và kín tiếng. Mọi hành động của hắn đều được dự tính từ trước. Hắn là một trong bảy Thất vũ hải nguy hiểm!"; 
			temp [2] = "Tốt lắm, dù đối thủ mạnh nhưng ngươi vẫn vượt qua được. Tiến lên nào!"; 
			break;

		case 9:
			temp [0] = "Màn 3-1 (Skypiea): Một thế giới mới: Hãy đặt niềm tin vào những kẻ luôn nói dối!";
			temp [1] = "Điều ông ta nói thật sự tồn tại, thế giới đó là có thật!"; 
			break;

		case 10:
			temp [0] = "Màn 3-2: Nơi đây thật đẹp nhưng cũng đầy rẫy những nguy hiểm khi nhắc về \"Chúa\"";
			temp [1] = "\"Chúa\" mà ngươi nhắc đến thật sự lài ai?"; 
			break;

		case 11:
			temp [0] = "Màn 3-3: Là bạn hay là thù?";
			temp [1] = "Hắn cũng chỉ là người, nhưng lại khiến chúng ta sợ hãi!"; 
			break;

		case 12:
			temp [0] = "Màn 3-4(Boss): Đức chúa trời quyền năng! Không, đó là Enel!";
			temp [1] = " Chúa trời Enel là người của tộc Birkan - một trong ba tộc người có đôi cánh trên lưng và có nguồn gốc từ mặt trăng. Hắn không phải hải tặc nhưng nếu bị truy nã thì con số sẽ khá lớn..."; 
			temp [2] = "Hắn vẫn còn sống, nếu ngươi muốn gặp,... hãy bay tới mặt trăng! Đó là thông tin mà ngươi nên biết!";
			break;

		case 13:
			temp [0] = "Màn 4-1(Water 7): Liệu những người tốt có thật sự tốt???";
			temp [1] = "Muốn tìm câu trả lời, hãy đi đến tận cùng!"; 
			break;

		case 14:
			temp [0] = "Màn 4-2: Lần đầu tiên nghe đến CP9";
			temp [1] = "CP9 là một tổ chức được thành lập của hải quân với nhiệm vụ tiêu diệt những mối lo ngại bằng những cách \"đơn giản\" nhất"; 
			break;

		case 15:
			temp [0] = "Màn 4-3: Nếu con đường phía trước là ngõ cụt, tôi sẽ đập bể nó!";
			temp [1] = "Tên thủ lĩnh vẫn còn là một ẩn số, bồ câu mang nghĩa là gì?";
			break;

		case 16:
			temp [0] = "Màn 4-4(Boss): Bồ câu không nên bay?";
			temp [1] = "Rob lucci là kẻ đứng đầu của tổ chức CP9, hắn giấu mình dưới thân phận là một người đóng tàu bình thường. Là người của hải quân với sự điềm tĩnh chết người!";
			temp [2] = "Ngươi đang đối đầu với một thế lực còn lớn hơn cả nỗi sợ...";
			break;

		case 17:
			temp [0] = "Màn 5-1(Thriller Bark): Thế giới của bóng đêm";
			temp [1] = "Âm thanh rùng rợn, những con người quái dị đang ở phía trước...";
			break;

		case 18:
			temp [0] = "Màn 5-2: Ngươi chưa nên gặp hắn vội!";
			temp [1] = "Thời gian càng lúc càng chậm...";
			break;

		case 19:
			temp [0] = "Màn 5-3: Bác sĩ không nhân tính!";
			temp [1] = "Dr.Hockback được biết đến với nhân vật gần giống như Frankenstein, là người có thể hồi sinh người đã chết. Tuy nhiên mục đích lại khác nhau, Hockback chỉ muốn tạo đội quân phục tùng cho riêng mình!";
			break;

		case 20:
			temp [0] = "Màn 5-4: Hồn ma xuất hiện từ đâu?";
			temp [1] = "Perona là 1 thành viên chủ lực của Thriller Bark. Perona tự tin về bản thân nhưng cũng rất cả tin, dễ bị lừa. Cô trông khá dễ thương với đôi mắt nai tròn xoe, mái tóc hồng buộc 2 bên cực kì xinh xắn và ăn mặc theo phong cách Gothic Lolita. Chính vì thế, không thể phủ nhận sức hấp dẫn của cô nàng này với người khác phái.";
			break;

		case 21: 
			temp [0] = "Màn 5-5(Final): Kẻ thống trị bóng đêm!";
			temp [1] = "Gecko Moria là một trong bảy thất vũ hải, tại hòn đảo Thriller Bark của mình, hắn âm mưu xây dựng một quân đoàn xác chết với mục đích thống trị thế giời bóng đêm!";
			temp [2] = "Tốt lắm, ngươi đã hoàn thành chuyến hành trình đầu tiên của mình tại One piece: The new adventure. Thông tin One piece vẫn còn là một ẩn số với ngươi, hãy đợi ta cho đến khi ta quay lại, One piece sẽ là của ngươi... Hahaha";
			break;
		}

		return temp;
	}
}
