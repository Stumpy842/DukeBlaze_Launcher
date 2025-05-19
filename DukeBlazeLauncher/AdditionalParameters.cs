using System;

namespace DukeBlazeLauncher
{
    internal static class AdditionalParameters
    {

        private static MainWindow _mainWindow = null;


        internal static void Init(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }



        internal static string GameDirectoryCommand
        {
            get
            {
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string dir = exeDirectory + _mainWindow.GameDirTextBox.Text;
                if (!String.IsNullOrEmpty(_mainWindow.GameDirTextBox.Text)) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.game_dir].CommandName} {dir} ";
                return String.Empty;
            }
        }

        internal static string GameDirectory
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



        internal static string ConfigPathCommand
        {
            get
            {
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string dir = exeDirectory + _mainWindow.CfgPathTextBox.Text;
                if (!String.IsNullOrEmpty(_mainWindow.CfgPathTextBox.Text)) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.cfg].CommandName} {dir} ";
                return String.Empty;
            }
        }

        internal static string ConfigPath
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



        internal static string SkillCommand
        {
            get { return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.s].CommandName}{_mainWindow.SkillLevelComboBox.SelectedIndex} "; }
        }

        internal static int Skill
        {
            get { return _mainWindow.SkillLevelComboBox.SelectedIndex; }
            set { _mainWindow.SkillLevelComboBox.SelectedIndex = value; }
        }



        internal static string AddonCommand
        {
            get
            {
                if (_mainWindow.AddonComboBox.SelectedIndex > 0) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.addon].CommandName} {_mainWindow.AddonComboBox.SelectedIndex} ";
                return String.Empty;
            }
        }

        internal static int Addon
        {
            get { return _mainWindow.AddonComboBox.SelectedIndex; }
            set { _mainWindow.AddonComboBox.SelectedIndex = value; }
        }



        internal static string RespawnModeCommand
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

        internal static int RespawnMode
        {
            get { return _mainWindow.RespawnModeComboBox.SelectedIndex; }
            set { _mainWindow.RespawnModeComboBox.SelectedIndex = value; }
        }



        internal static string DisableStartupWindowCommand
        {
            get
            {
                if (_mainWindow.DisableStartupWindowCheckbox.Checked) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.nosetup].CommandName} ";
                return String.Empty;
            }
        }

        internal static bool DisableStartupWindow
        {
            get { return _mainWindow.DisableStartupWindowCheckbox.Checked; }
            set { _mainWindow.DisableStartupWindowCheckbox.Checked = value; }
        }



        internal static string DisableMonstersCommand
        {
            get
            {
                if (_mainWindow.DisableMonstersCheckbox.Checked) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.m].CommandName} ";
                return String.Empty;
            }
        }

        internal static bool DisableMonstersWindow
        {
            get { return _mainWindow.DisableMonstersCheckbox.Checked; }
            set { _mainWindow.DisableMonstersCheckbox.Checked = value; }
        }



        internal static string DisableStartupAnimationsAndLogosCommand
        {
            get
            {
                if (_mainWindow.SkipLogoCheckBox.Checked) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.nologo].CommandName} {CommandsBase.AllCommands[CommandsBase.CommandNames.quick].CommandName} ";
                return String.Empty;
            }
        }

        internal static bool DisableStartupAnimationsAndLogos
        {
            get { return _mainWindow.SkipLogoCheckBox.Checked; }
            set { _mainWindow.SkipLogoCheckBox.Checked = value; }
        }

        internal static string DisableInstanceCheckCommand
        {
            get {
                if (_mainWindow.DisableInstanceCheckbox.Checked) return $"{CommandsBase.AllCommands[CommandsBase.CommandNames.noinst].CommandName} ";
                return String.Empty;
            }
        }

        internal static bool DisableInstanceCheck
        {
            get { return _mainWindow.DisableInstanceCheckbox.Checked; }
            set { _mainWindow.DisableInstanceCheckbox.Checked = value; }
        }

        internal static string CustomExe
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


        internal static void SetDefaultParameters()
        {
            _mainWindow.GameDirTextBox.Text = String.Empty;
            _mainWindow.CfgPathTextBox.Text = String.Empty;
            _mainWindow.SkillLevelComboBox.SelectedItem = _mainWindow.SkillLevelComboBox.Items[1];
            _mainWindow.AddonComboBox.SelectedIndex = 0;
            _mainWindow.RespawnModeComboBox.SelectedIndex = 0;
            _mainWindow.DisableStartupWindowCheckbox.Checked = true;
            _mainWindow.DisableMonstersCheckbox.Checked = false;
            _mainWindow.SkipLogoCheckBox.Checked = true;
            _mainWindow.DisableInstanceCheckbox.Checked = true;
        }


        internal static string GetCommands()
        {
            return GameDirectoryCommand +
                ConfigPathCommand +
                SkillCommand + 
                AddonCommand +
                RespawnModeCommand +
                DisableStartupWindowCommand +
                DisableMonstersCommand +
                DisableStartupAnimationsAndLogosCommand +
                DisableInstanceCheckCommand;
        }

    }
}
