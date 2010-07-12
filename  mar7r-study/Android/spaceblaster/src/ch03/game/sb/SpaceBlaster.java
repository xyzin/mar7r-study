package ch03.game.sb;
import android.app.Activity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;


public class SpaceBlaster extends Activity {

	private View view;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		LayoutInflater factory = LayoutInflater.from(this);
		
		//���� ���̾ƿ� �����Ѵ�.
		view = factory.inflate(R.layout.main, null);
		setContentView(view);
		
		//Ű �Է»���� Ȱ��ȭ �Ѵ�.
		view.setFocusable(true);
		view.setFocusableInTouchMode(true);
	}
	@Override
	protected void onPause() {
		super.onPause();
		onStop();
	}
	@Override
	protected void onRestart() {
		super.onRestart();
		((ArcadeGame)view).resume();
	}
	@Override
	protected void onStart() {
		super.onStart();
	}
	@Override
	protected void onStop() {
		super.onStop();
		((ArcadeGame) view).halt();
	}
	
	public View getView() {
		return view;
	}

	
	
	
	
	
	
	
	
}
