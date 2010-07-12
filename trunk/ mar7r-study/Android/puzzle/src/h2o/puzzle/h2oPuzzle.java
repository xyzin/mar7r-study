package h2o.puzzle;

import android.app.*;
import android.os.*;
import android.view.*;
import android.view.View.*;
import android.widget.*;


public class h2oPuzzle extends Activity {
	Button mShuffleButton;
	GameView mGameView;
	
	private int mSec = 0;
	private int mMin = 0;
	private int mHour = 0;
	private TextView mElapsedTime;
	private boolean mTimerOn;
	private boolean mIsPlaying;
	private Dialog mWinDialog;
	private Window mWindow;
	private Thread elapsedTime = new Thread() {
		private boolean isStart = false;
		
		@Override
		public void run() {
			while(true)
			{
				if (mTimerOn)
				{
					mSec++;
					if (mSec > 59)
					{
						mSec = 0;
						mMin++;
					}
					if (mMin > 59)
					{
						mMin = 0;
						mHour++;
					}
					Message msg = handler.obtainMessage();
					handler.sendMessage(msg);
				}
				try {
					Thread.sleep(1000);
				} catch (InterruptedException e) {
				}
			}
		}

		@Override
		public synchronized void start() {
			if (isStart)
			{
				super.resume();
			} else {
				isStart = true;
				super.start();
			}
		}
		
	};

	private Handler handler = new Handler() {
		@Override
		public void handleMessage(Message msg) {
			mElapsedTime.setText(getElapsedTime());
		}
		
	};
	
	private String getElapsedTime() {
		return String.format("%02d:%02d:%02d", mHour, mMin, mSec);		
	}
	
	/** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        
        makeWinDialog();
        
        mGameView = (GameView)findViewById(R.id.game_view);
        mGameView.setOnTouchListener(onTouchListener);
        
        mShuffleButton = (Button)findViewById(R.id.shuffle);
        mShuffleButton.setOnClickListener(onShuffleClick);
        
        mElapsedTime = (TextView)findViewById(R.id.elapsed_time);
        mTimerOn = false;
        mIsPlaying = false;
    }
    
	private void makeWinDialog() {
		mWinDialog = new Dialog(this);
		mWindow = mWinDialog.getWindow();
		mWindow.setContentView(R.layout.complete_dialog);
		mWindow.setFlags(WindowManager.LayoutParams.FLAG_BLUR_BEHIND, 
				WindowManager.LayoutParams.FLAG_BLUR_BEHIND);
		((Button)mWindow.findViewById(R.id.btnRestart))
		.setOnClickListener(new OnClickListener() {
			public void onClick(View v) {
				restart();
			}
		});
		((Button)mWindow.findViewById(R.id.btnQuit))
		.setOnClickListener(new OnClickListener() {
			public void onClick(View v) {
				quit();
			}
		});
		mWinDialog.setTitle(R.string.win_msg);
	}
	
    private View.OnTouchListener onTouchListener = new View.OnTouchListener() {
		public boolean onTouch(View v, MotionEvent event) {
	    	int action = event.getAction();
	    	
	    	if (action == MotionEvent.ACTION_DOWN)
	    		return true;
	    	
	    	if (action == MotionEvent.ACTION_UP)
	    	{
	    		int x = (int)event.getX();
	    		int y = (int)event.getY();
	    		
	    		boolean isValidClick = mGameView.TouchCell(x, y);
	    		
	    		if (isValidClick && mIsPlaying && mGameView.checkGameStatus())
	    		{
	    			mIsPlaying = false;
	    			timerOff();
	    			winGame();
	    		}
	    		return isValidClick;
	    	}
			return false;
		}
	};
	
	private View.OnClickListener onShuffleClick = new OnClickListener() {
		public void onClick(View v) {
			mGameView.shuffle();
			GameStart();
		}
	};	
	
	public void restart() {
		closeWinDialog();
		GameStart();
	}
	
	public void quit() {
		closeWinDialog();
	}
	
	protected void GameStart() {
		initTimer();
		mIsPlaying = true;
		timerOn();
		elapsedTime.start();
	}
	
	private void winGame() {
		((TextView)mWindow.findViewById(R.id.txtLeft))
			.setText(mGameView.getLeftCount());
		((TextView)mWindow.findViewById(R.id.txtRight))
			.setText(mGameView.getRightCount());
		((TextView)mWindow.findViewById(R.id.txtUp))
			.setText(mGameView.getUpCount());
		((TextView)mWindow.findViewById(R.id.txtDown))
			.setText(mGameView.getDownCount());
		((TextView)mWindow.findViewById(R.id.txtSecond))
			.setText(getElapsedTime());
		mWinDialog.show();
	}
	
	private void timerOff() {
		mTimerOn = false;
	}
	
	private void timerOn() {
		mTimerOn = true;
	}
	
	private void closeWinDialog() {
		mWinDialog.dismiss();
	}
	
	protected void initTimer() {
		mSec = 0;
		mMin = 0;
		mHour = 0;
	}	
}