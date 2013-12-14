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
		
		this.p1 = new Player(1, false);
		foreach(Piece p in p1.pieces) {
			createPiece(p);
		}
		this.p2 = new Player(2, true);
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
      if(this.selectedPiece == pc) {
        this.selectedPiece.deselect();
      }
      else if(this.selectedPiece.model.positionIsInRange(this, pc.model.position) && this.selectedPiece.model.canCombineWith(pc.model)) {
        combine(this.selectedPiece, pc);
        return;
      } else {
        this.selectedPiece.deselect();
      }
    } 
    this.selectedPiece = pc;
    pc.select();
  }
  
  public void combine(PieceController owner, PieceController loser) {
    owner.move(loser.model.position);
    Player owningPlayer = playerForNumber(owner.model.playerNum);
    Player losingPlayer = playerForNumber(loser.model.playerNum);
    Debug.Log(owningPlayer);
    owningPlayer.pieces.Remove(owner.model);
    losingPlayer.pieces.Remove(loser.model);
    Piece newPiece = PieceFactory.combine(owner.model, loser.model);
    PieceController piece = Instantiate(piecePrefab, Vector3.zero, Quaternion.identity) as PieceController;
    piece.transform.parent = transform;
    piece.model = newPiece;
    piece.board = this;
    getTile(piece.model.position).myPiece = piece;
    Destroy(owner.gameObject);
    Destroy(loser.gameObject);
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
  
  public Player playerForNumber(int num) {
    if(num == 1) { return p1; }
    else if(num == 2) { return p2; }
    else { Debug.Log("playerForNumber shouldn't have gotten here"); return null; }
  }
}
