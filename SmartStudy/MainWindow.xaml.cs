using System.Windows;
using DataAcecss.Repositories;
using DataAcecss.Models;

namespace SmartStudy
{
    public partial class MainWindow : Window
    {
        private SubjectRepository _subjectRepo = new();
        private ScoreRepository _scoreRepo = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadSubjects();
            LoadScores();
        }

        private void LoadSubjects()
        {
            var subjects = _subjectRepo.GetAllSubjects();
            SubjectsListBox.ItemsSource = subjects;
        }

        private void LoadScores()
        {
            var scores = _scoreRepo.GetAllScores();
            ScoresListBox.ItemsSource = scores;
        }
    }
}
