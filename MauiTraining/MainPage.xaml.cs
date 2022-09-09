namespace MauiTraining;

public partial class MainPage : ContentPage
{
	int count = 0;
	string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Counter.txt");

	public MainPage()
	{
		InitializeComponent();

		if (File.Exists(targetFile))
		{
			string lastCount = File.ReadAllText(targetFile);

			if (int.TryParse(lastCount, out int v))
				count = v;
		}
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		await File.WriteAllTextAsync(targetFile, count.ToString());
	}
}


