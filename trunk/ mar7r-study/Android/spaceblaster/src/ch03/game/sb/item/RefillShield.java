package ch03.game.sb.item;

import android.graphics.Bitmap;
import android.graphics.Point;

public class RefillShield extends Item {
	private static Bitmap image;
	
	public static void setImage(Bitmap bitmap) {
		image = bitmap;
	}
	
	public Bitmap getImage() {
		return RefillShield.image;
	}

	public RefillShield(int positionX, int positionY, int itemDuration) {
		super(positionX, positionY, itemDuration);
	}

	public RefillShield(Point itemPosition, int itemDurationInitValue) {
		this(itemPosition.x, itemPosition.y, itemDurationInitValue);
	}

	@Override
	public ItemEffect getAbility() {
		return ItemEffect.REFIL_SHIELD;
	}

}
