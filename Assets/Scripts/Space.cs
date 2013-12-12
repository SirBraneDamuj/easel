public class Space {
	public Position position { get; private set; }
	
	public Space(int x, int y) {
		position = new Position(x, y);
	}
}
