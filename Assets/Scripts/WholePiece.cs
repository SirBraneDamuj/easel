using UnityEngine;
using System.Collections.Generic;

public class WholePiece : Piece {

	public WholePiece(string color, int playerNum, int x, int y) : base(color, playerNum, x, y) {}

  //all
	public override List<Position> getAvailableSpaces(BoardController board) {
		List<Position> availableMoves = new List<Position>();
    availableMoves.Add(this.position.move(1,0));
    availableMoves.Add(this.position.move(-1,0));
    availableMoves.Add(this.position.move(0,1));
    availableMoves.Add(this.position.move(0,-1));
    availableMoves.Add(this.position.move(1,1));
    availableMoves.Add(this.position.move(1,-1));
    availableMoves.Add(this.position.move(-1,-1));
    availableMoves.Add(this.position.move(-1,1));
    return availableMoves;
	}
  
  public override bool canCombineWith(Piece other) {
    return false;
  }

}
