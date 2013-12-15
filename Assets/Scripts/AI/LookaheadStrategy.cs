using System.Collections.Generic;
using System;
using UnityEngine;

//Does a 2-ply minimax search, evaluates leaves with WeightedEnsembleHeuristic.
public class LookaheadStrategy : Strategy
{
	private StateEvaluator eval;
	private int depth;
	public LookaheadStrategy(int depth) {
		this.depth = depth;
		Dictionary<StateEvaluator, double> evals = new Dictionary<StateEvaluator, double> ();
		evals.Add (new WholePieceCountHeuristic (), 2.0);
		evals.Add (new PieceCountHeuristic (), 1.0);
		evals.Add (new MobilityHeuristic (), 0.1);
		eval = new WeightedEnsembleHeuristic (evals);
	}
	public override Model.Action getAction(Model.State state) {
		SearchPair pair = search (state, depth, state.isP1Turn);
		if(pair.act == null) {
			Debug.Log("AI: Lookahead strategy found null move. Was it called on a terminal state?");
			return null;
		}
		return pair.act;
	}

	private class SearchPair {
		public Model.Action act { get; set; }
		public double eval { get; set; }

		public SearchPair(Model.Action act, double eval) {
			this.act = act;
			this.eval = eval;
		}
	}


	private SearchPair search(Model.State state, int depth, bool max) {
		List<Model.Action> legalActs = state.getLegalMoves ();
		if(legalActs == null || legalActs.Count == 0) {
			if(!state.isTerminal) {
				Debug.Log("Problem with Model.State: No legal moves but game not over!");
			} else {
				return new SearchPair(null, (double)state.winStatus);
			}
		}
		SearchPair bestPair = null;
		SearchPair thisPair = null;
		double bestEval;
		if(max) {
			bestEval = -1.0;
		} else {
			bestEval = 1.0;
		}
		foreach(Model.Action act in legalActs) {
			if(depth <= 1){
				thisPair = new SearchPair(act, this.eval.evaluate(new Model.State(state, act)));	
			} else {
				thisPair = search(new Model.State(state,act), depth-1, !max);
			}
			if((max && thisPair.eval >= bestEval) || (!max && thisPair.eval <= bestEval)) {
				bestEval = thisPair.eval;
				bestPair = new SearchPair(act, bestEval);
			}
		}
		return bestPair;
	}
}


