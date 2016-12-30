using UnityEngine;
using System.Collections;

public class Map{
	Box[,] corresponding_Arrays;
	int linelength , columnlength;
		public Map(int x, int y){
			corresponding_Arrays = new Box[y,x]; 
			linelength = x;
			columnlength = y;
			for (int i = 0; i < columnlength; i++) {
				for (int j = 0; j < linelength; j++) {
					corresponding_Arrays [j, i] = new Box ("Void", -1, new Color (0, 0, 0), i, j);
				}
			}			
		}
				
	public void randomize(){
		string terrain = null;
		Color boxColor = new Color(0,0,0);
		for (int i = 0; i < columnlength;i++) {
			for (int j = 0; j < linelength; j++) {
				int a = Random.Range (0, 4);
				Debug.Log (a);
				switch (a) {

				case 0:
					terrain = "eau";
					boxColor = new Color (0, 1, 1);
					break;
				case 1:
					terrain = "montagne";
					boxColor = new Color (0.5f, 0.5f, 0.5f);
					break;
				case 2:
					terrain = "feu";
					boxColor = new Color (1, 0, 0);
					break;
				case 3:
					terrain = "plaine";
					boxColor = new Color (0, 1, 0);
					break;
				}
				corresponding_Arrays [j,i] = new Box (terrain,0,boxColor,i,j);
				corresponding_Arrays [j, i].update_box ();
			}
		}
	}

	public void setup(){
		string terrain = null;
		Color boxColor = new Color(0,0,0);
		for (int i = 0; i < columnlength;i++) {
			for (int j = 0; j < linelength; j++) {
				corresponding_Arrays [j,i] = new Box (terrain,0,boxColor,i,j);
				corresponding_Arrays [j, i].update_box ();
			}
		}

	}
}

public class Box{
	string terrain;
	int player;	
	Color boxColor;
	GameObject BoxObject = new GameObject();
	int x,y;

	public Box (){
		terrain = "";
		player = 0;
		boxColor = new Color (0, 0, 0);
	}


	public Box(string terrain, int player, Color boxColor, int x,int y){
		this.terrain = terrain;
		this.player = player;
		this.boxColor = boxColor;
		this.x = x;
		this.y = y;
		BoxObject.AddComponent<SpriteRenderer> ();
		BoxObject.GetComponent<Transform> ().position = new Vector3 (x, y);
	}
	public void update_box(){
		Debug.Log(Resources.Load<Sprite> ("Test"));
		BoxObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Test");
		BoxObject.GetComponent<SpriteRenderer> ().color = boxColor;
	}		
}
