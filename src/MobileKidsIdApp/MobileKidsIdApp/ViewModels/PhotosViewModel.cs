﻿using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.IO;

namespace MobileKidsIdApp.ViewModels
{
    public class PhotosViewModel : ViewModelBase<Models.FileReferenceList>
    {
        private bool IsAdding { get; set; }

        public PhotosViewModel(FileReferenceList fileReferenceList)
        {
            IsAdding = false;
            Model = fileReferenceList;
            _choosePhotoCommand = new Command(ChoosePhoto);
            _deletePhotoCommand = new Command(obj =>
            {
                var photoVM = (PhotoViewModel)obj;
                PhotoViewModels.Remove(photoVM);
                var fileRef = photoVM.FileReference;
                Model.Remove(fileRef);
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var fullPath = Path.Combine(documentsPath, fileRef.FileName);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            });

            PhotoViewModels = new ObservableCollection<PhotoViewModel>();
        }

        protected override void OnModelChanged(FileReferenceList oldValue, FileReferenceList newValue)
        {
            if (oldValue != null)
                oldValue.AddedNew -= Model_AddedNew;
            if (newValue != null)
                newValue.AddedNew += Model_AddedNew;

            base.OnModelChanged(oldValue, newValue);
        }

        private async void Model_AddedNew(object sender, Csla.Core.AddedNewEventArgs<FileReference> e)
        {
            if (IsAdding)
            {
                return;
            }

            IsAdding = true;
            var newItem = e.NewObject;
            var destinationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fileName = GenerateUniqueFileNameFor(destinationDirectory);

            PrepareToShowModal();
            var fullFileName = await DependencyService.Get<IPhotoPicker>().GetCopiedFilePath(destinationDirectory, fileName);
            if (fullFileName == null)
            {
                if (newItem != null)
                {
                    Model.Remove(newItem);
                }
                return;
            }
            newItem.FileName = fullFileName;
            var photoVM = new PhotoViewModel(newItem);
            await photoVM.InitializeAsync();
            PhotoViewModels.Add(photoVM);
            IsAdding = false;
        }

        protected override async Task<FileReferenceList> DoInitAsync()
        {
            var photoViewModels = Model.Select(_ => new PhotoViewModel(_)).ToList();
            var initTasks = new List<Task>();
            foreach (var viewModel in photoViewModels)
            {
                PhotoViewModels.Add(viewModel);
                initTasks.Add(viewModel.InitializeAsync());
            }
            await Task.WhenAll(initTasks);
            return Model;
        }

        private readonly ICommand _choosePhotoCommand;
        public ICommand ChoosePhotoCommand { get { return _choosePhotoCommand; } }
        
        public ObservableCollection<PhotoViewModel> PhotoViewModels { get; private set; }

        private void ChoosePhoto()
        {
            if (!IsAdding)
            {
                BeginAddNew();
            }
        }

        private readonly ICommand _deletePhotoCommand;
        public ICommand DeletePhotoCommand { get { return _deletePhotoCommand; } }

        private static Random _rnd = new Random();
        private static string GenerateUniqueFileNameFor(string path)
        {
            string generatedFileName;
            var fileNames = Directory.GetFiles(path);
            do
            {
                generatedFileName = string.Empty;
                for (int i = 0; i < 6; i++)
                    generatedFileName += Convert.ToChar(_rnd.Next(97, 122));
            } while (fileNames.Count(existingFileName => existingFileName.Equals(generatedFileName, 
                StringComparison.InvariantCultureIgnoreCase)) > 0);
            return generatedFileName;
        }
    }
}