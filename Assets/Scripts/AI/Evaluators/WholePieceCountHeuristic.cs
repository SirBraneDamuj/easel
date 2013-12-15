using System;

public class WholePieceCountHeuristic : StateEvaluator
{
	public override double evaluate(Model.State state) {
		int P1 = 0;
		int P2 = 0;
		foreach(Piece p in state.player1) {
			if(p.color == "black") {
				P1++;
			}
		}
		foreach(Piece p in state.player2) {
			if(p.color == "black") {
				P2++;
			}
		}
		return normalize(P1 - P2);
	}
}


