using UnityEngine;
using System.Collections;

public class PieceController : MonoBehaviour {

  public BoardController board;

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
	}
	
	void updateSprite() {
		string suffix = model.playerNum == 1 ? "_x" : "_y";
		Sprite sprite = Resources.Load<Sprite>(model.color + suffix);
		GetComponent<SpriteRenderer>().sprite = sprite;
	}

  void OnMouseDown() {
    Debug.Log(model.color);
    board.getTile(model.position).GetComponent<SpriteRenderer>().color = Color.yellow;
  }
}
