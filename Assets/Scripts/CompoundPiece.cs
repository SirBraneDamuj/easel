using UnityEngine;
using System.Collections.Generic;

public class CompoundPiece : Piece {

	public CompoundPiece(string color, int playerNum, int x, int y) : base(color, playerNum, x, y) {}

  //cardinal
	public override List<Position> getAvailableSpaces(BoardController board) {
		List<Position> availableMoves = new List<Position>();
    availableMoves.Add(this.position.move(1,0));
    availableMoves.Add(this.position.move(-1,0));
    availableMoves.Add(this.position.move(0,1));
    availableMoves.Add(this.position.move(0,-1));
    return availableMoves;
	}
  
  public override bool canCombineWith(Piece other) {
    if(other.playerNum == this.playerNum) {
      return false;
    } else {
      if(this.color == "green") {
        return other.color == "red";
      }
      else if(this.color == "purple") {
        return other.color == "yellow";
      }
      else if(this.color == "orange") {
        return other.color == "blue";
      }
    }
    Debug.Log("BasicPiece.canCombineWith shouldn't have gotten here");
    return false;
  }

}
