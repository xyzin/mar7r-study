package h2o.helloGallery;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Gallery;
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;

public class HelloGallery extends Activity {
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        
        Gallery g = (Gallery)findViewById(R.id.gallery);
        g.setAdapter(new ImageAdapter(this));
        
        g.setOnItemClickListener(new OnItemClickListener() {

			public void onItemClick(AdapterView<?> parent, View view, int position,
					long id) {
				Toast.makeText(HelloGallery.this, "" + position, Toast.LENGTH_SHORT).show();
			}
		});
    }
}