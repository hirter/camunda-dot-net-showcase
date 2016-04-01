﻿using System.Collections.Generic;
using System.Windows.Controls;
using Camunda;
using System.Windows;
using Newtonsoft.Json.Linq;
using System;

namespace InsuranceApplicationWpfTasklist.TaskForms.DE
{
    /// <summary>
    /// Interaktionslogik für AntragPruefen.xaml
    /// </summary>
    public partial class DecideAboutApplication : Page, CamundaTaskForm
    {
        private TasklistWindow Tasklist;
        private HumanTask Task;
        public Dictionary<string, object> TaskVariables { get; set; }
        public Dictionary<string, object> NewVariables { get; set; }

        public DecideAboutApplication()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void initialize(TasklistWindow tasklist, HumanTask task)
        {
            this.Tasklist = tasklist;
            this.Task = task;
            TaskVariables = Tasklist.Camunda.HumanTaskService().LoadVariables(task.id);
            NewVariables = new Dictionary<string, object>();
            NewVariables.Add("approved", false);
        }

        private void buttonCompleteTaskl_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try {
                Tasklist.Camunda.HumanTaskService().Complete(Task.id, NewVariables);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error completing the task: " + ex.Message + "\nPlease investigate and try again.", "Could not complete task", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Tasklist.hideDetails();
            Tasklist.reloadTasks();
        }
    }
}
