namespace Policzmy.Controls;

public partial class LiczenieElement : ContentView
{
    int count = 0;
    int theme = 1;
    int allowMinus = 1;
    int fontSize = 10;
    string title = "Tytul";
    string id = "";
    bool isDark = true;
    int themeCount = 4;
    string[] buttonColorDark = { "000000", "000000", "000000", "000000" };
    string[] buttonBorderColorDark = { "FFFFFF", "FF0000", "00FF00", "4444FF" };
    string[] buttonTextColorDark = { "FFFFFF", "FF0000", "00FF00", "4444FF" };
    string[] labelColorDark = { "FFFFFF", "FF0000", "00FF00", "4444FF" };
    string[] titleColorDark = { "FFFFFF", "FF0000", "00FF00", "4444FF" };
    string[] backgroundColorDark = { "000000", "000000", "000000", "000000" };


    string[] buttonColorLight = { "FFFFFF", "FFFFFF", "FFFFFF", "FFFFFF" };
    string[] buttonBorderColorLight = { "FFFFFF", "FF0000", "00FF00", "0000FF" };
    string[] buttonTextColorLight = { "000000", "FF0000", "00FF00", "0000FF" };
    string[] labelColorLight = { "FFFFFF", "FF0000", "00FF00", "0000FF" };
    string[] titleColorLight = { "FFFFFF", "FF0000", "00FF00", "0000FF" };
    string[] backgroundColorLight = { "000000", "000000", "000000", "000000" };


    public static string RandomString(int length)
    {
        Random random = new Random();
        const string chars = "qwertyuiopasdfghjklzxcvbnm0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public LiczenieElement()
    {
        InitializeComponent();
        this.id = RandomString(15);
        this.isDark = true;
        init();
    }
    public LiczenieElement(string id, bool DarkMode, MainPage mainPage)
    {
        InitializeComponent();
        IDLabel.Text = id;
        this.id = id;
        this.isDark = DarkMode;
        init();
        BindingContext = mainPage;
    }
    private void init()
    {
        Wartosc.HorizontalTextAlignment = TextAlignment.Center;
        Wartosc.VerticalTextAlignment = TextAlignment.Center;
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, id + ".txt");
        if (File.Exists(_fileName))
        {
            string s1 = "";
            using (StreamReader sr = File.OpenText(_fileName))
                s1 = sr.ReadLine();
            string[] s2 = s1.Split(';');
            count = int.Parse(s2[0]);
            theme = int.Parse(s2[1]);
            allowMinus = int.Parse(s2[2]);
            title = s2[3];
            fontSize = int.Parse(s2[4]);
            Wartosc.Text = count.ToString();
            Wartosc.FontSize = fontSize;
            Tytul.Text = title;
            if (title != null || title != "")
                Tytul.FontSize = fontSize + 10;
            else
                Tytul.FontSize = 1;
            style(theme);
            if (allowMinus == 0)
                MinusAllowBtn.Text = "0+";
            else
                MinusAllowBtn.Text = "-+";
        }
    }
    private void style(int styleID)
    {
        if (this.isDark)
        {
            Kontener.BackgroundColor = Color.FromArgb("#FF" + backgroundColorDark[styleID]);
            Tytul.TextColor = Color.FromArgb("#FF" + titleColorDark[styleID]);
            Wartosc.TextColor = Color.FromArgb("#FF" + labelColorDark[styleID]);
            PlusButton.BackgroundColor = Color.FromArgb("#FF" + buttonColorDark[styleID]);
            PlusButton.BorderColor = Color.FromArgb("#FF" + buttonBorderColorDark[styleID]);
            PlusButton.TextColor = Color.FromArgb("#FF" + buttonTextColorDark[styleID]);
            MinusButton.BackgroundColor = Color.FromArgb("#FF" + buttonColorDark[styleID]);
            MinusButton.BorderColor = Color.FromArgb("#FF" + buttonBorderColorDark[styleID]);
            MinusButton.TextColor = Color.FromArgb("#FF" + buttonTextColorDark[styleID]);
            DeleteBtn.BackgroundColor = Color.FromArgb("#FF" + buttonColorDark[styleID]);
            ThemeBtn.BackgroundColor = Color.FromArgb("#FF" + buttonColorDark[styleID]);
            MinusAllowBtn.BackgroundColor = Color.FromArgb("#FF" + buttonColorDark[styleID]);
            DeleteBtn.BorderColor = Color.FromArgb("#FF" + buttonBorderColorDark[styleID]);
            ThemeBtn.BorderColor = Color.FromArgb("#FF" + buttonBorderColorDark[styleID]);
            MinusAllowBtn.BorderColor = Color.FromArgb("#FF" + buttonBorderColorDark[styleID]);
            DeleteBtn.TextColor = Color.FromArgb("#FF" + buttonTextColorDark[styleID]);
            ThemeBtn.TextColor = Color.FromArgb("#FF" + buttonTextColorDark[styleID]);
            MinusAllowBtn.TextColor = Color.FromArgb("#FF" + buttonTextColorDark[styleID]);
        }
        else
        {
            Kontener.BackgroundColor = Color.FromArgb("#FF" + backgroundColorLight[styleID]);
            Tytul.TextColor = Color.FromArgb("#FF" + titleColorLight[styleID]);
            Wartosc.TextColor = Color.FromArgb("#FF" + labelColorLight[styleID]);
            PlusButton.BackgroundColor = Color.FromArgb("#FF" + buttonColorLight[styleID]);
            PlusButton.BorderColor = Color.FromArgb("#FF" + buttonBorderColorLight[styleID]);
            PlusButton.TextColor = Color.FromArgb("#FF" + buttonTextColorLight[styleID]);
            MinusButton.BackgroundColor = Color.FromArgb("#FF" + buttonColorLight[styleID]);
            MinusButton.BorderColor = Color.FromArgb("#FF" + buttonBorderColorLight[styleID]);
            MinusButton.TextColor = Color.FromArgb("#FF" + buttonTextColorLight[styleID]);
            DeleteBtn.BackgroundColor = Color.FromArgb("#FF" + buttonColorLight[styleID]);
            ThemeBtn.BackgroundColor = Color.FromArgb("#FF" + buttonColorLight[styleID]);
            MinusAllowBtn.BackgroundColor = Color.FromArgb("#FF" + buttonColorLight[styleID]);
            DeleteBtn.BorderColor = Color.FromArgb("#FF" + buttonBorderColorLight[styleID]);
            ThemeBtn.BorderColor = Color.FromArgb("#FF" + buttonBorderColorLight[styleID]);
            MinusAllowBtn.BorderColor = Color.FromArgb("#FF" + buttonBorderColorLight[styleID]);
            DeleteBtn.TextColor = Color.FromArgb("#FF" + buttonTextColorLight[styleID]);
            ThemeBtn.TextColor = Color.FromArgb("#FF" + buttonTextColorLight[styleID]);
            MinusAllowBtn.TextColor = Color.FromArgb("#FF" + buttonTextColorLight[styleID]);
        }
    }
    private void MinusButton_Clicked(object sender, EventArgs e)
    {
        if(allowMinus != 1)
            if (count == 0)
                return;
        count--;
        Wartosc.Text = count.ToString();
        SaveState();
    }
    private void SaveState()
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, id + ".txt");
        using (StreamWriter sw = File.CreateText(_fileName))
        {
            sw.WriteLine(count + ";" + this.theme + ";" + allowMinus + ";" + title + ";" + fontSize);
        }
    }
    private void PlusButton_Clicked(object sender, EventArgs e)
    {
        count++;
        Wartosc.Text = count.ToString();
        SaveState();
    }
    private void Theme_Clicked(object sender, EventArgs e)
    {
        this.theme++;
        if (this.theme > themeCount-1)
            this.theme = 0;
        style(this.theme);
        SaveState();
    }
    private void MinusAllow_Clicked(object sender, EventArgs e)
    {
        if(allowMinus == 1)
        {
            allowMinus = 0;
            if(count < 0)
            {
                count = 0;
                Wartosc.Text = count.ToString();
            }
        }
        else
            allowMinus = 1;
        if (allowMinus == 0)
            MinusAllowBtn.Text = "0+";
        else
            MinusAllowBtn.Text = "-+";
        SaveState();
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, id + ".txt");
        File.Delete(_fileName);
        var mainPage = BindingContext as MainPage;
        mainPage.Generate();
    }
}