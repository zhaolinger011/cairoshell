﻿using CairoDesktop.Common;
using System.Windows.Input;
using ManagedShell.Common.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CairoDesktop.SupportingClasses
{
    internal class SystemHotKeys
    {
        internal static void RegisterSystemHotkeys()
        {
            new HotKey(Key.R, HotKeyModifier.Win | HotKeyModifier.NoRepeat, OnWinRCommand);
            new HotKey(Key.D, HotKeyModifier.Win | HotKeyModifier.NoRepeat, OnWinDCommand);
            new HotKey(Key.OemComma, HotKeyModifier.Win | HotKeyModifier.NoRepeat, OnWinDCommand);
            new HotKey(Key.E, HotKeyModifier.Win | HotKeyModifier.NoRepeat, OnWinECommand);
            new HotKey(Key.I, HotKeyModifier.Win | HotKeyModifier.NoRepeat, OnWinICommand);
            new HotKey(Key.Pause, HotKeyModifier.Win | HotKeyModifier.NoRepeat, OnWinPauseCommand);
        }

        private static void OnWinDCommand(HotKey obj)
        {
            var desktopManager = CairoApplication.Current.Host.Services.GetService<DesktopManager>();
            desktopManager.ToggleOverlay();
        }
        
        private static void OnWinRCommand(HotKey cmd)
        {
            ShellHelper.ShowRunDialog(Localization.DisplayString.sRun_Title, Localization.DisplayString.sRun_Info);
        }

        private static void OnWinECommand(HotKey cmd)
        {
            FolderHelper.OpenLocation("::{20D04FE0-3AEA-1069-A2D8-08002B30309D}");
        }

        private static void OnWinICommand(HotKey cmd)
        {
            ShellHelper.StartProcess("control.exe");
        }

        private static void OnWinPauseCommand(HotKey cmd)
        {
            ShellHelper.StartProcess("system.cpl");
        }

        // TODO: Add window management related HotKeys
        // Win + [up]
        // Win + [down]
        // Win + [left]
        // Win + [right]
    }
}