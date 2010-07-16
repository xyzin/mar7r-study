package h2o.helloGallery;

import android.app.Activity;
import android.content.Context;
import android.content.res.TypedArray;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Gallery;
import android.widget.ImageView;

public class ImageAdapter extends BaseAdapter {
	int mGalleryItemBackground;
	private Context mContext;
	
	private Integer[] mImageIds = {
		R.drawable.sample_0,
		R.drawable.sample_1,
		R.drawable.sample_2,
		R.drawable.sample_3,
		R.drawable.sample_4,
		R.drawable.sample_5,
		R.drawable.sample_6,
		R.drawable.sample_7
	};

	public ImageAdapter(Context c) {
		mContext = c;
		TypedArray a = ((Activity)c).obtainStyledAttributes(R.styleable.HelloGallery);
		mGalleryItemBackground = a.getResourceId(
				R.styleable.HelloGallery_android_galleryItemBackground, 0);
		a.recycle();
	}

	public int getCount() {
		// TODO Auto-generated method stub
		return mImageIds.length;
	}

	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return position;
	}

	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return position;
	}

	public View getView(int position, View convertView, ViewGroup parent) {
		ImageView iv = new ImageView(mContext);
		
		iv.setImageResource(mImageIds[position]);
		iv.setLayoutParams(new Gallery.LayoutParams(150, 100));
		iv.setScaleType(ImageView.ScaleType.FIT_XY);
		iv.setBackgroundResource(mGalleryItemBackground);

		return iv;
	}

}
