using UnityEngine;
using System.Collections;

public class PieceFactory {
  
  public static Piece combine(Piece owner, Piece loser) {
    if(owner.color == "red") {
      if(loser.color == "green") {
        return createWholePiece(owner);
      } else {
        string color = "";
        if(loser.color == "blue") {
          color = "purple";
        } else if(loser.color == "yellow") {
          color = "orange";
        } else {
          Debug.Log("combining with the wrong color! SOMETHING'S NOT RIGHT HERE!");
        }
        return createCompoundPiece(color, owner);
      }
    }
    if(owner.color == "blue") {
      if(loser.color == "orange") {
        return createWholePiece(owner);
      } else {
        string color = "";
        if(loser.color == "red") {
          color = "purple";
        } else if(loser.color == "yellow") {
          color = "green";
        } else {
          Debug.Log("combining with the wrong color! SOMETHING'S NOT RIGHT HERE!");
        }
        return createCompoundPiece(color, owner);
      }
    }
    if(owner.color == "yellow") {
      if(loser.color == "purple") {
        return createWholePiece(owner);
      } else {
        string color = "";
        if(loser.color == "red") {
          color = "orange";
        } else if(loser.color == "blue") {
          color = "green";
        } else {
          Debug.Log("combining with the wrong color! SOMETHING'S NOT RIGHT HERE!");
        }
        return createCompoundPiece(color, owner);
      }
    }
    if(owner.color == "purple" && loser.color == "yellow") {
      return createWholePiece(owner);
    }
    if(owner.color == "orange" && loser.color == "blue") {
      return createWholePiece(owner);
    }
    if(owner.color == "green" && loser.color == "red") {
      return createWholePiece(owner);
    }
    Debug.Log("returning null from combinePiece...THIS IS BAD!!!");
    return null;
      
  }
  
  public static Piece createBasicPiece(Piece original) {
	return new BasicPiece (original.color, original.playerNum, original.position.x, original.position.y);
  }

  public static Piece createWholePiece(Piece original) {
    return new WholePiece("black", original.playerNum, original.position.x, original.position.y);
  }
  
  public static Piece createCompoundPiece(string color, Piece original) {
    return new CompoundPiece(color, original.playerNum, original.position.x, original.position.y);
  }
  
  
  
  
}
