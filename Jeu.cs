using UnityEngine;
using System.Collections;

public class Jeu : MonoBehaviour {
	Map current_map;
	// Use this for initialization
	void Start () {
		current_map = generate_Map (10, 10);
		current_map.randomize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Map generate_Map(int x, int y){
		Map one = new Map (x, y);
		return one;
	}
}
