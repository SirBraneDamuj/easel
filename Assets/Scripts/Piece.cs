using System.Collections.Generic;

public abstract class Piece {
	public string color { get; private set; }
	public Position position { get; private set; }
	public int playerNum { get; private set; }
	
	public Piece(string color, int playerNum, int x, int y) {
		this.color = color;
		this.playerNum = playerNum;
		this.position = new Position(x, y);
	}
	
	public abstract List<Position> getAvailableSpaces(GameBoard board, Space space);
	public bool canCombineWith(Piece other) {
		return true;
	}
}
