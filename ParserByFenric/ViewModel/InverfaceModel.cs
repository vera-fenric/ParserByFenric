using System.Collections.Generic;

namespace ViewModel
{
    //определение всех нужных интерфейсов
    public enum YNC { Yes, No, Cancel };
    public enum YN { Yes, No };

    public interface IConfirmInterface
    {
        YNC ConfirmFunc(string s);
    }
    public interface ISimpleConfirmInterface
    {
        YN SimpleConfirmFunc(string s);
    }
    public interface ISaveFileInterface
    {
        string SaveFileFunc();
    }
    public interface IOpenFileInterface
    {
        List<string> OpenFileFunc();
    }
    public interface IErrorInterface
    {
        void ErrorFunc(string s1, string s2);
        void ErrorFunc(string s);
        void ErrorFunc();
    }
    public interface IUIServices : IConfirmInterface, ISimpleConfirmInterface, ISaveFileInterface, IOpenFileInterface, IErrorInterface
    { }
}
