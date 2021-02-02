using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWSFBlazorDemo.Data.DummyDataAccess
{
    public class DummyDataAccess : IDummyDataAccess
    {
        private string _headline = "";
        private string _details = "";
        private bool _showCountdown = false;
        private bool _showLogo = false;
        private string _countDownTitle;
        private bool _showAdminMenu = false;

        public string headline
        {
            get => _headline ?? "";
            set => _headline = value;
        }

        public string details
        {
            get => _details ?? "";
            set => _details = value;
        }

        public bool showLogo
        {
            get => _showLogo;
            set => _showLogo = value;
        }

        public bool showCountdown
        {
            get => _showCountdown;
            set => _showCountdown = value;
        }

        public string countDownTitle
        {
            get => _countDownTitle;
            set => _countDownTitle = value;
        }

        public bool showAdminMenu
        {
            get => _showAdminMenu;
            set => _showAdminMenu = value;
        }
    }
}
