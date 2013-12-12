using UnityEngine;
using System.Collections.Generic;

public class GameBoard {	
	public int width { get; private set; }
	public int height { get; private set; }
	
	public GameBoard(int width, int height) {
		this.width = width;
		this.height = height;
	}	
}
