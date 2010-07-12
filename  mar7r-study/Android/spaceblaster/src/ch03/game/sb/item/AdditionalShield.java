package ch03.game.sb.item;

import android.graphics.Bitmap;
import android.graphics.Point;

public class AdditionalShield extends Item {
	private static Bitmap image;
	
	public static void setImage(Bitmap bitmap) {
		image = bitmap;
	}
	
	public Bitmap getImage() {
		return AdditionalShield.image;
	}

	public AdditionalShield(int positionX, int positionY, int itemDuration) {
		super(positionX, positionY, itemDuration);
	}

	public AdditionalShield(Point itemPosition, int itemDurationInitValue) {
		this(itemPosition.x, itemPosition.y, itemDurationInitValue);
	}

	@Override
	public ItemEffect getAbility() {
		return ItemEffect.ADDITIONAL_SHIELD;
	}

}
