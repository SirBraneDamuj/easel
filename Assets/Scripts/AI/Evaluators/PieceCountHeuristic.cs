using System;

public class PieceCountHeuristic : StateEvaluator
{
	public override double evaluate(Model.State state) {
		return normalize(state.player1.Count - state.player2.Count);
	}
}


