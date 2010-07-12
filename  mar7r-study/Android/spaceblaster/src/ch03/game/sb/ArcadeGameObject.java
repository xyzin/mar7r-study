package ch03.game.sb;

public abstract class ArcadeGameObject {
	int position_x;
	int position_y;

	public ArcadeGameObject(int positionX, int positionY) {
		position_x = positionX;
		position_y = positionY;
	}

	public int getX() {
		return position_x;
	}
	
	public int getY() {
		return position_y;
	}
	
	public void move(int dx, int dy) {
		position_x += dx;
		position_y += dy;
	}
}
