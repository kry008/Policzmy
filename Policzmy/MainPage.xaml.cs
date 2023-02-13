namespace Policzmy;

public partial class MainPage : ContentPage
{
    bool trybCiemny = true;
    string dbLicznik = "spisLicznikow.txt";
    Stack<string> liczniki = new Stack<string>();

    public MainPage()
	{
		InitializeComponent();
        Generate();
    }
    public void Generate()
    {
        mainElement.Children.Clear();
        liczniki.Clear();
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, dbLicznik);
        if (File.Exists(_fileName))
        {
            string s1 = "";
            using (StreamReader sr = File.OpenText(_fileName))
            {
                while ((s1 = sr.ReadLine()) != null)
                {
                    string _fileName2 = Path.Combine(FileSystem.AppDataDirectory, s1 + ".txt");
                    if (File.Exists(_fileName2))
                    {
                        liczniki.Push(s1);
                    }
                }
            }
            foreach (string s in liczniki)
            {
                Controls.LiczenieElement le = new Controls.LiczenieElement(s, trybCiemny, this);
                mainElement.Children.Add(le);
            }
        }
    }
    public static string RandomString(int length)
    {
        Random random = new Random();
        const string chars = "qwertyuiopasdfghjklzxcvbnm0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
    private void AddNew_Clicked(object sender, EventArgs e)
    {
        string tytulLicznika;
        if (TytulLicznika.Text == null || TytulLicznika.Text == "")
        {
            tytulLicznika = "";
        }
        else
        {
            tytulLicznika = TytulLicznika.Text;
        }
        TytulLicznika.Text = "";
        string randomString = RandomString(15);
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, dbLicznik);
        using (StreamWriter sw = File.AppendText(_fileName))
        {
            sw.WriteLine(randomString);
        }
        string _fileName2 = Path.Combine(FileSystem.AppDataDirectory, randomString);
        using (StreamWriter sw = File.CreateText(_fileName2 + ".txt"))
        {
            sw.WriteLine("0;0;1;" + tytulLicznika + ";20");
        }
        Generate();
    }

    private void Set0_Clicked(object sender, EventArgs e)
    {
        foreach (string s in liczniki)
        {
            string _fileName = Path.Combine(FileSystem.AppDataDirectory, s + ".txt");
            string[] lines = File.ReadAllLines(_fileName);
            string[] line = lines[0].Split(';');
            line[0] = "0";
            string newLine = line[0] + ";" + line[1] + ";" + line[2] + ";" + line[3] + ";" + line[4];
            lines[0] = newLine;
            File.WriteAllLines(_fileName, lines);
        }
        Generate();
    }

    private void Del_Clicked(object sender, EventArgs e)
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, dbLicznik);
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }
        foreach (string s in liczniki)
        {
            string _fileName2 = Path.Combine(FileSystem.AppDataDirectory, s + ".txt");
            if (File.Exists(_fileName2))
            {
                File.Delete(_fileName2);
            }
        }
        Generate();
    }
    private void ThemeSwitch_Clicked(object sender, EventArgs e)
    {
        trybCiemny = !trybCiemny;
        if(!trybCiemny)
        {
            WygladInterfejs.Text = "Włącz noc";
        }
        else
        {
            WygladInterfejs.Text = "Włącz dzień";
        
        }
        Generate();
    }
}