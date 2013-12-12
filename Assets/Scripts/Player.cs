using System.Collections.Generic;

public class Player {

	public List<Piece> pieces { get; private set; }
	public int playerNumber { get; private set; }
	
	public Player(int playerNumber, bool inverted) {
		this.playerNumber = playerNumber;
		this.pieces = new List<Piece>();
		Position topLeft = new Position(0, 2);
		int xDelt = 2;
		if(inverted) {
			topLeft = new Position(Options.boardWidth-2, Options.boardHeight-1);
			xDelt *= -1;
		}
		createCluster(topLeft, "red");
		topLeft.x += xDelt;
		createCluster(topLeft, "blue");
		topLeft.x += xDelt;
		createCluster(topLeft, "yellow");
	}
	
	private void createCluster(Position topLeft, string color) {
		for(int yDelt=0; yDelt>=-2; yDelt--) {
			pieces.Add(new BasicPiece(color, playerNumber, topLeft.x, topLeft.y+yDelt));
			pieces.Add(new BasicPiece(color, playerNumber, topLeft.x+1, topLeft.y+yDelt));
		}
	}
	
}
