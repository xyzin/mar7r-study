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
	//�������α׷� ����
	private Context mContext;

	//�並 ��ȿȭ�ϴ� �� ���̴� ���� Ÿ�̸�
	private Timer mUpdateTimer;

	//Ÿ�̸� �ֱ�
	private long mPeriod = 1000;
	
	public ArcadeGame(Context context) {
		super(context);
		mContext = context;
		
	}

	public ArcadeGame(Context context, AttributeSet attrs) {
		super(context, attrs);
		mContext = context;
	}

	//���̾ƿ� �ʱ�ȭ �� ȣ���
	@Override
	protected void onLayout(boolean changed, int l, int t, int r, int b) {
		super.onLayout(changed, l, t, r, b);
		try{
			//���� �ʱ�ȭ
			initialize();
			
			//���� �����Ѵ�. �̿� ���� ��� �� onDraw�� ȣ��ȴ�.
			startUpdateTimer();
		}catch(Exception e){
			e.printStackTrace();
		}
	}
	
	// ���� �ֱ� ����
	public void setUpdatePeriod(long period){
		mPeriod = period;
	}
	
	// �������̵� �̵� ���� ������ ���� Ÿ�̸Ӹ� �����Ѵ�.
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
	
	// �̹����� �����Ѵ�.
	protected Bitmap getImage(int id){
		return BitmapFactory.decodeResource(mContext.getResources(), id);
	}
	
	// AudioClip  �ν��Ͻ��� ��´�.
	protected AudioClip getAudioClip(int id){
		return new AudioClip(mContext, id);
	}
	
	// �Ļ� Ŭ�������� �������� �޼���, ���� �� ���踦 �����Ѵ�.
	abstract protected void updatePhysics();
	
	// �Ļ� Ŭ�������� �������� �޼���, ������ �ʱ�ȭ�Ѵ�.
	abstract protected void initialize();
	abstract protected boolean gameOver();
	abstract protected long getScore();
	
	// ĵ���� ���� �½�ũ
	private class UpdateTask extends TimerTask{

		@Override
		public void run() {
			updatePhysics();
			
			/*
			 * ������ ���� �ֱ⿡�� ��ȿȭ�� �Ͼ�� �Ѵ�.
			 * �� UI �����忡�� �並 ��ȿȭ �ϰ��� �� �� �� ȣ����
			 * ����Ѵ�. ���� onDraw�� ȣ��ȴ�.
			 *
			 * postInvalidate();
			 * Cause an invalidate to happen on a subsequent cycle through the event loop.
			 * Use this to invalidate the View from a non-UI thread 
			 */
			postInvalidate();
		}
	}

	
	/*
	 * ���� �ߴ� �޼���, ���� �½�ũ�� �����Ѵ�. 
	 * �θ� Ȱ������ ������ �ߴ��ϱ� ���� �� �޼��带 ȣ���Ѵ�.
	 */
	public void halt(){
		stopUpdateTimer();
	}
	
	// ���� �簳
	public void resume(){
		initialize();
		startUpdateTimer();
	}
}





