using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BeckyTeachersAssistant.Models;
using BeckyTeachersAssistant.ViewModels;

namespace BeckyTeachersAssistant.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Name = "Item 1",
                OverallGrade = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}