using System;

namespace Adapter
{
    // Адаптуємо Ubuntu
    class Ubuntu
    {
        public string RunFromUbuntu()
        {
            return "running from ubuntu";
        }
    }
    // Інтерфейс для Windows (специфікація до програми)
    interface IWindows
    {
        string RunFromWindows();
    }

    // Ну і власне сама пратформа, на якій запускається
    class Windows : IWindows
    {
        public string RunFromWindows()
        {
            return "running from windows";
        }
    }
    // Віртуальна машина (адаптер) назовні виглядає як Windows, шляхом наслідування прийнятного у 
    // Ubuntu
    class VirtualBox : IWindows
    {
        // Але всередині це ще Ubuntu
        private readonly Ubuntu _adaptee;
        public VirtualBox(Ubuntu adaptee)
        {
            _adaptee = adaptee;
        }

        // А тут відбувається вся магія: наш адаптер «перекладає»
        // функціональність із Windows на Ubuntu
        public string RunFromWindows()
        {
            return _adaptee.RunFromUbuntu();
        }
    }

    class WindowsFormApplication
    {
        // WinForms та DatagridView, яких розуміє тільки Windows
        public static void CreateDataGridViewTable(IWindows windows)
        {
            Console.WriteLine(windows.RunFromWindows());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            // 1) Ми можемо користуватися windows без проблем
            var windows = new Windows();
            WindowsFormApplication.CreateDataGridViewTable(windows);
            // 2) Ми повинні адаптуватися до Windows, використовуючи Virtual Box
            var ubuntu = new Ubuntu();
            var virtualBox = new VirtualBox(ubuntu);
            WindowsFormApplication.CreateDataGridViewTable(virtualBox);            
            Console.ReadKey();
        }
    }
}
