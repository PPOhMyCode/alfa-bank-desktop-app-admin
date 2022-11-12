using System.Collections.Generic;
using System.Collections.ObjectModel;
using Desktop_Admin.Models;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class AddNewDishVM : BaseVM
{
    private DishView _dishView;

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
    
    public ObservableCollection<Ingredient> Ingredients { get; set; }

    public RelayCommand AddCommand { protected set; get; }
    public AddNewDishVM()
    {
        Ingredients = new ObservableCollection<Ingredient>(ApiServer.Get<List<Ingredient>>("Ingredients"));
        _dishView = new DishView();
        this.AddCommand = new RelayCommand(ExecuteAddDish);
    }
    
    public void ExecuteAddDish(object param)
    {
         //TODO: Сделать проверку заполнености поле ввода
         ApiServer.Post(_dishView, "Dish");
    }
}