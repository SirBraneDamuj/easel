using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

  public bool isHighlighted = false;
  public PieceController myPiece;
  public BoardController board;
  public Position gridPosition;
  private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
    this.sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
    if(myPiece != null && myPiece.isSelected) {
      sprite.color = new Color(1F, 0.5f, 0.5f, 1F);
    } else {
      sprite.color = isHighlighted ? Color.yellow : Color.white;
    }
	}
  
  void OnMouseDown() {
    this.board.tileClicked(this);
  }
}
