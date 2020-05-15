﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public partial class FriendListPage : ContentPage
    {
        public FriendListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ViewModels.IViewModel)BindingContext).SetActiveView();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await ((ViewModels.IViewModel)BindingContext).CloseView();
        }

        private void ChangeItem(object sender, EventArgs e)
        {
            var vm = ((ViewModels.FriendList)BindingContext);
            vm.CurrentItem = (ViewModels.FriendInfo)((Button)sender).BindingContext;
            vm.ChangeContact();
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            var vm = ((ViewModels.FriendList)BindingContext);
            vm.CurrentItem = (ViewModels.FriendInfo)((Button)sender).BindingContext;
            vm.DeleteContact();
        }
    }
}
