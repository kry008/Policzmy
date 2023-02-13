namespace Policzmy;
public partial class App : Application
{
    const int WindowWidth = 600;
    const int WindowHeight = 800;
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
    protected override Window CreateWindow(IActivationState activationState)
    {
        //Thx Kamilolek
        var window = base.CreateWindow(activationState);

        window.Width = WindowWidth;
        window.Height = WindowHeight;

        return window;
    }
}