using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {

	public GameObject tile;
	private GameBoard board;

	// Use this for initialization
	void Start () {
		this.board = new GameBoard(Options.boardWidth, Options.boardHeight);
		for(int row=0; row<this.board.height; row++) {
			for(int col=0; col < this.board.width; col++) {
				GameObject newTile = Instantiate(tile, new Vector3(col * Options.tileSize, row * Options.tileSize, 0), Quaternion.identity) as GameObject;
				newTile.transform.parent = transform;
			}
		}
		
		GameObject piecePrefab = Resources.Load("Piece") as GameObject;
		
		Player p1 = new Player(1, false);
		foreach(Piece p in p1.pieces) {
			GameObject piece = Instantiate(piecePrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			piece.transform.parent = transform;
			piece.GetComponent<PieceController>().model = p;
		}
		Player p2 = new Player(2, true);
		foreach(Piece p in p2.pieces) {
			GameObject piece = Instantiate(piecePrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			piece.transform.parent = transform;
			piece.GetComponent<PieceController>().model = p;
		}
		
		transform.position = new Vector3(-Options.tileSize * 3, -Options.tileSize * 4, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
