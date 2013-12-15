using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Model {

	public class Action {
		public Piece piece { get; private set; }
		public Position newPos { get; private set; }

		public Action(Piece piece, Position newPos ) {
			this.piece = piece;
			this.newPos = newPos;
		}
	}

	public class State {
		public bool isP1Turn { get; set; }
		public bool isTerminal { get; private set; }
		public int winStatus { get; private set; } //1 for player 1 win, -1 for player 2 win, 0 for draw. Means nothing if isTerminal == false
		public List<Piece> player1 { get; private set; }
		public List<Piece> player2 { get; private set; }
		public Piece[,] board { get; private set; }

		private Piece copyPiece(Piece p) {
			if (p is WholePiece) {
//				Debug.Log("Copying whole piece at ("+p.position.x+","+p.position.y+")");
				return PieceFactory.createWholePiece (p);
			} else if (p is CompoundPiece) {
//				Debug.Log("Copying compound piece at ("+p.position.x+","+p.position.y+")");
				return PieceFactory.createCompoundPiece(p.color, p);
			} else if (p is BasicPiece) {
//				Debug.Log("Copying basic piece at ("+p.position.x+","+p.position.y+")");
				return PieceFactory.createBasicPiece(p);
			} else {
				Debug.Log("Model.State.copyPiece shouldn't have gotten here");
				return null;
			}
		}

		private void initPlayer(List<Piece> player, List<Piece> copyFrom, Action a) {
			foreach(Piece p in copyFrom) {
				if(!p.position.Equals(a.newPos)) {
					Piece newP = copyPiece(p);
					if(p.Equals(a.piece)) {
						newP.move(a.newPos);
					}
					placePiece(newP);
					player.Add(newP);
				}
			}
		}

		private void initBoard() {
			this.board = new Piece[Options.boardHeight,Options.boardWidth];
		}

		private void placePiece(Piece p) {
			board [p.position.y,p.position.x] = p;
		}

		public State(State s, Action a) {
			initBoard();
			this.isP1Turn = !s.isP1Turn;
			this.player1 = new List<Piece>();
			this.player2 = new List<Piece>();
			initPlayer(this.player1, s.player1, a);
			initPlayer(this.player2, s.player2, a);
			setStatus();
		}

		public State(Player p1, Player p2, bool turn ) {
			initBoard();
			this.isP1Turn = turn;
			this.player1 = new List<Piece>();
			this.player2 = new List<Piece>();
			foreach(Piece p in p1.pieces) {
				Piece newP = copyPiece(p);
				player1.Add(newP);
				placePiece(newP);
			}
			foreach(Piece p in p2.pieces) {
				Piece newP = copyPiece(p);
				player2.Add(newP);
				placePiece(newP);
			}
			setStatus();
		}

		private void setStatus() {
			int P1points = 0;
			int P2points = 0;
			bool P1done = true;
			bool P2done = true;
			foreach(Piece p in player1) {
				if(p.color == "black") {
					P1points++;
				} else {
					P1done = false;
				}
			}
			foreach(Piece p in player2) {
				if(p.color == "black") {
					P2points++;
				} else {
					P2done = false;
				}
			}
			this.isTerminal = P1done || P2done || this.getLegalMoves().Count == 0;

			if(isTerminal) {
				if(P1points > P2points) {
					this.winStatus = 1;
				} else if (P2points > P1points) {
					this.winStatus = -1;
				} else {
					this.winStatus = 0;
				}
			} else {
				this.winStatus = 0;
			}
		}

		public List<Action> getLegalMoves() {
			if (this.isTerminal) {
				return null;
			}
			List<Piece> activePlayer;
			List<Piece> waitingPlayer;
			if(this.isP1Turn) {
				activePlayer = player1;
				waitingPlayer = player2;
			} else
			{
				activePlayer = player2;
				waitingPlayer = player1;
			}

			List<Action> result = new List<Action> ();
			foreach(Piece p in activePlayer) {
				foreach(Position pos in p.getAvailableSpaces(null)) {
					if(pos.x >= 0 && pos.x < Options.boardWidth &&
					   pos.y >= 0 && pos.y < Options.boardHeight) {
						if(board[pos.y,pos.x] == null) {
							result.Add(new Action(p, pos));
						} else if(p.canCombineWith(board[pos.y,pos.x])) {
//							Debug.Log("AI: Model.State.getLegalMoves found capture: "+
//							          "("+p.position.x+","+p.position.y+") to "+
//							          "("+pos.x+","+pos.y+").");
							result.Add(new Action(p, pos));
						}
					}
				}
			}
			return result;
		}
	}

}
