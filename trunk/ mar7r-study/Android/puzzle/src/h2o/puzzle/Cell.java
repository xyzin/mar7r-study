package h2o.puzzle;

import android.graphics.Bitmap;
import android.graphics.Rect;

public class Cell {
	private Bitmap image;
	private Rect rect;
	private int position;

	public Cell(Bitmap resBitmap, int i) {
		image = resBitmap;
		position = i;
		rect = new Rect();
		rect.set(0, 0, image.getWidth() - 1, image.getHeight() - 1);
	}

	public int getWidth() {
		return image.getWidth();
	}

	public int getHeight() {
		return image.getHeight();
	}

	public Bitmap getImage() {
		return image;
	}

	public void setPosition(int position) {
		this.position = position;
	}

	public int getPosition() {
		return position;
	}
	
	public Rect getRect() {
		return rect;
	}
}
