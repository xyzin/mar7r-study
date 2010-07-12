package ch03.game.sb;

import java.util.Timer;
import java.util.TimerTask;

import ch03.common.AudioClip;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.AttributeSet;
import android.widget.LinearLayout;

public abstract class ArcadeGame extends LinearLayout {
	//응용프로그램 문맥
	private Context mContext;

	//뷰를 무효화하는 데 쓰이는 갱신 타이머
	private Timer mUpdateTimer;

	//타이머 주기
	private long mPeriod = 1000;
	
	public ArcadeGame(Context context) {
		super(context);
		mContext = context;
		
	}

	public ArcadeGame(Context context, AttributeSet attrs) {
		super(context, attrs);
		mContext = context;
	}

	//레이아웃 초기화 시 호출됨
	@Override
	protected void onLayout(boolean changed, int l, int t, int r, int b) {
		super.onLayout(changed, l, t, r, b);
		try{
			//게임 초기화
			initialize();
			
			//갱신 시작한다. 이에 의해 잠시 후 onDraw가 호출된다.
			startUpdateTimer();
		}catch(Exception e){
			e.printStackTrace();
		}
	}
	
	// 갱신 주기 설정
	public void setUpdatePeriod(long period){
		mPeriod = period;
	}
	
	// 스프라이드 이동 등의 갱신을 위한 타이머를 시작한다.
	protected void startUpdateTimer(){
		mUpdateTimer = new Timer();
		mUpdateTimer.schedule(new UpdateTask(), 0, mPeriod);
	}
	
	protected void stopUpdateTimer(){
		if(mUpdateTimer != null){
			mUpdateTimer.cancel();
		}
	}
	
	public Context getmContext() {
		return mContext;
	}

	public void setmContext(Context mContext) {
		this.mContext = mContext;
	}
	
	// 이미지를 적재한다.
	protected Bitmap getImage(int id){
		return BitmapFactory.decodeResource(mContext.getResources(), id);
	}
	
	// AudioClip  인스턴스를 얻는다.
	protected AudioClip getAudioClip(int id){
		return new AudioClip(mContext, id);
	}
	
	// 파생 클래스에서 재정의할 메서드, 게임 내 세계를 갱신한다.
	abstract protected void updatePhysics();
	
	// 파생 클래스에서 재정의할 메서드, 게임을 초기화한다.
	abstract protected void initialize();
	abstract protected boolean gameOver();
	abstract protected long getScore();
	
	// 캔버스 갱신 태스크
	private class UpdateTask extends TimerTask{

		@Override
		public void run() {
			updatePhysics();
			
			/*
			 * 루프의 다음 주기에서 무효화가 일어나게 한다.
			 * 비 UI 스레드에서 뷰를 무효화 하고자 할 때 이 호출을
			 * 사용한다. 이후 onDraw가 호출된다.
			 *
			 * postInvalidate();
			 * Cause an invalidate to happen on a subsequent cycle through the event loop.
			 * Use this to invalidate the View from a non-UI thread 
			 */
			postInvalidate();
		}
	}

	
	/*
	 * 게임 중단 메서드, 갱신 태스크를 중지한다. 
	 * 부모 활동에서 게임을 중단하기 위해 이 메서드를 호출한다.
	 */
	public void halt(){
		stopUpdateTimer();
	}
	
	// 게임 재개
	public void resume(){
		initialize();
		startUpdateTimer();
	}
}





