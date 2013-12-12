using System.Collections.Generic;

public class BasicPiece : Piece {

	public BasicPiece(string color, int playerNum, int x, int y) : base(color, playerNum, x, y) { }

	public override List<Position> getAvailableSpaces(GameBoard board, Space space) {
		return null;
	}
	
}
