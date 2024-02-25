<<<<<<< HEAD
using Avalonia;
=======
﻿using Avalonia;
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Ryujinx.Ava.Common;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.Ava.UI.Windows;
using System;

namespace Ryujinx.Ava.UI.Views.Main
{
    public partial class MainViewControls : UserControl
    {
        public MainWindowViewModel ViewModel;
<<<<<<< HEAD

=======
    
>>>>>>> 1ec71635b (sync with main branch)
        public MainViewControls()
        {
            InitializeComponent();
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);

            if (VisualRoot is MainWindow window)
            {
                ViewModel = window.ViewModel;
            }

            DataContext = ViewModel;
        }

        public void Sort_Checked(object sender, RoutedEventArgs args)
        {
            if (sender is RadioButton button)
            {
                ViewModel.Sort(Enum.Parse<ApplicationSort>(button.Tag.ToString()));
            }
        }
<<<<<<< HEAD

=======
    
>>>>>>> 1ec71635b (sync with main branch)
        public void Order_Checked(object sender, RoutedEventArgs args)
        {
            if (sender is RadioButton button)
            {
                ViewModel.Sort(button.Tag.ToString() != "Descending");
            }
        }
<<<<<<< HEAD

=======
    
>>>>>>> 1ec71635b (sync with main branch)
        private void SearchBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            ViewModel.SearchText = SearchBox.Text;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
