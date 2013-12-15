using UnityEngine;
using System.Collections;

public class Position {
	public int x;
	public int y;
	
	public Position(int x, int y) {
		this.x = x;
		this.y = y;
	}
  
  public Position move(int x, int y) {
    return new Position(this.x + x, this.y + y);
  }

  public bool Equals(Position p) {
	return p.x == this.x && p.y == this.y;
  }
}
