package h2o.puzzle;

import java.util.Random;

import android.content.Context;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.Rect;
import android.graphics.Bitmap.Config;
import android.graphics.BitmapFactory.Options;
import android.graphics.drawable.Drawable;
import android.util.AttributeSet;
import android.view.View;

public class GameView extends View {

	private static final int MARGIN = 10;
	private static final int MATRIX_SIZE = 16;
	private Cell[] cells = new Cell[MATRIX_SIZE-1];
	private Rect[] mDstRect = new Rect[MATRIX_SIZE];
	private Rect mBackGroundRect;
	private Bitmap mBackGroundImage;
	private Paint mBmpPaint;
	private int mCountInRow;
	private int mEmptyCell;
	private int mCountMoveUp;
	private int mCountMoveDown;
	private int mCountMoveLeft;
	private int mCountMoveRight;

	public GameView(Context context, AttributeSet attrs) {
		super(context, attrs);
		requestFocus();

		mBmpPaint = new Paint(Paint.ANTI_ALIAS_FLAG);
		mCountInRow = 4;
		mEmptyCell = MATRIX_SIZE - 1;
		
		initStat();
		initRect();
		initCells();
		mBackGroundImage = getResBitmap(R.drawable.gridwin);
	}

	private void initStat() {
		mCountMoveDown = 0;
		mCountMoveLeft = 0;
		mCountMoveRight = 0;
		mCountMoveUp =0;
	}

	private void initRect() {
		for (int i=0; i<mDstRect.length; i++)
		{
			mDstRect[i] = new Rect();
		}
		
		mBackGroundRect = new Rect();
	}
	
	
	private void initCells() {
		cells[0] = new Cell(getResBitmap(R.drawable.num01), 0);
		cells[1] = new Cell(getResBitmap(R.drawable.num02), 1);
		cells[2] = new Cell(getResBitmap(R.drawable.num03), 2);
		cells[3] = new Cell(getResBitmap(R.drawable.num04), 3);
		cells[4] = new Cell(getResBitmap(R.drawable.num05), 4);
		cells[5] = new Cell(getResBitmap(R.drawable.num06), 5);
		cells[6] = new Cell(getResBitmap(R.drawable.num07), 6);
		cells[7] = new Cell(getResBitmap(R.drawable.num08), 7);
		cells[8] = new Cell(getResBitmap(R.drawable.num09), 8);
		cells[9] = new Cell(getResBitmap(R.drawable.num10), 9);
		cells[10] = new Cell(getResBitmap(R.drawable.num11), 10);
		cells[11] = new Cell(getResBitmap(R.drawable.num12), 11);
		cells[12] = new Cell(getResBitmap(R.drawable.num13), 12);
		cells[13] = new Cell(getResBitmap(R.drawable.num14), 13);
		cells[14] = new Cell(getResBitmap(R.drawable.num15), 14);
	}
	
	private Bitmap getResBitmap(int bmpResId) {
        Options opts = new Options();
        opts.inDither = false;

        Resources res = getResources();
        Bitmap bmp = BitmapFactory.decodeResource(res, bmpResId, opts);

        if (bmp == null && isInEditMode()) {
            // BitmapFactory.decodeResource doesn't work from the rendering
            // library in Eclipse's Graphical Layout Editor. Use this workaround instead.

            Drawable d = res.getDrawable(bmpResId);
            int w = d.getIntrinsicWidth();
            int h = d.getIntrinsicHeight();
            bmp = Bitmap.createBitmap(w, h, Config.ARGB_8888);
            Canvas c = new Canvas(bmp);
            d.setBounds(0, 0, w - 1, h - 1);
            d.draw(c);
        }
        return bmp;
    }	

	@Override
	protected void onSizeChanged(int width, int height, int oldw, int oldh) {
		super.onSizeChanged(width, height, oldw, oldh);
		int smallSide = ( width>height )? height : width ;
		int dstRectSide = ( smallSide - (MARGIN * 2) ) / mCountInRow;
		
		for (int i=0; i<mDstRect.length; i++)
		{
			int rectLeft = i % mCountInRow;
			int rectTop = i / mCountInRow;
			int rectRight = rectLeft + 1;
			int rectBottom = rectTop + 1;;
			mDstRect[i].set((dstRectSide * rectLeft) + MARGIN, 
							(dstRectSide * rectTop) + MARGIN, 
							(dstRectSide * rectRight) + MARGIN, 
							(dstRectSide * rectBottom) + MARGIN
							);
		}
		mBackGroundRect.set(0, 0, 
				(dstRectSide * mCountInRow) + (MARGIN * 2), (dstRectSide * (MATRIX_SIZE / mCountInRow) + (MARGIN * 2)));
	}

	@Override
	protected void onDraw(Canvas canvas) {
		super.onDraw(canvas);
		
		drawBackgound(canvas);
		for (int i=0; i<cells.length; i++)
		{
			int position = cells[i].getPosition();
			canvas.drawBitmap(cells[i].getImage(), cells[i].getRect(), mDstRect[position], mBmpPaint);
		}
	}
	
    private void drawBackgound(Canvas canvas) {
		Rect backgound = new Rect();
		backgound.set(0, 0, mBackGroundImage.getWidth()-1, mBackGroundImage.getHeight()-1);
		canvas.drawBitmap(mBackGroundImage, backgound, mBackGroundRect, mBmpPaint);
	}

	private void moveCell(int position, Direction direction) {
		int cellIndex = getCellIndex(position);
		if (cellIndex == -1)
			return;
		switch(direction)
		{
		case UP:
			moveUp();
			break;
		case DOWN:
			moveDown();
			break;
		case LEFT:
			moveLeft();
			break;
		case RIGHT:
			moveRight();
			break;
		}
		int newEmptyCell = cells[cellIndex].getPosition();
		cells[cellIndex].setPosition(mEmptyCell);
		mEmptyCell = newEmptyCell;
		
		invalidate();
	}
	
	private void moveUp() {
		mCountMoveUp++;
	}
	
	private void moveDown() {
		mCountMoveDown++;
	}
	
	private void moveLeft() {
		mCountMoveLeft++;
	}
	
	private void moveRight() {
		mCountMoveRight++;
	}

	private int getCellPosition(int x, int y) {
		for (int i=0; i<mDstRect.length; i++)
		{
			if (mDstRect[i].contains(x, y))
				return i;
		}
		return -1;
	}
	
	private Direction getEmptyCellDirection(int cell) {
		if (cell == mEmptyCell)
			return Direction.CENTER;
		
		int leftCell = getLeftCell(cell);
		int rightCell = getRightCell(cell);
		int upCell = getUpCell(cell);
		int downCell = getDownCell(cell);
		
		if (leftCell == mEmptyCell)
			return Direction.LEFT;
		else if (rightCell == mEmptyCell)
			return Direction.RIGHT;
		else if (upCell == mEmptyCell)
			return Direction.UP;
		else if (downCell == mEmptyCell)
			return Direction.DOWN;
		return Direction.CENTER;
	}
	
	private int getLeftCell(int cell) {
		return ((cell % mCountInRow) != 0) ? (cell - 1) : -1;
	}
	
	private int getRightCell(int cell) {
		return (((cell + 1) % mCountInRow) != 0) ? cell + 1 : -1;
	}
	
	private int getUpCell(int cell) {
		return ((((cell + 1) / mCountInRow) != 0) && 
				(cell + 1 != mCountInRow)) ?
				cell - mCountInRow : -1;
	}
	
	private int getDownCell(int cell) {
		return ((cell + mCountInRow) <= MATRIX_SIZE) ?
				cell + mCountInRow : -1;
	}
	
	private int getCellIndex(int position) {
		int result = -1;
		for (int i=0; i<cells.length; i++)
		{
			if (cells[i].getPosition() == position)
			{
				result = i;
				break;
			}
		}
		return result;
	}	
	
	public boolean checkGameStatus() {
		for (int i=0; i<cells.length; i++)
		{
			if (cells[i].getPosition() != i)
			{
				// Not yet
				return false;
			}
		}
		return true;
	}
	
	public void shuffle() {
		Random random = new Random();
		for (int i=0; i<1000; i++)
		{
			int positin = random.nextInt(MATRIX_SIZE);
    		Direction emptyCellDirection = getEmptyCellDirection(positin);
			moveCell(positin, emptyCellDirection);
		}
		initStat();
	}

	public boolean TouchCell(int x, int y) {
		int cellPosition = getCellPosition(x, y);
		if (cellPosition == -1)
			return false;
		
		Direction emptyCellDirection = getEmptyCellDirection(cellPosition);
		moveCell(cellPosition, emptyCellDirection);
		return true;
	}

	public String getLeftCount() {
		return Integer.toString(mCountMoveLeft);
	}
	
	public String getRightCount() {
		return Integer.toString(mCountMoveRight);
	}
	
	public String getUpCount() {
		return Integer.toString(mCountMoveUp);
	}
	
	public String getDownCount() {
		return Integer.toString(mCountMoveDown);
	}	
}
