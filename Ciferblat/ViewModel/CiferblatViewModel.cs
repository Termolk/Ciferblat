using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Ciferblat.Model;

namespace Ciferblat.ViewModel;

public class CiferblatViewModel : INotifyPropertyChanged
{
    private ModelCiferblat _modelCiferblat = new ModelCiferblat();
    private string _text = "";
    private bool _isEnableButton = true;
    
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }
    
    public bool IsEnableButton
    {
        get => _isEnableButton;
        set
        {
            _isEnableButton = value;
            OnPropertyChanged(nameof(IsEnableButton));
        }
    }

    public ICommand AddNumCommand { get; private set; }
    public ICommand ClearAllCommand { get; private set; }
    public ICommand CheckPassCommand { get; private set; }

    public CiferblatViewModel()
    {
        AddNumCommand = new Command<string>(AddNum);
        ClearAllCommand = new Command(ClearAll);
        CheckPassCommand = new Command(CheckPass);
    }

    private void CheckPass()
    {
        if (_modelCiferblat.CheckAnswer(Text))
        {
            Text = "DONE";
            IsEnableButton = false;
        }
        else
        {
            ClearAll();
        }
    }
    private void ClearAll()
    {
        Text = "";
    }
    
    private void AddNum(string ch)
    {
        if (Text.Length < 8) Text += ch;
        else Text = "";
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}