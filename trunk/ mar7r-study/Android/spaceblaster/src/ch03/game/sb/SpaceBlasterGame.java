package ch03.game.sb;

import java.util.ArrayList;
import java.util.List;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.RectF;
import android.util.AttributeSet;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.widget.Toast;
import ch03.common.AudioClip;
import ch03.common.Tools;
import ch03.game.sb.item.AdditionalShield;
import ch03.game.sb.item.Item;
import ch03.game.sb.item.ItemEffect;
import ch03.game.sb.item.RefillLaser;
import ch03.game.sb.item.RefillShield;
import ch03.game.sb.item.UnlimitLaser;
import ch03.game.sb.item.UnlimitShield;

public class SpaceBlasterGame extends ArcadeGame {

	public static final String NAME = "SpaceBlaster";

	private static final long UPDATE_DELAY = 40;

	private static final int MAX_STARS = 30;

	private static final int KIND_OF_ITEMS = 5;
	
	private Context mContext;
	
	private Paint mTextPaint = new Paint();
	private Paint mBitmapPaint = new Paint();
	private Paint mLaserBarPaint 	= new Paint();
	private Paint mShieldBarPaint 	= new Paint();
	private Paint mShieldPaint		= new Paint();
	
	private int viewWidth, viewHeight;
	private int gameViewSize_x, gameViewSize_y;
	
	boolean bIsGameStarted = false;

	private Ship ship;
	private int ship_dx = 0, ship_dy = 0, shield = 0;
	private final int movePerTick_x = 10, movePerTick_y = 5;
	
	List<Bullet> bullets = new ArrayList<Bullet>();
	int bulletVelocity;
	
	List<Meteor> meteors = new ArrayList<Meteor>(); 
	int meteorMaxCount;
	int meteorRenewTick, meteorRenewInterval;
	int meteorVelocity;
	
	private List<Item> items = new ArrayList<Item>();
	private int itemVelocity;
	private int itemDurationInitValue;
	private ItemEffect itemEffect;
	private int itemEffectRestDuration;
	private int additionalShieldValue;
	private int itemDropRate = 10;

	List<Star> stars = new ArrayList<Star>();
	private int starVelocity;

	private Bitmap[] introImages;
	private Bitmap[] boomImages;
	int introImagePosition_x, introImagePostion_y;
	int introImageFrame = 0;
	final int introImageSize_x = 71, introImageSize_y = 100, introImageFrames = 4;
	
	int distance = 0, distanceForLevelUp = 1000;
	int sheildInitValue, maxShieldValue, currentShieldValue;
	int laserInitValue, maxLaserValue, currentLaserValue, laserChargeInterval, laserChargeTick = 0;
	int gameLevel;
	long score;

	AudioClip blast, crash, kill;

	final int maxshield = 9;
	final int backcol = 0x102040;
	final int borderwidth = 0;
	final int scoreBoardHeight = 45;

	private int originShipPosition_x;
	private int originShipPosition_y;	
	private int originTouchPosition_x;
	private int originTouchPosition_y;

	private boolean pauseNewMeteor;

	private int fingerId;

	public SpaceBlasterGame(Context context) {
		super(context);
		mContext = context;
		super.setUpdatePeriod(UPDATE_DELAY);
	}

	public SpaceBlasterGame(Context context, AttributeSet attrs) {
		super(context, attrs);
		mContext = context;
		super.setUpdatePeriod(UPDATE_DELAY);
	}
	
	/**
	 * Overload to initialize game elements
	 */
	@Override
	protected void initialize() {
		initDisplay();
		initItem();
		initShip();
		initBullet();
		initMeteor();
		initAudio();
		initStars();
		initIntro();
	}

	private void initAudio() {
		try{
			blast 	= getAudioClip(R.raw.sb_blast);
			crash 	= getAudioClip(R.raw.sb_collisn);
			kill	= getAudioClip(R.raw.sb_mdestr);
		}catch (Exception e){
			Tools.MessageBox(mContext, "Audio Error: "+e.toString());
		}
	}

	private void initMeteor() {
		boomImages =  new Bitmap[] {
				getImage(R.drawable.sb_boom0), 
				getImage(R.drawable.sb_boom1),
				getImage(R.drawable.sb_boom2),
				getImage(R.drawable.sb_boom3),
				getImage(R.drawable.sb_boom4)};		

		Meteor.setBitmap(getImage(R.drawable.sb_meteor));
		Meteor.setImageSize(80, 84);
		meteorVelocity = 2;
		Meteor.setBoomImage(boomImages);
		Meteor.setBoomImageSize(71, 100);
		
		meteorMaxCount = viewHeight / Meteor.getImageSize_y() + 1;
		meteorMaxCount = meteorMaxCount * 10;
	}

	private void initDisplay() {
		// 화면 크기
		viewWidth 	= getWidth();
		viewHeight	= getHeight();
		
		gameViewSize_x = viewWidth - borderwidth * 2;
		gameViewSize_y = viewHeight - borderwidth * 2 - scoreBoardHeight;		
		
		laserInitValue = 3;
		sheildInitValue = 3;

		// 텍스트용 Paint
		mTextPaint.setARGB(255, 255, 255, 255); //흰색
		mShieldPaint.setARGB(125, 0, 255, 255);
		
		// 레이저 동력 막대용 Paint
		mLaserBarPaint.setARGB(255, 0, 255, 96);
		mLaserBarPaint.setStyle(Paint.Style.FILL);
		
		// 보호막 동력 막대용 Paint
		mShieldBarPaint.setARGB(255, 0, 255, 255);
		mShieldBarPaint.setStyle(Paint.Style.FILL);
	}

	private void initBullet() {
		setBulletImage();
		setBulletSpeed();
	}

	private void setBulletSpeed() {
		bulletVelocity = -16;
	}

	private void setBulletImage() {
		Bullet.setBitmap(getImage(R.drawable.sb_bullet));
		Bullet.setImageSize(54, 8);
	}

	private void initShip() {
		setShipImage();
		ship = getNewShip();
	}

	private Ship getNewShip() {
		return new Ship(getDefaultShipPosition());
	}
	
	private Point getDefaultShipPosition() {
		return new Point((gameViewSize_x - Ship.getImageSize_x()) / 2, 
		gameViewSize_y - Ship.getImageSize_y() - scoreBoardHeight - borderwidth);
	}

	private void setShipImage() {
		Ship.setBitmap(getImage(R.drawable.sb_ship));
		Ship.setImageSize(90, 39);
		Bitmap[] engineFireImages = new Bitmap[] {
				getImage(R.drawable.sb_fire0), 
				getImage(R.drawable.sb_fire1)};
		Ship.setEngineFireImages(engineFireImages);
		Ship.setEngineFireImageSize(11, 6);
	}

	private void initItem() {
		setItemImage();
		setItemSpeed();
	}

	private void setItemSpeed() {
		itemVelocity = 2;
	}

	private void setItemImage() {
		UnlimitShield.setImage(getImage(R.drawable.redshield));
		AdditionalShield.setImage(getImage(R.drawable.greenshield));
		RefillShield.setImage(getImage(R.drawable.blueshield));
		UnlimitLaser.setImage(getImage(R.drawable.goldmedal));
		RefillLaser.setImage(getImage(R.drawable.silvermedal));
		Item.setItemSize(32, 32);
	}
	
	private void initStars(){
		starVelocity = 1;
		while(MAX_STARS > stars.size())
		{
			stars.add(
					new Star(
							(int)((Math.random()* gameViewSize_x -1) + 1), 
							(int)((Math.random()* gameViewSize_y -1) + 1)
							)
					);
		}
	}
	
	private void initIntro() {
		setIntroImage();
	}

	private void setIntroImage() {
		if (boomImages != null)
			introImages = boomImages;
		else {
			introImages = new Bitmap[] {
					getImage(R.drawable.sb_boom0), 
					getImage(R.drawable.sb_boom1),
					getImage(R.drawable.sb_boom2),
					getImage(R.drawable.sb_boom3),
					getImage(R.drawable.sb_boom4)};		
		}
	}	
	
	@Override
	protected void onDraw(Canvas canvas) 
	{
		super.dispatchDraw(canvas);
		drawGame(canvas);
	}
	
	private void drawGame(Canvas canvas) {
		if (bIsGameStarted)
			drawGameView(canvas);
		else
			drawIntro(canvas);
	}
	
	private void drawGameView(Canvas canvas) {
		if (!isPauseNewMeteor())
			makeNewMeteor();
		moveShip();
		drawPlayField(canvas);
		drawScore(canvas);

		laserCharge();
		shieldCharge();
		
		if(levelCheck())
		{
			itemDestroy();
			pauseNewMeteor = true;
			levelUp();
			difficultyChange();		
			showLevelUpMessage(canvas);
		}
	}

	private boolean isPauseNewMeteor() {
		if (!isCanMakeMeteor())
		{
			if (isEmptyMeteor())
			{
				canMakeMeteor();
				return false;
			}
			return true;
		}
		return false;
	}

	private void canMakeMeteor() {
		pauseNewMeteor = false;
	}

	private boolean isCanMakeMeteor() {
		return !pauseNewMeteor;
	}

	private boolean isEmptyMeteor() {
		return meteors.size() == 0;
	}

	private void drawIntro(Canvas canvas) {
		drawPlayField(canvas);
		drawIntroImage(canvas);
		drawIntroMessage(canvas);
	}

	private void drawIntroImage(Canvas canvas) {
		if (introImageFrame > introImageFrames) {
			introImagePosition_x = (int) (Math.random() * (gameViewSize_x - introImageSize_x) + 1);
			introImagePostion_y = (int) (Math.random() * (gameViewSize_y - introImageSize_y) + 1);
			introImageFrame = 0;
		}
		canvas.drawBitmap(introImages[introImageFrame++], introImagePosition_x, introImagePostion_y, mBitmapPaint);
	}

	private void drawIntroMessage(Canvas canvas) {
		String message = "Game Over"; 
		canvas.drawText(message
					, (viewWidth - (message.length() * mTextPaint.getTextSize()/2) ) / 2
					, (viewHeight - scoreBoardHeight - borderwidth)/2 - 20, mTextPaint);
	}
	
	public void makeNewMeteor() {
		meteorRenewTick++;
		if (meteorRenewTick > meteorRenewInterval / meteorVelocity) {
			meteorRenewTick = 0;
			
			if (meteors.size() < meteorMaxCount)
				meteors.add(new Meteor(
						(int) (Math.random() * (gameViewSize_x - Meteor.getImageSize_x()) + 1), 
						borderwidth - Meteor.getImageSize_y())
				);
		}
	}	
	
	private void moveShip() {
		ship.moveTo(getNewShipPosition());
	}
	
	private void drawPlayField(Canvas canvas) {
		if (itemEffect != ItemEffect.NONE)
			checkItemDuration();
		
		moveStars();
		drawStars(canvas);

		drawMeteor(canvas);
		drawItem(canvas);
		drawLaser(canvas);
		drawShip(canvas);
		
		processCollisions();
		processGetItem();

		if (shield > 0) {
			float left = ship.getX() - shield;
			float top = ship.getY() - shield;
			float right = left + Ship.getImageSize_x() + shield * 2;
			float bottom = top + Ship.getImageSize_y() + shield * 2;
			canvas.drawOval(new RectF(left, top, right, bottom), mShieldPaint);
			shield--;
		}
	}
	
	private void checkItemDuration() {
		itemEffectRestDuration--;
		if (itemEffectRestDuration < 0)
		{
			itemDestroy();
			Toast.makeText(mContext, "ITEM DESTROYED!", Toast.LENGTH_SHORT).show();
		}
	}

	private void itemDestroy() {
		if (itemEffect == ItemEffect.ADDITIONAL_SHIELD)
			removeAdditionalEffect();
		itemEffect = ItemEffect.NONE;
	}

	private void removeAdditionalEffect() {
		maxShieldValue -= additionalShieldValue;
		currentShieldValue = currentShieldValue > maxShieldValue ?
				maxShieldValue : 
					currentShieldValue;
	}

	private void moveStars() {
		for (int i=0; i < stars.size(); i++) 
		{
			Star star = stars.get(i);
			if (star.getY() > gameViewSize_y) 
				star.init((int) ((Math.random() * gameViewSize_x - 1) + 1), 0);
			else
				star.move(0, starVelocity);
		}
	}
	
	private void drawStars(Canvas canvas) {
		for (int i=0; i < stars.size(); i++) {
			Star star = stars.get(i);
			canvas.drawRect(star.getX(), 
					star.getY(), 
					star.getX() + star.getSize(), 
					star.getY() + star.getSize(),
					star.getPaint());
		}
	}	
	
	private void drawScore(Canvas canvas) {
		String message;
		
		int scoreBoardLineTop = viewHeight - scoreBoardHeight;
		int scoreBoardLineHeight = 10;
		int scoreBoardLineMargin = 5;
		int scoreBoardLeftMargin = 10;
		int scoreBoardChartMargin = 100;
		int widthPerValue = 
			(gameViewSize_x - scoreBoardChartMargin * 2) 
			/ Math.max(maxLaserValue, maxShieldValue);
		
		message = "LEVEL: " + gameLevel;
		canvas.drawText(message, scoreBoardLeftMargin, scoreBoardLeftMargin, mTextPaint);			

		message = "Laser: " + currentLaserValue + "/" + maxLaserValue;
		canvas.drawRect(scoreBoardChartMargin, scoreBoardLineTop, 
				scoreBoardChartMargin + maxLaserValue * widthPerValue, 
				scoreBoardLineTop + scoreBoardLineHeight, mTextPaint);
		canvas.drawRect(scoreBoardChartMargin, scoreBoardLineTop, 
				scoreBoardChartMargin + currentLaserValue * widthPerValue, 
				scoreBoardLineTop + scoreBoardLineHeight, mLaserBarPaint);
		canvas.drawText(message, scoreBoardLeftMargin, scoreBoardLineTop + (int)mTextPaint.getTextSize(), mTextPaint);

		scoreBoardLineTop += scoreBoardLineHeight;
		scoreBoardLineTop += scoreBoardLineMargin;
		
		message = "Shield: " + currentShieldValue + "/" + maxShieldValue;
		canvas.drawRect(scoreBoardChartMargin, scoreBoardLineTop, 
				scoreBoardChartMargin + maxShieldValue * widthPerValue, 
				scoreBoardLineTop + scoreBoardLineHeight, mTextPaint);
		canvas.drawRect(scoreBoardChartMargin, scoreBoardLineTop, 
				scoreBoardChartMargin + currentShieldValue * widthPerValue, 
				scoreBoardLineTop + scoreBoardLineHeight, mShieldBarPaint);
		canvas.drawText(message, scoreBoardLeftMargin, scoreBoardLineTop + (int)mTextPaint.getTextSize(), mTextPaint);

		scoreBoardLineTop += scoreBoardLineHeight;
		scoreBoardLineTop += scoreBoardLineMargin;
		message = "Score: " + score;
		canvas.drawText(message, scoreBoardLeftMargin, scoreBoardLineTop + (int)mTextPaint.getTextSize(), mTextPaint);
	}
	
	private void shieldCharge() {
		if (distance % 500 == 0) {
			currentShieldValue++;
			if (currentShieldValue > maxShieldValue)
				currentShieldValue = maxShieldValue;
		}
	}

	private void laserCharge() {
		laserChargeTick++;
		if (laserChargeTick % (laserChargeInterval / laserInitValue) == 0) {
			currentLaserValue++;
			if (currentLaserValue > maxLaserValue)
				currentLaserValue = maxLaserValue;
		}
		if (laserChargeTick > laserChargeInterval)
			laserChargeTick = 0;
	}	
	
	private boolean levelCheck() {
		distance++;
		score += 100;
		if (distance % distanceForLevelUp == 0) {
			return true;
		}
		return false;
	}
	
	private void levelUp() {
		gameLevel++;
	}	

	private void difficultyChange() {
		if (2 < gameLevel & gameLevel < 10) 
		{
			laserChargeFaster();
			meteorRenewFaster();
			moreLaserNShield();
		}
	}
	
	private void showLevelUpMessage(Canvas canvas) {
		Toast.makeText(mContext, "LEVEL " + gameLevel, Toast.LENGTH_LONG).show();
	}	
	
	private Point getNewShipPosition() {
		int newPosition_x = ship.getX() + (ship_dx * movePerTick_x);
		int newPosition_y = ship.getY() + (ship_dy * movePerTick_y);
		
		return filterImpossibleShipPosition(new Point(newPosition_x, newPosition_y));
	}
	
	private Point filterImpossibleShipPosition(Point p) {
		Point newPoint = new Point(p.x, p.y);
		
		if (p.x >= (viewWidth - borderwidth - Ship.getImageSize_x()))
		{
			newPoint.x = ship.getX();
		}
		if (p.x <= borderwidth) 
		{
			newPoint.x = 0;
		}		
		if (p.y >= (viewHeight - scoreBoardHeight - Ship.getImageSize_y()))
		{
			newPoint.y = ship.getY();
		}
		if (p.y <= borderwidth) {
			newPoint.y = 0;
		}
	
		return newPoint;
	}

	private void moreLaserNShield() {
		maxLaserValue++;
		maxShieldValue++;
		additionalShieldValue++;
	}

	private void meteorRenewFaster() {
		meteorVelocity++;
		meteorRenewInterval--;
	}

	private void laserChargeFaster() {
		laserChargeInterval -= 20;
	}

	private void drawShip(Canvas canvas) {
		canvas.drawBitmap(Ship.getBitmap(), ship.getX(), ship.getY(), mBitmapPaint); // paint ship

		canvas.drawBitmap(Ship.getEngineFireImage(), 
				ship.getX() + ((Ship.getImageSize_x() - Ship.getEngineFireImageSize_x()) / 2), 
				ship.getY()	+ Ship.getImageSize_y(), mBitmapPaint);
	}	

	@Override
	public boolean onKeyUp(int keyCode, KeyEvent event) {
		keyUp(keyCode);
		return true;
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		keyDown(keyCode);
		return true;
	}	
	
	
	@Override
	public boolean onTouchEvent(MotionEvent event) {
		int action = event.getAction();
		
		if (action == MotionEvent.ACTION_DOWN) 
		{
			setControlFingerId(event.getPointerId(0));
			originShipPosition_x = ship.getX();
			originShipPosition_y = ship.getY();
			
			originTouchPosition_x = (int)event.getX();
			originTouchPosition_y = (int)event.getY();
		} else if (action == MotionEvent.ACTION_POINTER_UP) {
			if (!isControlFinger(action))
				keyDown(KeyEvent.KEYCODE_SPACE);
		} else if (action == MotionEvent.ACTION_UP) {
			if(!bIsGameStarted)
			{
				GameStart();
			} else {
				keyDown(KeyEvent.KEYCODE_SPACE);
			}
		} else if (action == MotionEvent.ACTION_MOVE && 
				isControlFinger(action)) {
			int dx = 0;
			int dy = 0;
			
			for (int i=0; i<event.getPointerCount(); i++)
			{
				if (fingerId == event.getPointerId(i))
				{
					dx = (int)event.getX(i);
					dy = (int)event.getY(i);
				}
				
			}
			int touch_dx = originTouchPosition_x - dx;
			int touch_dy = originTouchPosition_y - dy;
			
			Point p = filterImpossibleShipPosition(
					new Point(originShipPosition_x - touch_dx, 
							originShipPosition_y - touch_dy)
					);
			
			ship.moveTo(p);
		}
		return true;
	}

	private boolean isControlFinger(int action) {
		return action >> MotionEvent.ACTION_POINTER_ID_SHIFT == fingerId;
	}

	private void setControlFingerId(int pointerId) {
		fingerId = pointerId;
	}

	public boolean keyDown(int key){
		if (bIsGameStarted) {
			if(key == KeyEvent.KEYCODE_DPAD_LEFT || key == KeyEvent.KEYCODE_Q)
				ship_dx = -1;
			if(key == KeyEvent.KEYCODE_DPAD_RIGHT || key == KeyEvent.KEYCODE_W)
				ship_dx = 1;
			if(key == KeyEvent.KEYCODE_DPAD_UP || key == KeyEvent.KEYCODE_O)
				ship_dy = -1;
			if(key == KeyEvent.KEYCODE_DPAD_DOWN || key == KeyEvent.KEYCODE_L)
				ship_dy = 1;
			if ( (key ==  KeyEvent.KEYCODE_SPACE) || (key == 23) ) {
				if(currentLaserValue > 0){
					fireGun();
				}
			}	
		}else {
			if (key == KeyEvent.KEYCODE_S){
				bIsGameStarted = true;
				GameStart();
			}
		}
		
		if(key == KeyEvent.KEYCODE_E){
			bIsGameStarted = false;
		}
		
		if(key == KeyEvent.KEYCODE_Q){
			System.exit(0);
		}
		return true;			
	}
	
	// 키 떼어짐 사건을 처리한다.
	public boolean keyUp(int key){
		if(key == KeyEvent.KEYCODE_DPAD_LEFT
				|| key == KeyEvent.KEYCODE_DPAD_RIGHT
				|| key == KeyEvent.KEYCODE_Q
				|| key == KeyEvent.KEYCODE_W)
			ship_dx = 0;
		if(key == KeyEvent.KEYCODE_DPAD_UP
				|| key == KeyEvent.KEYCODE_DPAD_DOWN
				|| key == KeyEvent.KEYCODE_O
				|| key == KeyEvent.KEYCODE_L)
			ship_dy = 0;
			return true;	
	}

	private void fireGun() {
		bullets.add(
				new Bullet(
						ship.getX() + ((Ship.getImageSize_x() - Bullet.getImageSize_x()) / 2), 
						ship.getY()
						)
				);
		if (itemEffect != ItemEffect.UNLIMIT_LASER )
			currentLaserValue--;
		blast.play();
	}

	private void drawLaser(Canvas canvas) {
		for (int i=0; i<bullets.size(); i++)
		{
			Bullet bullet = bullets.get(i);
			bullet.move(0, bulletVelocity);
			if (isOutOfView(bullet) ||
				isDestroyedMeteor(bullet))
			{
				bullets.remove(i);
			} else {
				canvas.drawBitmap(Bullet.getBitmap(), bullet.getX(), bullet.getY(), mBitmapPaint);
			}
		}
	}

	private boolean isOutOfView(Bullet bullet) {
		return bullet.getY() < borderwidth;
	}

	private boolean isDestroyedMeteor(Bullet bullet) {
		for (int i=0; i<meteors.size(); i++)
		{
			Meteor m = meteors.get(i);
			if (m.isNormal() & bullet.getX() + Bullet.getImageSize_x() > m.getX() 
					& bullet.getX() < m.getX() + Meteor.getImageSize_x() 
					& bullet.getY() + Bullet.getImageSize_y() > m.getY()
					& bullet.getY() < m.getY() + Meteor.getImageSize_y())
			{
				m.distroy();
				kill.play();
				return true;
			}
		}
		return false;
	}

	private void drawMeteor(Canvas canvas) {

		for (int i=0; i<meteors.size(); i++) 
		{
			Meteor m = meteors.get(i);
			m.move(0, meteorVelocity);
			if (m.getY() > viewHeight - borderwidth - scoreBoardHeight) {
				meteors.remove(i);
			} else {
				if (m.isNormal()) {
					canvas.drawBitmap(Meteor.getBitmap(), m.getX(), m.getY(), mBitmapPaint); 
					// meteor
				} else {
					canvas.drawBitmap(m.getBoomImage(), m.getX()
							+ (Meteor.getImageSize_x() - Meteor.getBoomImageSize_x()) / 2, m.getY()
							+ (Meteor.getImageSize_y() - Meteor.getBoomImageSize_y()) / 2, mBitmapPaint); 
																	
					if (m.isDestroyed())
					{
						if (isLuckyForItem())
						{
							items.add(makeNewItem(m.getX(), m.getY()));
						}
						meteors.remove(i);
					}
				}
			}
		}
	}

	private Item makeNewItem(int x, int y) {
		int itemKind = (int)(Math.random() * KIND_OF_ITEMS);
		Point itemPosition = getItemPosition(x, y);
		Item item = null;
		switch(itemKind) {
		case 0:
			item = new UnlimitShield(itemPosition, itemDurationInitValue);
			break;
		case 1:
			item = new AdditionalShield(itemPosition, itemDurationInitValue);
			break;
		case 2:
			item = new RefillShield(itemPosition, itemDurationInitValue);
			break;
		case 3:
			item = new UnlimitLaser(itemPosition, itemDurationInitValue);
			break;
		case 4:
			item = new RefillLaser(itemPosition, itemDurationInitValue);
			break;
		default:
			item = new RefillLaser(itemPosition, itemDurationInitValue);
			break;
		}
		return item;
	}

	private Point getItemPosition(int x, int y) {
		return new Point(
				x + (Meteor.getImageSize_x() / 2) - (Item.getItemSize_x() / 2), 
				y + (Meteor.getImageSize_y() / 2) - (Item.getItemSize_y() / 2));
	}

	private boolean isLuckyForItem() {
		if (itemDropRate > (int)(Math.random() * 100))
			return true;
		else
			return false;
	}
	
	private void drawItem(Canvas canvas) {
		for (int i=0; i<items.size(); i++) 
		{
			Item item = items.get(i);
			item.move(0, itemVelocity);
			if (item.getY() > viewHeight - borderwidth - scoreBoardHeight) {
				items.remove(i);
			} else {
				canvas.drawBitmap(item.getImage(), item.getX(), item.getY(), mBitmapPaint); 
			}
		}
	}	

	private void processCollisions() {
		for (int i=0; i < meteors.size(); i++) 
		{
			Meteor m = meteors.get(i);
			if (m.isNormal() 
					& ship.getX() + Ship.getImageSize_x() > m.getX() 
					& ship.getX() < m.getX() + Meteor.getImageSize_x()
					& ship.getY() + Ship.getImageSize_y() > m.getY() 
					& ship.getY() < m.getY() + Meteor.getImageSize_y()) {
				hitShip();
				m.distroy();
			}
		}
	}
	
	private void processGetItem() {
		for (int i=0; i < items.size(); i++) 
		{
			Item item = items.get(i);
			if (ship.getX() + Ship.getImageSize_x() > item.getX() 
					& ship.getX() < item.getX() + Item.getItemSize_x()
					& ship.getY() + Ship.getImageSize_y() > item.getY() 
					& ship.getY() < item.getY() + Item.getItemSize_y()) {
				getItem(item);
				items.remove(i);
			}
		}
	}	
	
	private void hitShip() {
		crash.play();
		shield = maxshield;
		if (itemEffect != ItemEffect.UNLIMIT_SHIELD)
			currentShieldValue--;
		if (currentShieldValue < 0)
			GameOver();
	}
	
	private void getItem(Item item) {
		if (itemEffect == ItemEffect.ADDITIONAL_SHIELD)
			removeAdditionalEffect();
		
		itemEffect = item.getAbility();
		itemEffectRestDuration = item.getDuration();
		Toast.makeText(mContext, item.getAbility().toString(), Toast.LENGTH_SHORT).show();
		
		switch(itemEffect) {
		case ADDITIONAL_SHIELD:
			maxShieldValue += additionalShieldValue;
			refillShield();
			break;
		case UNLIMIT_SHIELD:
			refillShield();
			break;
		case REFIL_SHIELD:
			refillShield();
			itemEffect = ItemEffect.NONE;
			break;
		case UNLIMIT_LASER:
			refillLaser();
			break;
		case REFIL_LASER:
			refillLaser();
			itemEffect = ItemEffect.NONE;
			break;
		}
	}	

	private void refillLaser() {
		currentLaserValue = maxLaserValue;
	}

	private void refillShield() {
		currentShieldValue = maxShieldValue;
	}

	// Game Start
	public void GameStart() {
		bIsGameStarted = true;
		
		maxLaserValue = laserInitValue * laserInitValue;
		currentLaserValue = maxLaserValue;
		maxShieldValue = sheildInitValue * sheildInitValue;
		currentShieldValue = maxShieldValue;
		gameLevel = 1;
		distance = 0;
		score = 0;
		laserChargeInterval = 250;

		meteorRenewTick = 0;
		meteorRenewInterval = 60;
		meteorVelocity = 2;
		
		itemEffect = ItemEffect.NONE;
		itemDurationInitValue = 200;
		additionalShieldValue = 2;
	}

	// Game Over
	public void GameOver() {
		bIsGameStarted = false;
	}

	@Override
	protected void updatePhysics() {

	}
	@Override
	protected boolean gameOver() {
		return bIsGameStarted;
	}

	@Override
	protected long getScore() {
		return score;
	}

	// TODO: using test
	public void testInit() {
		initialize();
	}
	
	public List<Meteor> getMeteors() {
		return meteors;
	}
	
}
