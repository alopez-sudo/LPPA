﻿using Xamarin.Forms;

namespace CalcularIMC
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			Device.SetFlags(new[] { "RadioButton_Experimental" });

			MainPage = new MainPage();
			
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
