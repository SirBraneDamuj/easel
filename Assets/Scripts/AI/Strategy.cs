using UnityEngine;
using System.Collections;

public abstract class Strategy {

	public abstract Model.Action getAction(Model.State state);
}
