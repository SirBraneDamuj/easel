using System;

public class MobilityHeuristic : StateEvaluator
{
	public override double evaluate(Model.State state) {
		bool oldMove = state.isP1Turn;
		state.isP1Turn = true;
		int P1Mobility = state.getLegalMoves().Count;
		state.isP1Turn = false;
		int P2Mobility = state.getLegalMoves().Count;
		state.isP1Turn = oldMove;
		return normalize(P1Mobility - P2Mobility);
	}
}


