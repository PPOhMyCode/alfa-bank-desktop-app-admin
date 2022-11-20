using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Desktop_Admin.Models;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class AddNewDishVM : BaseVM
{
    private DishInput _dishView;

    #region DishData
    public string Name
    {
        get { return _dishView.Name; }
        set
        {
            _dishView.Name = value;
            OnPropertyChanged("Name");
        }
    }
    
    public string Discription
    {
        get { return _dishView.Discription; }
        set
        {
            _dishView.Discription = value;
            OnPropertyChanged("Discription");
        }
    }
    
    public double Calories
    {
        get { return _dishView.Calories; }
        set
        {
            _dishView.Calories = value;
            OnPropertyChanged("Calories");
        }
    }
    
    public double Weight
    {
        get { return _dishView.Weight; }
        set
        {
            _dishView.Weight = value;
            OnPropertyChanged("Weight");
        }
    }
    
    public double Cost
    {
        get { return _dishView.Cost; }
        set
        {
            _dishView.Cost = value;
            OnPropertyChanged("Cost");
        }
    }

    #endregion
    
    public StackPanel IngredientsStackPanel { get; set; }
    private List<Ingredient> SelectedIngredients { get; set; }
    public Button AddNewIngredientButton { get; set; }
    
    private Ingredient _prevSelectedItem;
    private Ingredient _selectedItem;
    public Ingredient SelectedIngredient
    {
        get { return _selectedItem; }
        set
        {
            _prevSelectedItem = _selectedItem;
            _selectedItem = value;
            AddNewIngredientButton.IsEnabled = true;
            // if (_prevSelectedItem.Name == _selectedItem.Name)
            // {
            //     AddNewIngredientButton.IsEnabled = false;
            // }
            // else
            // {
            //     AddNewIngredientButton.IsEnabled = true;
            // }
            OnPropertyChanged("SelectedIngredient");
        }
    }
    
    public List<IngredientCountInput> InputIngredients { get; set; }
    public ObservableCollection<Ingredient> Ingredients { get; set; }
    public RelayCommand AddCommand { protected set; get; }
    public RelayCommand DeleteIngredientCommand { protected set; get; }
    public RelayCommand AddIngredientCommand { protected set; get; }
    public AddNewDishVM()
    {
        Ingredients = new ObservableCollection<Ingredient>(ApiServer.Get<List<Ingredient>>("Ingredients"));
        InputIngredients = new List<IngredientCountInput>();
        SelectedIngredients = new List<Ingredient>();
        _dishView = new DishInput();
        this.AddCommand = new RelayCommand(ExecuteAddDish);
        this.AddIngredientCommand = new RelayCommand(AddSelectedIngredient);
        this.DeleteIngredientCommand = new RelayCommand(DeleteIngredient);
        _selectedItem = null;
        _prevSelectedItem = null;
    }

    private void DeleteIngredient(object param)
    {
        var grid = (Grid) param;
        var parent = (StackPanel) grid.Parent;
        parent.Children.Remove(grid);
        var nameIngredient = ((TextBlock) grid.Children[0]).Text;
        var ingredient = SelectedIngredients.FirstOrDefault(x => x.Name == nameIngredient);
        Ingredients.Add(ingredient);
        SelectedIngredients.Remove(ingredient);
        
    }

    public void AddSelectedIngredient(object param)
    {
        if (_selectedItem == null)
            return;
        
        var ingredientRow = new Grid();
        ingredientRow.Height = 40;
        ingredientRow.Width = 460;
        ingredientRow.HorizontalAlignment = HorizontalAlignment.Left;
        var ing = new ColumnDefinition{Width = new GridLength(230)};
        var quantity = new ColumnDefinition{Width = new GridLength(110)};
        var measuree = new ColumnDefinition{Width = new GridLength(60)};
        var x = new ColumnDefinition{Width = new GridLength(60)};
        ingredientRow.ColumnDefinitions.Add(ing);
        ingredientRow.ColumnDefinitions.Add(quantity);
        ingredientRow.ColumnDefinitions.Add(measuree);
        ingredientRow.ColumnDefinitions.Add(x);

        var ingName = new TextBlock
        {
            Text = _selectedItem.Name,
            FontSize = 19,
            FontWeight = FontWeights.Normal,
            VerticalAlignment = VerticalAlignment.Center,
            Foreground = Application.Current.TryFindResource("DarkGrayBrush") as Brush //new SolidColorBrush(Color.FromRgb(65, 64, 64))
        };
        Grid.SetColumn(ingName, 0);
        Grid.SetRow(ingName, 0);

        ingredientRow.Children.Add(ingName);
        
        var input = new TextBox()
        {
            FontSize = 19,
            Padding = new Thickness(10, 5, 10, 5),
            FontWeight = FontWeights.Normal,
            BorderBrush =  Application.Current.TryFindResource("MediumGreenBrush") as Brush,
            Foreground = Application.Current.TryFindResource("DarkGrayBrush") as Brush,
            Style = Application.Current.TryFindResource("MaterialDesignOutlinedTextBox") as Style
        };
        MaterialDesignThemes.Wpf.HintAssist.SetHelperText(input, "Граммовка");
        Grid.SetColumn(input, 1);
        Grid.SetRow(input, 0);

        ingredientRow.Children.Add(input);
        
        var measure = new TextBlock
        {
            Text = _selectedItem.Measure,
            FontSize = 19,
            FontWeight = FontWeights.Normal,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Right,
            Foreground = new SolidColorBrush(Color.FromRgb(65, 64, 64))
        };
        Grid.SetColumn(measure, 2);
        Grid.SetRow(measure, 0);

        ingredientRow.Children.Add(measure);

        var xButton = new Button
        {
            Content = "x",
            Background = Brushes.Transparent,
            Foreground = Application.Current.TryFindResource("MediumGreenBrush") as Brush,
            BorderThickness = new Thickness(0.0),
            FontSize = 15,
            Width = 40,
            Height = 40,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Center,
            Command = DeleteIngredientCommand,
            CommandParameter = ingredientRow
        };
        Grid.SetColumn(xButton, 3);
        Grid.SetRow(xButton, 0);

        ingredientRow.Children.Add(xButton);
        
        ingredientRow.Margin = new Thickness(0, 5, 0, 15);
        IngredientsStackPanel.Children.Add(ingredientRow);
        SelectedIngredients.Add(_selectedItem);
        Ingredients.Remove(_selectedItem);
    }
    
    public void ExecuteAddDish(object param=null)
    {
         //TODO: Сделать проверку заполнености поле ввода
         
         var ingredientCount = IngredientsStackPanel.Children.Count;
         for (int i = 1; i < ingredientCount; i++)
         {
             var grid = (Grid)IngredientsStackPanel.Children[i];
             var ingredient = SelectedIngredients.FirstOrDefault(x => x.Name == ((TextBlock) grid.Children[0]).Text);
             var count = Convert.ToDouble(((TextBox)grid.Children[1]).Text);
             InputIngredients.Add(new IngredientCountInput()
             {
                 IngredientId = ingredient.Id,
                 Count = count/ingredient.Quantity
             });
         }
         ApiServer.Post(_dishView, "Dish");
         var dish = ApiServer.Get<List<Dish>>("Dish").FirstOrDefault(x => x.Name == _dishView.Name);
         ApiServer.Post(InputIngredients, "Dish/" + dish.Id + "/ingredients");
    }
}