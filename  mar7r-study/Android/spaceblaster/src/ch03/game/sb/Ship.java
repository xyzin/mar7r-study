package ch03.game.sb;

import android.graphics.Bitmap;
import android.graphics.Point;

public class Ship extends ArcadeGameObject {
	private static Bitmap[] engineFireImages;
	private static int engineFireImagesSize_x;
	private static int engineFireImagesSize_y;
	private static int toggle = 0;
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
	
	public static void setEngineFireImages(Bitmap[] images) {
		Ship.engineFireImages = images;
	}

	public Ship(int positionX, int positionY) {
		super(positionX, positionY);
	}

	public Ship(Point defaultShipPosition) {
		this(defaultShipPosition.x, defaultShipPosition.y);
	}

	public void moveTo(int positionX, int positionY) {
		this.position_x = positionX;
		this.position_y = positionY;
	}
	
	public void moveTo(Point destination) {
		moveTo(destination.x, destination.y);
	}

	public static Bitmap getEngineFireImage() {
		toggle = toggle > 1 ? 0 : toggle;
		return engineFireImages[toggle++];
	}
	
	public static void setEngineFireImageSize(int x, int y) {
		engineFireImagesSize_x = x;
		engineFireImagesSize_y = y;
	}

	public static int getEngineFireImageSize_x() {
		return engineFireImagesSize_x;
	}
	
	public static int getEngineFireImageSize_y() {
		return engineFireImagesSize_y;
	}

}
