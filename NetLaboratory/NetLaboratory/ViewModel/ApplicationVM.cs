using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NetLaboratory.ViewModel
{
    class ApplicationVM : BindableBase
    {
        private bool isDialogWindowForArticleOpen = false;
        private bool isDialogWindowForCommentOpen = false;
        private Window DialogWindowForArticle;
        private Window DialogWindowForComment;

        #region Property

        private string selectedArticle;
        public string SelectedArticle
        {
            get { return selectedArticle; }
            set
            {
                SetProperty(ref selectedArticle, value);
                // SelectedArticleText = value.Text;
            }
        }

        private string selectedArticleText;
        public string SelectedArticleText
        {
            get { return selectedArticleText; }
            set { SetProperty(ref selectedArticleText, value); }
        }

        private string selectedComment;
        public string SelectedComment
        {
            get { return selectedComment; }
            set { SetProperty(ref selectedComment, value); }
        }

        public ObservableCollection<string> SelectedArticleComments { get; set; }

        public string NewArticleTitle { get; set; }
        public string NewArticleText { get; set; }

        public string NewCommentText { get; set; }

        public ObservableCollection<string> ArticleList { get; set; }
        public ObservableCollection<string> CommentsList { get; set; }

        public ICommand DeleteCommentCommand { get; set; }
        public ICommand AddArticleCommand { get; set; }
        public ICommand AddCommentCommand { get; set; }
        public ICommand CancelForCommentCommand { get; set; }
        public ICommand CancelForArticleCommand { get; set; }
        public ICommand ShowDialogWindowForArticleCommand { get; set; }
        public ICommand ShowDialogWindowForCommentCommand { get; set; }
        #endregion

        public ApplicationVM()
        {
            DeleteCommentCommand = new DelegateCommand(DeleteCommentCommandExecute);
            CancelForArticleCommand = new DelegateCommand(CancelForArticleCommandExecute);
            CancelForCommentCommand = new DelegateCommand(CancelForCommentCommandExecute);
            ShowDialogWindowForArticleCommand = new DelegateCommand(ShowDialogWindowForArticleCommandEecute, ShowDialogWindowForArticleCommandCanExecute);
            ShowDialogWindowForCommentCommand = new DelegateCommand(ShowDialogWindowForCommentCommandEecute, ShowDialogWindowForCommentCommandCanExecute);
        }

        #region Commands

        private void ShowDialogWindowForArticleCommandEecute()
        {
            isDialogWindowForArticleOpen = true;
        }

        private bool ShowDialogWindowForArticleCommandCanExecute()
        {
            return !isDialogWindowForArticleOpen;
        }

        private void ShowDialogWindowForCommentCommandEecute()
        {
            isDialogWindowForCommentOpen = true;
        }

        private bool ShowDialogWindowForCommentCommandCanExecute()
        {
            return !isDialogWindowForCommentOpen;
        }

        private void CancelForArticleCommandExecute()
        {
            DialogWindowForArticle.Close();
            DialogWindowForArticle = null;
            isDialogWindowForArticleOpen = false;
            (ShowDialogWindowForArticleCommand as DelegateCommand).RaiseCanExecuteChanged();
        }

        private void CancelForCommentCommandExecute()
        {
            DialogWindowForComment.Close();
            DialogWindowForComment = null;
            isDialogWindowForCommentOpen = false;
            (ShowDialogWindowForCommentCommand as DelegateCommand).RaiseCanExecuteChanged();
        }

        private void DeleteCommentCommandExecute()
        {
            //SelectedComment.Usun
        }

        #endregion
    }
}
