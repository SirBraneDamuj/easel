using System;
using System.Collections.Generic;

public class WeightedEnsembleHeuristic : StateEvaluator
{
	Dictionary<StateEvaluator, double> evals;

	public WeightedEnsembleHeuristic(Dictionary<StateEvaluator, double> evals) {
		this.evals = evals;
	}

	public override double evaluate(Model.State state) {
		double total = 0.0;
		if(state.isTerminal) {
			return (double)state.winStatus;
		}
		foreach(KeyValuePair<StateEvaluator, double> kvp in evals) {
			total += kvp.Value * kvp.Key.evaluate(state);
		}
		return normalize(total);
	}
}


