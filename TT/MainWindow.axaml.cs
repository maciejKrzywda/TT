using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using MyPopupWindow;

namespace TT;

public partial class MainWindow : Window
{
    private readonly string[] _imagePaths = 
    {
        "avares://TT/photos/Włochy.jpg",
        "avares://TT/photos/Japonia.jpg",
        "avares://TT/photos/Norwegia.jpg",
        "avares://TT/photos/USA.jpg",
        "avares://TT/photos/Francja.jpg"
    };
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void ChangeImageDisplay(object sender, SelectionChangedEventArgs e)
    {
        string selectedCountry = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            
        if (selectedCountry == "Francja")
        {
            using var stream = AssetLoader.Open(new Uri("avares://TT/photos/Francja.jpg"));
            CountryDisplayImage.Source = new Bitmap(stream);
        }
        else if (selectedCountry == "Norwegia")
        {
            using var stream = AssetLoader.Open(new Uri("avares://TT/photos/Norwegia.jpg"));
            CountryDisplayImage.Source = new Bitmap(stream);
        }
        else if (selectedCountry == "USA")
        {
            using var stream = AssetLoader.Open(new Uri("avares://TT/photos/USA.jpg"));
            CountryDisplayImage.Source = new Bitmap(stream);
        }
        else if (selectedCountry == "Japonia")
        {
            using var stream = AssetLoader.Open(new Uri("avares://TT/photos/Japonia.jpg"));
            CountryDisplayImage.Source = new Bitmap(stream);
        }
        else if (selectedCountry == "Włochy")
        {
            using var stream = AssetLoader.Open(new Uri("avares://TT/photos/Włochy.jpg"));
            CountryDisplayImage.Source = new Bitmap(stream);
        }
    }
    
    private void AddCityButton_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(CityTextBox.Text))
        {
            CityListBox.Items.Add(CityTextBox.Text);
            CityTextBox.Clear();
        }
    }
    
    private void ShowSummaryButton_Click(object sender, RoutedEventArgs e)
    {
        string name = TextBox.Text;
        string country = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

        List<string> attractions = new();
        if (MuseumCheckBox.IsChecked == true) attractions.Add("Muzea");
        if (ParksCheckBox.IsChecked == true) attractions.Add("Parki Narodowe");
        if (MonumentsCheckBox.IsChecked == true) attractions.Add("Zabytki");
        if (RestaurantsCheckBox.IsChecked == true) attractions.Add("Restauracje");
        if (GalleriesCheckBox.IsChecked == true) attractions.Add("Galerie sztuki");
        if (FestivalsCheckBox.IsChecked == true) attractions.Add("Festiwale i koncerty");

        string transport;
        if (PlaneRadioButton.IsChecked == true)
        {
            transport = "Plane";
        }
        else if (CarRadioButton.IsChecked == true)
        {
            transport = "Car";
        }
        else if (TrainRadioButton.IsChecked == true)
        {
            transport = "Train";
        }
        else if (ShipRadioButton.IsChecked == true)
        {
            transport = "Ship";
        }
        else
        {
            transport = "Nie wybrano";
        }

        List<string> cities = new();
        foreach (var item in CityListBox.Items) 
            cities.Add(item.ToString());

        var popupWindow = new PopupWindow(name, country, attractions, transport, cities);
        popupWindow.Show();
        this.Close();
    }
}