﻿using MobileCRM;
using MobileCRM.Models;
using MobileCRM.ViewModels.Orders;
using Xamarin.Forms;
using Xamarin;

namespace MobileCRM.Pages.Orders
{
    public partial class AccountHistoryView
    {
        OrdersViewModel viewModel;

        public AccountHistoryView(OrdersViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = vm;
        }

        public void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            Navigation.PushAsync(new AccountOrderDetailsView(e.Item as Order) { IsEnabled = false });

            OrdersList.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //if (viewModel.IsInitialized)
            //{
            //  return;
            //}
            viewModel.LoadOrdersCommand.Execute(null);
            viewModel.IsInitialized = true;

            Insights.Track("Account Details Order History Page");
        }

        public void RefreshView()
        {
            viewModel.LoadOrdersCommand.Execute(null);
            viewModel.IsInitialized = true;
        }
    }
}