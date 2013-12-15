using System.Collections.Generic;
using System;

//Smart as a Brick...
public class BrickStrategy : Strategy
{
	static Random rnd = new Random();

	public override Model.Action getAction(Model.State state) {
		List<Model.Action> actions = state.getLegalMoves ();
		return actions[rnd.Next(actions.Count)];
	}
}


