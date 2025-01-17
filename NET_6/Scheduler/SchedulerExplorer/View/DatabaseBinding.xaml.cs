﻿using C1.Schedule;
using C1.WPF.Calendar;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SchedulerExplorer
{
    public partial class DatabaseBinding : UserControl
    {
        SqlDataAdapter _appointmentsAdapter;
        DataSet _dataSet;
        bool _updatingSelection = false;

        public DatabaseBinding()
        {
            InitializeComponent();

            var path = Directory.GetCurrentDirectory();
            //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            _dataSet = new DataSet();
            try
            {
                // todo: check error messages
                SqlConnection conn = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename ={path}\\Database\\Appointment.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand selectCMD = new SqlCommand("SELECT * FROM Appointees", conn);
                selectCMD.CommandTimeout = 30;
                SqlDataAdapter customerDA = new SqlDataAdapter();
                customerDA.SelectCommand = selectCMD;
                customerDA.Fill(_dataSet, "Appointees");

                selectCMD = new SqlCommand("SELECT * FROM Appointments", conn);
                _appointmentsAdapter = new SqlDataAdapter();
                _appointmentsAdapter.SelectCommand = selectCMD;
                SqlCommandBuilder builder = new SqlCommandBuilder(_appointmentsAdapter);
                builder.GetUpdateCommand();
                builder.GetDeleteCommand();
                builder.GetInsertCommand();

                _appointmentsAdapter.Fill(_dataSet, "Appointments");

                conn.Close();


                // set mappings and DataSource for the ContactStorage
                ContactStorage cstorage = scheduler.DataStorage.ContactStorage;
                cstorage.Mappings.IndexMapping.MappingName = "Id";
                cstorage.Mappings.TextMapping.MappingName = "Name";
                cstorage.DataMember = "Appointees";
                cstorage.DataSource = _dataSet.Tables["Appointees"];

                // set mappings and DataSource for the AppointmentStorage
                AppointmentStorage storage = scheduler.DataStorage.AppointmentStorage;
                storage.Mappings.AppointmentProperties.MappingName = "Properties";
                storage.Mappings.Body.MappingName = "Body";
                storage.Mappings.End.MappingName = "End";
                storage.Mappings.IdMapping.MappingName = "Id";
                storage.Mappings.Location.MappingName = "Location";
                storage.Mappings.Start.MappingName = "Start";
                storage.Mappings.Subject.MappingName = "Subject";
                storage.DataMember = "Appointments";
                storage.DataSource = _dataSet.Tables["Appointments"];
            }
            catch
            {

            }

            scheduler.LayoutUpdated += Scheduler_LayoutUpdated;
            scheduler.VisibleDates.CollectionChanged += VisibleDates_CollectionChanged;
            Tag = SchedulerExplorer.Resources.AppResources.DatabaseBindingDescription;

            DataContext = this;
            Unloaded += OnUnloaded;
        }

        private void VisibleDates_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateCalendarSelection();
        }

        private void Scheduler_LayoutUpdated(object sender, EventArgs e)
        {
            if (scheduler.Style == scheduler.MonthStyle)
            {
                views.SelectedIndex = 3;
            }
            else
            {
                if (scheduler.Style == scheduler.OneDayStyle)
                {
                    views.SelectedIndex = 0;
                }
                else if (scheduler.Style == scheduler.WorkingWeekStyle)
                {
                    views.SelectedIndex = 1;
                }
                else if (scheduler.Style == scheduler.WeekStyle)
                {
                    views.SelectedIndex = 2;
                }
                else
                {
                    views.SelectedIndex = 4;
                }
            }
            UpdateCalendarSelection();
        }

        void UpdateCalendarSelection()
        {
            if ( !_updatingSelection && (calendar1.SelectedDates == null || 
                ( scheduler.VisibleDates.Count != calendar1.SelectedDates.Count
                || (calendar1.SelectedDates.Count > 0 && scheduler.VisibleDates[0] != calendar1.SelectedDates[0]))))
            {
                _updatingSelection = true;
                calendar1.SelectedDates = scheduler.VisibleDates.ToList();
                _updatingSelection = false;
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            // save all changes in appointments back to database
            _appointmentsAdapter.Update(_dataSet.Tables["Appointments"]);
            _dataSet.AcceptChanges();

        }

        private void SelectedDate_changed(object sender, CalendarSelectionChangedEventArgs e)
        {
            if (!_updatingSelection)
            {
                var calendar = sender as C1Calendar;
                if (calendar?.SelectedDate == default(DateTime))
                    return;

                scheduler.VisibleDates.BeginUpdate();
                scheduler.VisibleDates.Clear();
                foreach (var d in calendar.SelectedDates)
                {
                    scheduler.VisibleDates.Add(d);
                }
                scheduler.VisibleDates.EndUpdate();
            }
        }

        private void Views_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (scheduler == null)
            {
                return;
            }
            switch (views.SelectedItems.FirstOrDefault())
            {
                case "Day":
                    SetStyle(scheduler.OneDayStyle);
                    break;
                case "Work Week":
                    SetStyle(scheduler.WorkingWeekStyle);
                    break;
                case "Week":
                    SetStyle(scheduler.WeekStyle);
                    break;
                case "Month":
                    SetStyle(scheduler.MonthStyle);
                    break;
                case "Time Line":
                    SetStyle(scheduler.TimeLineStyle);
                    break;
            }
        }
        private void SetStyle(Style style)
        {
            if (!IsLoaded || scheduler.Style == style)
            {
                return;
            }
            scheduler.BeginUpdate();
            try
            {
                scheduler.ChangeStyle(style);
            }
            finally
            {
                Scheduler_LayoutUpdated(null, null);
                // Always call EndUpdate to apply all changes.
                scheduler.EndUpdate();
            }
            UpdateCalendarSelection();
        }
    }

}