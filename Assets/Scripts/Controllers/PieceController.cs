using UnityEngine;
using System.Collections.Generic;

public class PieceController : MonoBehaviour {

  public BoardController board;
  public bool isSelected = false;

	public Piece model;
	private string oldColor = "";
	private Position oldPosition = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(model != null) {
			if(model.position != oldPosition) {
				transform.localPosition = new Vector3(model.position.x * Options.tileSize, model.position.y * Options.tileSize, -1);
				oldPosition = model.position;
			}
			
			if(model.color != oldColor) {
				updateSprite();
				oldColor = model.color;
			}
		}
    if(board.getTile(model.position).myPiece != this) {
      board.getTile(model.position).myPiece = this;
    }
	}
	
	void updateSprite() {
		string suffix = model.playerNum == 1 ? "_x" : "_y";
		Sprite sprite = Resources.Load<Sprite>(model.color + suffix);
		GetComponent<SpriteRenderer>().sprite = sprite;
	}

  void OnMouseDown() {
    if(!this.isSelected) {
      board.selectPiece(this);
    } else {
      board.deselectPiece();
    }
  }
  
  public void select() {
    this.isSelected = true;
    setHighlightedSpaces(true);
  }
  
  public void deselect() {
    this.isSelected = false;
    setHighlightedSpaces(false);
  }
  
  public void move(Position pos) {
    this.deselect();
    this.board.getTile(model.position).myPiece = null;
    this.model.move(pos);
    this.board.getTile(pos).myPiece = this;
    this.board.deselectPiece();
  }
  
  private void setHighlightedSpaces(bool highlighted) {
    foreach(Position p in model.getAvailableSpaces(board)) {
      if(p.x < board.width && p.x >= 0) {
        if(p.y < board.height && p.y >= 0) {
          TileController tc = board.getTile(p);
          if(tc.myPiece == null || this.model.canCombineWith(tc.myPiece.model)) {
            board.getTile(p).isHighlighted = highlighted;
          }
        }
      }
    }
  }
}
