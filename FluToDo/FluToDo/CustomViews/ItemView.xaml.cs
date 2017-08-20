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
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(ItemView), "");

        public bool IsComplete
        {
            get { return (bool)GetValue(IsCompleteProperty); }
            set { SetValue(IsCompleteProperty, value); }
        }
        public static readonly BindableProperty IsCompleteProperty =
        BindableProperty.Create(nameof(IsComplete), typeof(bool), typeof(ItemView), false);

        #endregion BindableProperties

        #region  Constructor

        public ItemView()
        {
            InitializeComponent();
        }

        #endregion Constructor
    }
}