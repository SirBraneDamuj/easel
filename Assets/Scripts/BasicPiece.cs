using UnityEngine;
using System.Collections.Generic;

public class BasicPiece : Piece {

	public BasicPiece(string color, int playerNum, int x, int y) : base(color, playerNum, x, y) {}

  //diagonal
	public override List<Position> getAvailableSpaces(BoardController board) {
		List<Position> availableMoves = new List<Position>();
    availableMoves.Add(this.position.move(1,1));
    availableMoves.Add(this.position.move(1,-1));
    availableMoves.Add(this.position.move(-1,-1));
    availableMoves.Add(this.position.move(-1,1));
    return availableMoves;
	}
  
  public override bool canCombineWith(Piece other) {
    if(other.playerNum == this.playerNum) {
      return false;
    } else {
      if(this.color == "blue") {
        return other.color == "red" || other.color == "yellow" || other.color == "orange";
      }
      else if(this.color == "red") {
        return other.color == "blue" || other.color == "yellow" || other.color == "green";
      }
      else if(this.color == "yellow") {
        return other.color == "red" || other.color == "blue" || other.color == "purple";
      }
    }
    Debug.Log("BasicPiece.canCombineWith shouldn't have gotten here");
    return false;
  }
	
}
