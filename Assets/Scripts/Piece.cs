using System.Collections.Generic;

public abstract class Piece {
	public string color { get; private set; }
	public Position position { get; private set; }
	public int playerNum { get; private set; }
  public List<string> permittedColors;
	
	public Piece(string color, int playerNum, int x, int y) {
		this.color = color;
		this.playerNum = playerNum;
		this.position = new Position(x, y);
	}
	
	public abstract List<Position> getAvailableSpaces(BoardController board);
	public abstract bool canCombineWith(Piece other);
  
  public void move(Position pos) {
    this.position = pos;
  }
  
  public bool positionIsInRange(BoardController board, Position newPos) {
    foreach(Position availPos in getAvailableSpaces(board)) {
      if(availPos.x == newPos.x && availPos.y == newPos.y) {
        return true;
      }
    }
    return false;
  }
}
