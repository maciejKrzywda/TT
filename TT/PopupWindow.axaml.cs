using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MyPopupWindow;

public partial class PopupWindow : Window 
{
    public PopupWindow(string name, string country, List<string> attractions, string transport, List<string> cities)
    {
        InitializeComponent();
        
        SummaryText.Text = $"Imię i nazwisko: {name}\n" +
                           $"Kraj: {country}\n" +
                           $"Środek transportu: {transport}\n" +
                           $"Atrakcje: {string.Join(", ", attractions)}\n" +
                           $"Miasta do odwiedzenia: {string.Join(", ", cities)}";
    }

    private void OnCloseClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}