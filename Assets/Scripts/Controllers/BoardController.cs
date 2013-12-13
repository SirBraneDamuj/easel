using UnityEngine;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public TileController tilePrefab;
  public PieceController piecePrefab;
  public List<List<TileController>> rows;
  public Player p1;
  public Player p2;
  public int width;
  public int height;
  public PieceController selectedPiece;

	// Use this for initialization
	void Start () {
    this.width = Options.boardWidth;
    this.height = Options.boardHeight;
    this.rows = new List<List<TileController>>();
		for(int row=0; row<this.height; row++) {
      List<TileController> rowList = new List<TileController>();
			for(int col=0; col < this.width; col++) {
				TileController newTile = Instantiate(tilePrefab, Vector3.zero, Quaternion.identity) as TileController;
				newTile.transform.parent = transform;
        newTile.transform.position = new Vector3(col * Options.tileSize, row * Options.tileSize, 0);
        newTile.board = this;
        newTile.gridPosition = new Position(col, row);
        rowList.Add(newTile);
			}
      this.rows.Add(rowList);
		}
		
		Player p1 = new Player(1, false);
		foreach(Piece p in p1.pieces) {
			createPiece(p);
		}
		Player p2 = new Player(2, true);
		foreach(Piece p in p2.pieces) {
			createPiece(p);
		}
    
    
		transform.position = new Vector3(-Options.tileSize * 3, -Options.tileSize * 4, 0);
	}
  
  private void createPiece(Piece model) {
    PieceController piece = Instantiate(piecePrefab, Vector3.zero, Quaternion.identity) as PieceController;
    piece.transform.parent = transform;
    piece.model = model;
    piece.board = this;
  }
	
	// Update is called once per frame
	void Update () {
		
	}

  public TileController getTile(Position position) {
    return this.rows[position.y][position.x];
  }
  
  public void selectPiece(PieceController pc) {
    if(this.selectedPiece != null) {
      this.selectedPiece.deselect();
    } else if(this.selectedPiece.model.positionIsInRange(pc.model.position)) {
      //combine the pieces
    }
    this.selectedPiece = pc;
    pc.select();
  }
  
  public void deselectPiece() {
    if(this.selectedPiece != null) {
      this.selectedPiece.deselect();
      this.selectedPiece = null;
    }
  }
  
  public void tileClicked(TileController tc) {
    if(this.selectedPiece != null) {
      foreach(Position pos in this.selectedPiece.model.getAvailableSpaces(this)) {
        if(tc.gridPosition.x == pos.x && tc.gridPosition.y == pos.y) {
          this.selectedPiece.move(pos);
          return;
        }
      }
    }
  }
}
