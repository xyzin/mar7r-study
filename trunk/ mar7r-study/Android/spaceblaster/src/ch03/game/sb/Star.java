package ch03.game.sb;

import java.util.Random;

import android.graphics.Paint;

public class Star extends ArcadeGameObject {
	private Paint paint;
	private int size;
	private int resizeTick;
	private boolean bSmaller;
	private boolean bLarger;
	private int changingTick;
	private int resizeInterval;

	public Star(int positionX, int positionY) {
		super(positionX, positionY);
		paint = getRandomColor();
		size = 2;
		resizeTick = (int)(Math.random() * 100);
		resizeInterval = (int)(Math.random() * 100) + 100;
		bSmaller = false;
		bLarger = false;
		changingTick = 0;
	}
	
	public void init(int positionX, int positionY) {
		position_x = positionX;
		position_y = positionY;
		paint = getRandomColor();
	}
	
	public Paint getPaint() {
		return paint;
	}
	
	private Paint getRandomColor(){
		Random random = new Random();
		int r 	= random.nextInt(255);
		int g	= random.nextInt(255);
		int b	= random.nextInt(255);
		
		Paint p = new Paint();
		p.setARGB(255, r, g, b);
		return p;
	}

	public int getSize() {
		if (bSmaller)
		{
			changingTick++;
			if (changingTick > 10)
			{
				changingTick = 0;
				size--;
				bSmaller = false;
			}
		} else if (bLarger) {
			changingTick++;
			if (changingTick > 10)
			{
				changingTick = 0;
				size++;
				bLarger = false;
			}			
		} else {
			resizeTick++;
			if (resizeTick > resizeInterval)
			{
				resizeTick = 0;
				changeSize();
			}
		}
		return size;
	}
	
	private void changeSize() {
		switch(size) {
		case 3:
			bSmaller = true;
			size = 2;
			break;
		case 1:
			bLarger = true;
			size = 2;
			break;
		case 2:
			size = 1;
			break;
		}
	}

}
