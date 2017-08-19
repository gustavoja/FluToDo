using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FluToDo.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemView : StackLayout
    {
        #region BindableProperties

        public string Name
        {
            get { return (string)GetValue(NamePorperty); }
            set { SetValue(NamePorperty, value); }
        }
        public static readonly BindableProperty NamePorperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(ItemView), "");

        #endregion BindableProperties

        #region  Constructor

        public ItemView()
        {
            InitializeComponent();
        }

        #endregion Constructor
    }
}