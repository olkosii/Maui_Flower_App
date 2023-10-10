using Android.App;
using Android.Runtime;

namespace Maui_Flower_App;

[Application]
[MetaData("com.google.android.maps.v2.API_KEY",
            Value = "AIzaSyAEbGVyi4u2aNYLbq5wNSk9SCduZVI0bfk")]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
