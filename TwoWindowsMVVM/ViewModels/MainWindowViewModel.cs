﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using TwoWindowsMVVM.Commands;
using TwoWindowsMVVM.Models;
using TwoWindowsMVVM.Services;
using TwoWindowsMVVM.ViewModels.Base;

namespace TwoWindowsMVVM.ViewModels
{
    public class MainWindowViewModel : DialogViewModel
    {
        private readonly IUserDialog? _UserDialog = null!;
        private readonly IMessageBus? _MessageBus = null!;
        private readonly IDisposable _Subscription = null!;

        public MainWindowViewModel()
        {
            Title = "Главное окно";
        }

        public MainWindowViewModel(IUserDialog? UserDialog, IMessageBus? MessageBus) : this()
        {
            _UserDialog = UserDialog;
            _MessageBus = MessageBus;

            _Subscription = MessageBus!.RegisterHandler<Message>(OnReceiveMessage);
        }

        public void Dispose() => _Subscription.Dispose();
        private void OnReceiveMessage(Message message) => _Messages.Add(new(message.Text));

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
            ??= new(OnSendMessageCommandExecuted, p => p is string{Length: > 0});
        

        /// <summary>Логика выполнения - Отправка сообщения</summary>
        private void OnSendMessageCommandExecuted(object? p)
        {
            _MessageBus!.Send(new Message((string)p!));
        }

        #endregion


        #region Command OpenSecondWindowCommand - Открыть второе окно

        /// <summary>Открыть второе окно</summary>
        private LambdaCommand _OpenSecondWindowCommand = null!;

        /// <summary>Открыть второе окно</summary>
        public ICommand OpenSecondWindowCommand => _OpenSecondWindowCommand
            ??= new(OnOpenSecondWindowCommandExecuted);

        /// <summary>Логика выполнения - Открыть второе окно</summary>
        private void OnOpenSecondWindowCommandExecuted()
        {
            _UserDialog!.OpenSecondaryWindow();
        }

        #endregion

        #region Command ChangeToSecondWindowCommand - Перейти во второе окно

        /// <summary>Перейти во второе окно</summary>
        private LambdaCommand _ChangeToSecondWindowCommand = null!;

        /// <summary>Перейти во второе окно</summary>
        public ICommand ChangeToSecondWindowCommand => _ChangeToSecondWindowCommand
            ??= new(OnChangeToSecondWindowCommandExecuted);

        /// <summary>Логика выполнения - Перейти во второе окно</summary>
        private void OnChangeToSecondWindowCommandExecuted()
        {
            _UserDialog!.OpenSecondaryWindow();
            OnDialogComplete(EventArgs.Empty);
        }

        #endregion
    }
}
