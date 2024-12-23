using System;

namespace DragDukeLauncher
{
    public static class AdditionalParameters
    {

        private static MainWindow _mainWindow = null;


        public static void Init(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }



        public static string GameDirectoryCommand
        {
            get
            {
                if (!String.IsNullOrEmpty(_mainWindow.GameDirTextBox.Text)) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.game_dir].CommandName} {_mainWindow.GameDirTextBox.Text} ";
                return String.Empty;
            }
        }

        public static string GameDirectory
        {
            get
            {
                if (!String.IsNullOrEmpty(_mainWindow.GameDirTextBox.Text)) return _mainWindow.GameDirTextBox.Text;
                return String.Empty;
            }
            set
            {
                _mainWindow.GameDirTextBox.Text = value;
            }
        }



        public static string ConfigPathCommand
        {
            get
            {
                if (!String.IsNullOrEmpty(_mainWindow.CfgPathTextBox.Text)) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.cfg].CommandName} {_mainWindow.CfgPathTextBox.Text} ";
                return String.Empty;
            }
        }

        public static string ConfigPath
        {
            get
            {
                if (!String.IsNullOrEmpty(_mainWindow.CfgPathTextBox.Text)) return _mainWindow.CfgPathTextBox.Text;
                return String.Empty;
            }
            set
            {
                _mainWindow.CfgPathTextBox.Text = value;
            }
        }



        public static string SkillCommand
        {
            get{ return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.s].CommandName}{_mainWindow.SkillLevelComboBox.SelectedIndex.ToString()} "; }
        }

        public static int Skill
        {
            get { return _mainWindow.SkillLevelComboBox.SelectedIndex; }
            set { _mainWindow.SkillLevelComboBox.SelectedIndex = value; }
        }



        public static string AddonCommand
        {
            get
            {
                if (_mainWindow.AddonComboBox.SelectedIndex > 0) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.addon].CommandName} {_mainWindow.AddonComboBox.SelectedIndex} ";
                return String.Empty;
            }
        }

        public static int Addon
        {
            get { return _mainWindow.AddonComboBox.SelectedIndex; }
            set { _mainWindow.AddonComboBox.SelectedIndex = value; }
        }



        public static string RespawnModeCommand
        {
            get
            {
                if (_mainWindow.RespawnModeComboBox.SelectedIndex > 0 && _mainWindow.RespawnModeComboBox.SelectedIndex <= 3)
                {
                    return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.t].CommandName}{_mainWindow.RespawnModeComboBox.SelectedIndex} ";
                }
                else if (_mainWindow.RespawnModeComboBox.SelectedIndex > 3)
                {
                    return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.t].CommandName}x ";
                }
                return String.Empty;
            }
        }

        public static int RespawnMode
        {
            get { return _mainWindow.RespawnModeComboBox.SelectedIndex; }
            set { _mainWindow.RespawnModeComboBox.SelectedIndex = value; }
        }



        public static string DisableStartupWindowCommand
        {
            get
            {
                if (_mainWindow.DisableStartupWindowCheckbox.Checked) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.nosetup].CommandName} ";
                return String.Empty;
            }
        }

        public static bool DisableStartupWindow
        {
            get { return _mainWindow.DisableStartupWindowCheckbox.Checked; }
            set { _mainWindow.DisableStartupWindowCheckbox.Checked = value; }
        }



        public static string DisableMonstersCommand
        {
            get
            {
                if (_mainWindow.DisableMonstersCheckbox.Checked) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.m].CommandName} ";
                return String.Empty;
            }
        }

        public static bool DisableMonstersWindow
        {
            get { return _mainWindow.DisableMonstersCheckbox.Checked; }
            set { _mainWindow.DisableMonstersCheckbox.Checked = value; }
        }



        public static string DisableStartupAnimationsAndLogosCommand
        {
            get
            {
                if (_mainWindow.SkipLogoCheckBox.Checked) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.nologo].CommandName} {CommandsBase.AllCommands[CommandsBase.CommandNames.quick].CommandName} ";
                return String.Empty;
            }
        }

        public static bool DisableStartupAnimationsAndLogos
        {
            get { return _mainWindow.SkipLogoCheckBox.Checked; }
            set { _mainWindow.SkipLogoCheckBox.Checked = value; }
        }



        public static string CustomExe
        {
            get
            {
                if (!String.IsNullOrEmpty(_mainWindow.CustomExeTextBox.Text)) return _mainWindow.CustomExeTextBox.Text;
                return String.Empty;
            }
            set
            {
                _mainWindow.CustomExeTextBox.Text = value;
            }
        }


        public static void SetDefaultParameters()
        {
            _mainWindow.GameDirTextBox.Text = String.Empty;
            _mainWindow.CfgPathTextBox.Text = String.Empty;
            _mainWindow.SkillLevelComboBox.SelectedItem = _mainWindow.SkillLevelComboBox.Items[1];
            _mainWindow.AddonComboBox.SelectedIndex = 0;
            _mainWindow.RespawnModeComboBox.SelectedIndex = 0;
            _mainWindow.DisableStartupWindowCheckbox.Checked = true;
            _mainWindow.DisableMonstersCheckbox.Checked = false;
            _mainWindow.SkipLogoCheckBox.Checked = true;
        }


        public static string GetCommands()
        {
            return GameDirectoryCommand +
                ConfigPathCommand +
                SkillCommand + 
                AddonCommand +
                RespawnModeCommand +
                DisableStartupWindowCommand +
                DisableMonstersCommand +
                DisableStartupAnimationsAndLogosCommand;
        }

    }
}
