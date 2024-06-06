using System;
using System.Windows;
using SerializationLibrary;

namespace WpfSerializationApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            var person = new Person { Name = NameTextBox.Text, Age = int.Parse(AgeTextBox.Text) };
            var json = SerializationHelper.SerializeToJson(person);
            ResultTextBox.Text = json;
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            var json = ResultTextBox.Text;
            var person = SerializationHelper.DeserializeFromJson<Person>(json);
            NameTextBox.Text = person.Name;
            AgeTextBox.Text = person.Age.ToString();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
