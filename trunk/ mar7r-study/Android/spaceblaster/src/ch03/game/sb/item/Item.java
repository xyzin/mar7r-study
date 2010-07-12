package ch03.game.sb.item;

import ch03.game.sb.ArcadeGameObject;
import android.graphics.Bitmap;

public abstract class Item extends ArcadeGameObject {
	private static int itemSize_x;
	private static int itemSize_y;
	private static int duration;
	
	public static void setItemSize(int x, int y) {
		itemSize_x = x;
		itemSize_y = y;
	}
	
	public static int getItemSize_x() {
		return itemSize_x;
	}
	
	public static int getItemSize_y() {
		return itemSize_y;
	}
	
	public Item(int positionX, int positionY, int duration) {
		super(positionX, positionY);
		Item.duration = duration;
	}

	public abstract Bitmap getImage();
	public int getDuration() {
		return Item.duration;
	}

	public abstract ItemEffect getAbility();
}
