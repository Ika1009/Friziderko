namespace Friziderko.Model
{
	public class CustomImageButton : ImageButton
	{
		public static readonly BindableProperty ImageIdProperty = BindableProperty.Create(
			nameof(ImageId),
			typeof(int),
			typeof(CustomImageButton),
			default(int));

		public int ImageId
		{
			get { return (int)GetValue(ImageIdProperty); }
			set { SetValue(ImageIdProperty, value); }
		}
	}
}
