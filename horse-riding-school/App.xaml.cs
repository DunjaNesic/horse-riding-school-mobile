using horse_riding_school.Models;

namespace horse_riding_school
{
    public partial class App : Application
    {
        public static User _user;
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}