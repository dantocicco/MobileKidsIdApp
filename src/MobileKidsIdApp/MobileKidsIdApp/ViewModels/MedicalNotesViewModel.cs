﻿using Csla.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public class MedicalNotesViewModel : ViewModelBase<Models.MedicalNotes>
    {
        public MedicalNotesViewModel(Models.MedicalNotes medicalNotes)
        {
            Model = medicalNotes;
        }
    }
}
