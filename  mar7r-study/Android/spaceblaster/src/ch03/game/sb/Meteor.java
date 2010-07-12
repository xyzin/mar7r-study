package ch03.game.sb;

import android.graphics.Bitmap;

public class Meteor extends ArcadeGameObject {
	private State state;

	private static Bitmap objectImage;
	private static int imageSize_x;
	private static int imageSize_y;
	
	private static Bitmap[] boomImages;
	private static int boomImageSize_x;
	private static int boomImageSize_y;
	
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

	public Meteor(int positionX, int positionY) {
		super(positionX, positionY);
		state = State.NORMAL;
	}
	
	private enum State {
		BOOM1,
		BOOM2,
		BOOM3,
		BOOM4,
		DESTROYED,
		NORMAL;
	}

	public boolean isNormal() {
		return state == State.NORMAL;
	}

	public void distroy() {
		state = State.BOOM1;
	}

	public Bitmap getBoomImage() {
		if (!isNormal())
		{
			Bitmap boomImage = Meteor.boomImages[state.ordinal()];
			state = State.values()[state.ordinal() + 1];
			return boomImage;
		}
		return null;
	}

	public boolean isDestroyed() {
		if (state == State.DESTROYED)
			return true;
		return false;
	}

	public static void setBoomImage(Bitmap[] boomDrawables) {
		boomImages = boomDrawables;
	}
	
	public static void setBoomImageSize(int size_x, int size_y) {
		boomImageSize_x = size_x;
		boomImageSize_y = size_y;
	}
	
	public static int getBoomImageSize_x() {
		return boomImageSize_x;
	}
	
	public static int getBoomImageSize_y() {
		return boomImageSize_y;
	}	
}
