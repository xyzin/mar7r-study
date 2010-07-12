package ch03.common;

import android.content.Context;
import android.media.MediaPlayer;

public class AudioClip {
	private MediaPlayer mPlayer;
	private String name;
	
	private boolean mPlaying 	= false;
	private boolean mLoop		= false;
	/**
	 * 
	 */
	public AudioClip(Context ctx, int resID) {
		// Ŭ�� �̸�
		name = ctx.getResources().getResourceName(resID);
		
		// ��ü ����� ��ü�� �����Ѵ�.
		mPlayer = MediaPlayer.create(ctx, resID);
		mPlayer.setVolume(1000, 1000);
		// �Ϸ� ��ǿ� ���� �ݹ��� ����Ѵ�.
		mPlayer.setOnCompletionListener(
				new MediaPlayer.OnCompletionListener() {
			
			public void onCompletion(MediaPlayer mp) {
				mPlaying = false;
				if(mLoop)
					mp.start();
				
			}
		});
		
	}

	public synchronized void play(){
		if(mPlaying)
			return;
		
		if(mPlayer != null){
			mPlaying = true;
			mPlayer.start();
		}
	}
	
	public synchronized void stop(){
		try{
			mLoop = false;
			if(mPlaying){
				mPlaying = false;
				mPlayer.pause();
			}
		}catch(Exception e){
			System.err.println("AudioClip::stop "+name + " " + e.toString());
		}
	}
	
	public synchronized void loop () {
		mLoop = true;
		mPlaying = true;
		mPlayer.start();		
		
	}
	
	public void release () {
		if(mPlayer != null){
			mPlayer.release();
			mPlayer = null;
		}
	}

}
