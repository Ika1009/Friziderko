﻿using Friziderko.ViewModel;

namespace Friziderko;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}
}
