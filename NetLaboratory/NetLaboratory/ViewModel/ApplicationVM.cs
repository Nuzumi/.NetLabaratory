using NetLaboratory.Model;
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
        
        NetRepo repo;

        #region Property

        private Article selectedArticle;
        public Article SelectedArticle
        {
            get { return selectedArticle; }
            set
            {
                SetProperty(ref selectedArticle, value);
                SelectedArticleText = SelectedArticle.Content;
                SelectedArticleComments = repo.GetAllCommentsForArticle(SelectedArticle);
                (AddCommentCommand as DelegateCommand).RaiseCanExecuteChanged();
            }
        }

        private string selectedArticleText;
        public string SelectedArticleText
        {
            get { return selectedArticleText; }
            set { SetProperty(ref selectedArticleText, value); }
        }

        private Comment selectedComment;
        public Comment SelectedComment
        {
            get { return selectedComment; }
            set { SetProperty(ref selectedComment, value); }
        }

        
        private List<Comment> selectedArticleComments;
        public List<Comment> SelectedArticleComments
        {
            get { return selectedArticleComments; }
            set { SetProperty(ref selectedArticleComments, value); }
        }

        
        private ObservableCollection<Article> articleList;
        public ObservableCollection<Article> ArticleList
        {
            get { return articleList; }
            set { SetProperty(ref articleList, value); }
        }

        private string newArticleTitle;
        public string NewArticleTitle
        {
            get { return newArticleTitle; }
            set
            {
                SetProperty(ref newArticleTitle, value);
                (AddArticleCommand as DelegateCommand).RaiseCanExecuteChanged();
            }
        }

        private string newArticleText;
        public string NewArticleText
        {
            get { return newArticleText; }
            set
            {
                SetProperty(ref newArticleText, value);
                (AddArticleCommand as DelegateCommand).RaiseCanExecuteChanged();
            }
        }

        private string newCommentText;
        public string NewCommentText
        {
            get { return newCommentText; }
            set
            {
                SetProperty(ref newCommentText, value);
                (AddCommentCommand as DelegateCommand).RaiseCanExecuteChanged();
            }
        }

        

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
            AddCommentCommand = new DelegateCommand(AddCommentCommandExecute, AddCommentCommandCanExecute);
            AddArticleCommand = new DelegateCommand(AddArticelCommandExecute, AddArticleCommandCanExecute);

            repo = new NetRepo();

            ArticleList = new ObservableCollection<Article>(repo.GetAllArticles());
            SelectedArticle = ArticleList.FirstOrDefault();
          
        }

        #region Commands

        private void ShowDialogWindowForArticleCommandEecute()
        {
            isDialogWindowForArticleOpen = true;
            Window dialogWindow = new View.AddArticleDialogWindow{ DataContext = this };
            DialogWindowForArticle = dialogWindow;
            (ShowDialogWindowForArticleCommand as DelegateCommand).RaiseCanExecuteChanged();
            dialogWindow.Show();
        }

        private bool ShowDialogWindowForArticleCommandCanExecute()
        {
            return !isDialogWindowForArticleOpen;
        }

        private void ShowDialogWindowForCommentCommandEecute()
        {
            isDialogWindowForCommentOpen = true;
            Window dialogWindow = new View.AddCommentDialogWindow() { DataContext = this };
            DialogWindowForComment = dialogWindow;
            (ShowDialogWindowForCommentCommand as DelegateCommand).RaiseCanExecuteChanged();
            dialogWindow.Show();
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
            repo.DeleteComment(SelectedComment);
            SelectedArticleComments = new List<Comment>(repo.GetAllCommentsForArticle(SelectedArticle));
        }

        private void AddCommentCommandExecute()
        {
            repo.AddComment(new Comment() { Article = SelectedArticle, Content = NewCommentText, DayCreated = DateTime.Now });
            CancelForCommentCommandExecute();
            SelectedArticleComments = repo.GetAllCommentsForArticle(SelectedArticle);
        }

        private bool AddCommentCommandCanExecute()
        {
            if(SelectedArticle == null)
            {
                return false;
            }

            if(NewCommentText == "" || NewCommentText == null)
            {
                return false;
            }

            return true;
        }

        private void AddArticelCommandExecute()
        {
            repo.AddArticle(new Article() { Title = NewArticleTitle, Content = NewArticleText, DayCreated = DateTime.Now });
            CancelForArticleCommandExecute();
            ArticleList = new ObservableCollection<Article>(repo.GetAllArticles());
        }

        private bool AddArticleCommandCanExecute()
        {
            if(NewArticleTitle == "" || NewArticleTitle == null)
            {
                return false;
            }

            if(NewArticleText == "" || NewArticleText == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
