package ch03.game.sb.item;

public enum ItemEffect {
	UNLIMIT_SHIELD(0),
	ADDITIONAL_SHIELD(1),
	REFIL_SHIELD(2),
	UNLIMIT_LASER(3),
	REFIL_LASER(4),
	NONE(99);
	
	
	private int index;

	private ItemEffect(int index) {
		this.index = index;
	}

	@Override
	public String toString() {
		String s = null;
		switch(index) {
		case 0:
			s = "Got Unlimit Shield!";
			break;
		case 1:
			s = "Got Additional Shield!";
			break;
		case 2:
			s = "Refilled Shield!";
			break;
		case 3:
			s = "Got Unlimit Laser!";
			break;
		case 4:
			s = "Refilled Laser!";
			break;
		}
		return s;
	}
}
