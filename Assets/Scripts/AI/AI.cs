using UnityEngine;
using System;

public class AI
{
	private Strategy strat;
	public AI (Strategy s)
	{
		this.strat = s;
	}

	private Model.State getState(BoardController board, bool player1Turn) {
		return new Model.State(board.p1, board.p2, player1Turn);
	}

	private PieceController getPiece(BoardController board, Model.Action act) {
		return board.getTile(act.piece.position).myPiece;
	}

	public void move(BoardController board, bool movePlayer1) {
		Model.State state = getState (board, movePlayer1);
		if(state.isTerminal) {
			Debug.Log("AI Not moving; game is over!");
			return;
		}
		Model.Action act = strat.getAction(state);
		PieceController mover = getPiece(board, act);
		PieceController captured = board.getTile(act.newPos).myPiece;
		if(captured != null) {
			Debug.Log("AI Moving player "+mover.model.playerNum+"'s "+ mover.model.color+" piece at (" + mover.model.position.x+","+mover.model.position.y+") "
			         +" to capture player "+captured.model.playerNum+"'s "+captured.model.color+" piece at ("+captured.model.position.x+","+captured.model.position.y+").");
			board.combine(mover, captured);
		} else {
			Debug.Log("AI Moving player "+mover.model.playerNum+"'s "+ mover.model.color+" piece at (" + mover.model.position.x+","+mover.model.position.y+") "
			         +" to ("+act.newPos.x+","+act.newPos.y+").");
			mover.move(act.newPos);
		}
	}
}

