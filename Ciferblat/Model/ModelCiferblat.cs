namespace Ciferblat.Model;

public class ModelCiferblat
{
    private const string _pass = "228";
    
    public bool CheckAnswer(string pass)
    {
        return _pass.Equals(pass);
    }
}