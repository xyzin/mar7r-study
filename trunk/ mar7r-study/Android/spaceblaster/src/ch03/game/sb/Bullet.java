package ch03.game.sb;

import android.graphics.Bitmap;

public class Bullet extends ArcadeGameObject {
	private static Bitmap objectImage;
	private static int imageSize_x;
	private static int imageSize_y;
	
	public static int getImageSize_x() {
		return imageSize_x;
	}

	public static void setImageSize(int imageSizeX, int imageSizeY) {
		imageSize_x = imageSizeX;
		imageSize_y = imageSizeY;
	}

	public static int getImageSize_y() {
		return imageSize_y;
	}

	public static void setBitmap(Bitmap image) {
		objectImage = image;
	}
	
	public static Bitmap getBitmap() {
		return objectImage;
	}	

	public Bullet(int positionX, int positionY) {
		super(positionX, positionY);
	}

}
