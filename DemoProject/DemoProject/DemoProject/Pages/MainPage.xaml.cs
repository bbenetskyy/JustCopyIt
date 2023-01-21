using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.PageModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace DemoProject.Pages
{
    public partial class MainPage : MvxContentPage<MainPageModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}

