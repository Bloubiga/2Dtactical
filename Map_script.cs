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
		Box one;
		int[] values;
		for (int i = 0; i < columnlength;i++) {
			for (int j = 0; j < linelength; j++) {
				values = new int[4];
				if (i == 0) {
					one = randomColor (values, 0, j);
					one.update_box();
				}
				if (j == 0) {
					values [corresponding_Arrays [i - 1, j].getNumber()]++;
					values [corresponding_Arrays [i - 1, j + 1].getNumber()]++;
					one = randomColor (values, i, j);
					one.update_box();
				}
				if (j == linelength) {
					values [corresponding_Arrays [i - 1, j].getNumber ()]++;
					values [corresponding_Arrays [i, j - 1].getNumber ()]++;
					one = randomColor (values, i, j);
					one.update_box ();
				} else {
					values [corresponding_Arrays [i - 1, j].getNumber ()]++;
					values [corresponding_Arrays [i - 1, j - 1].getNumber ()]++;
					values [corresponding_Arrays [i, j - 1].getNumber ()]++;
					one = randomColor (values, i, j);
					one.update_box ();

				}
				corresponding_Arrays [i, j] = one;
				Debug.Log (values);
			}
		}

	}

	public Box randomColor(int[] values,int x,int y){
		string terrain = null;
		Color boxColor = new Color (0,0,0);
		if (values[0] + values[1] + values[2] + values[3] == 0){
			int a = Random.Range (0, 4);
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
			return new Box(terrain,0,boxColor,x,y);
		}
		for (int i = 0; i<4; i++){
			values[i] = values[i] * 10;
		}
		values [2] =  values [2]/2;
		int sum = values[0] + values[1]+values[2] + values[3];
		int rand = Random.Range (1,sum +1);
		if (rand <= values[0])
			return new Box("eau",0,new Color(0,1,1),x,y);
		
		if (rand <= (values [0] + values [1]))
			return new Box("montagne",0,new Color(0.5f, 0.5f, 0.5f),x,y);
		if (rand <= (values [0] + values [1] + values [2]))
			return new Box("feu",0,new Color(1,0,0),x,y);
		else
			return new Box("plaine",0,new Color(0,1,0),x,y);
		
		
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
		BoxObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Test");
		BoxObject.GetComponent<SpriteRenderer> ().color = boxColor;
	}

	public int getNumber (){
		switch (terrain) {
			case("eau"):
				return 0;
				break;
			case("montagne"):
				return 1;
				break;
			case("feu"):
				return 2;
				break;

			case("plaine"):
				return 3;
				break;
		
			default:
				return -1;
				break;
		}

	}

}
	
