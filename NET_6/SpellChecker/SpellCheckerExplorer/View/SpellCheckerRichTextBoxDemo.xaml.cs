﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using C1.WPF.SpellChecker;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using C1.WPF.Core;
using C1.WPF.Docking;
using System.Net;

namespace SpellCheckerExplorer
{
    /// <summary>
    /// Interaction logic for SpellCheckerDemo.xaml
    /// </summary>
    public partial class SpellCheckerRichTextBoxDemo : UserControl
    {
        // declare the C1SpellChecker
        C1SpellChecker _c1SpellChecker = new C1SpellChecker();

        public SpellCheckerRichTextBoxDemo()
        {
            InitializeComponent();
            this.Tag = Properties.Resources.SpellCheckerRtbDemoDescription;
            Loaded += Page_Loaded;
            Unloaded += Page_Unloaded;
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {

            // connect toolbar to C1RichTextBox
            _rtbToolbar.RichTextBox = _richTextBox;
            _richTextBox.SpellChecker = _c1SpellChecker;

            // load sample text into text boxes
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SpellCheckerExplorer.Resources.test.txt"))
            using (var sr = new StreamReader(stream))
            {
                var text = sr.ReadToEnd();
                _richTextBox.Text = text;
            }

            // set up ignore list
            WordList il = _c1SpellChecker.IgnoreList;
            il.Add("ComponentOne");
            il.Add("Silverlight");

            // monitor events
            _c1SpellChecker.BadWordFound += _c1SpellChecker_BadWordFound;
            _c1SpellChecker.CheckControlCompleted += _c1SpellChecker_CheckControlCompleted;

            // load main dictionary
            if (_c1SpellChecker.MainDictionary.State != DictionaryState.Loaded)
                _c1SpellChecker.MainDictionary.Load(Application.GetResourceStream(new Uri("/" + new AssemblyName(Assembly.GetExecutingAssembly().FullName).Name + ";component/Resources/C1Spell_en-US.dct", UriKind.Relative)).Stream);
            if (_c1SpellChecker.MainDictionary.State == DictionaryState.Loaded)
            {
                WriteLine("loaded main dictionary ({0:n0} words).", _c1SpellChecker.MainDictionary.WordCount);
            }
            else
            {
                WriteLine("failed to load dictionary: {0}", _c1SpellChecker.MainDictionary.State);                    
            }
            // load user dictionary
            //UserDictionary ud = _c1SpellChecker.UserDictionary;
            //ud.LoadFromIsolatedStorage("Custom.dct");

            // save user dictionary when app exits
            App.Current.Exit += App_Exit;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _c1SpellChecker.BadWordFound -= _c1SpellChecker_BadWordFound;
            _c1SpellChecker.CheckControlCompleted -= _c1SpellChecker_CheckControlCompleted;
            
        }

        // app closing, save modified user dictionary into compressed isolated storage
        void App_Exit(object sender, EventArgs e)
        {
            //UserDictionary ud = _c1SpellChecker.UserDictionary;
            //ud.SaveToIsolatedStorage("Custom.dct");
            
        }        

        #region event handlers
        // monitor spell-checker events
        void _c1SpellChecker_CheckControlCompleted(object sender, CheckControlCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                var msg = string.Format("Spell-check complete, {0} errors found.", e.ErrorCount);
                MessageBox.Show(msg, "Spelling");
            }
            WriteLine("CheckControlCompleted: {0} errors found", e.ErrorCount);
            if (e.Cancelled)
            {
                WriteLine("\t(cancelled...)");
            }
        }
        void _c1SpellChecker_BadWordFound(object sender, BadWordEventArgs e)
        {
            WriteLine("BadWordFound: \"{0}\" {1}", e.BadWord.Text, e.BadWord.Duplicate ? "(duplicate)" : string.Empty);
        }        

        #endregion

        #region utilities

        // trace execution
        void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }
        void WriteLine(string text)
        {
            _outputTextBox.Text += text + "\r\n";
        }

        // helper class used for binding to the DataGrid
        public class Beatle : INotifyPropertyChanged
        {
            string _name, _comments;


            Beatle()
            {
            }
            public string Name { get { return _name; } set { _name = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Name")); } }
            public string Comments { get { return _comments; } set { _comments = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Comments")); } }
            public static List<Beatle> GetBeatles()
            {
                var list = new List<Beatle>();
                list.Add(new Beatle { Name = "Paul McCartney", Comments = "Great songriter, bass playier, singer" });
                list.Add(new Beatle { Name = "John Lennon", Comments = "Great songriter, gitar playier, excelent singer" });
                list.Add(new Beatle { Name = "Ringo Starr", Comments = "Great drummmer" });
                list.Add(new Beatle { Name = "George Harrison", Comments = "Great guiter player, songriter, vocallist" });
                return list;
            }

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            #endregion
        }
        #endregion

        
    }
}
