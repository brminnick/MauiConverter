using System;
using Xamarin.Forms;

namespace ConverterApp
{
	public class UnitsPicker : Picker
	{
		#region Fields
		Command _selectedIndexChangedCommand;
		#endregion

		public static readonly BindableProperty SelectedIndexChangedCommandProperty =
			BindableProperty.Create(nameof(SelectedIndexChangedCommand), typeof(Command), typeof(UnitsPicker), null);

		public Command SelectedIndexChangedCommand
		{
			get { return (Command)GetValue(SelectedIndexChangedCommandProperty); }
			set { SetValue(SelectedIndexChangedCommandProperty, value); }
		}

		public UnitsPicker()
		{
			BackgroundColor = ColorConstants.LightestPurple;
			SelectedIndexChanged += HandleSelectedIndexChanged;
		}

		void HandleSelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedIndexChangedCommand?.Execute(null);
		}
	}
}
