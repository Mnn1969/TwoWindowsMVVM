﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using TwoWindowsMVVM.Commands;
using TwoWindowsMVVM.Models;
using TwoWindowsMVVM.ViewModels.Base;

namespace TwoWindowsMVVM.ViewModels
{
    public class SecondaryWindowViewModel : TitledViewModel
    {
        public SecondaryWindowViewModel()
        {
            Title = "Вторичное окно";
        }

        #region Message : string? - Текст сообщения

        /// <summary>Текст сообщения</summary>
        private string? _Message;

        /// <summary>Текст сообщения</summary>
        public string? Message
        {
            get => _Message;
            set => Set(ref _Message, value);
        }

        #endregion

        private readonly ObservableCollection<TextMessageModel> _Messages = new();

        public IEnumerable<TextMessageModel> Messages => _Messages;

        #region Command SendMessageCommand - Отправка сообщения

        /// <summary>Отправка сообщения</summary>
        private LambdaCommand? _SendMessageCommand;

        /// <summary>Отправка сообщения</summary>
        public ICommand SendMessageCommand => _SendMessageCommand
            ??= new(OnSendMessageCommandExecuted, p => p is string { Length: > 0 });


        /// <summary>Логика выполнения - Отправка сообщения</summary>
        private void OnSendMessageCommandExecuted(object? p)
        {

        }

        #endregion


        #region Command OpenMainWindowCommand - Открыть Главное окно

        /// <summary>Открыть второе окно</summary>
        private LambdaCommand _OpenMainWindowCommand = null!;

        /// <summary>Открыть второе окно</summary>
        public ICommand OpenMainWindowCommand => _OpenMainWindowCommand
            ??= new(OnOpenMainWindowCommandExecuted);

        /// <summary>Логика выполнения - Открыть второе окно</summary>
        private void OnOpenMainWindowCommandExecuted()
        {

        }

        #endregion

        #region Command ChangeToMainWindowCommand - Перейти в Главное окно

        /// <summary>Перейти во второе окно</summary>
        private LambdaCommand _ChangeToMainWindowCommand = null!;

        /// <summary>Перейти во второе окно</summary>
        public ICommand ChangeToMainWindowCommand => _ChangeToMainWindowCommand
            ??= new(OnChangeToMainWindowCommandExecuted);

        /// <summary>Логика выполнения - Перейти во второе окно</summary>
        private void OnChangeToMainWindowCommandExecuted()
        {

        }

        #endregion
    }
}
