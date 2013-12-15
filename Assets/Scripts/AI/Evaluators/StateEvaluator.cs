using System;

public abstract class StateEvaluator
{
	public abstract double evaluate(Model.State state);

	//Apply the logistic function to get a number between 0 and 1; stretch it to be between -1 and 1
	//Values close to 1 mean player 1 has a big advantage; values close to -1 mean player 2 has a big advantage.
	//Values close to 0 mean it looks even.
	public static double normalize(double x) {
		return 2.0 * (1.0 / (1.0 + Math.Exp (-x))) - 1.0;
	}
}


