using Csla.Xaml;
using MobileKidsIdApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public class PreparationChecklistViewModel : ViewModelBase<Models.PreparationChecklist>
    {
        public PreparationChecklistViewModel(Models.PreparationChecklist preparationChecklist)
        {
            Model = preparationChecklist;
        }
    }
}
