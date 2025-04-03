using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LightsOut.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<string> Statistics { get; set; } = new List<string>();

        public void SaveToFile()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new InvalidOperationException("Name field cannot be empty or null.");
            }

            string fileName = "./users/" + Name + ".txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                Type type = this.GetType();
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    if (prop.PropertyType == typeof(List<string>))
                    {
                        writer.WriteLine($"{prop.Name}: {string.Join(",", (List<string>)prop.GetValue(this))}");
                    }
                    else
                    {
                        writer.WriteLine($"{prop.Name}: {prop.GetValue(this)}");
                    }
                }

                foreach (FieldInfo field in type.GetFields())
                {
                    writer.WriteLine($"{field.Name}: {field.GetValue(this)}");
                }
            }
        }

        public void LoadFromFile(string name)
        {
            string fileName = name;
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found: " + fileName);
            }

            User obj = new User();
            Type type = typeof(User);

            foreach (string line in File.ReadLines(fileName))
            {
                string[] parts = line.Split(new[] { ": " }, 2, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    PropertyInfo prop = type.GetProperty(parts[0]);
                    FieldInfo field = type.GetField(parts[0]);

                    if (prop != null && prop.CanWrite)
                    {
                        if (prop.PropertyType == typeof(List<string>))
                        {
                            List<string> props = new List<string>(parts[1].Split(','));
                            if (props[0] == "") props.Remove(props[0]);
                            prop.SetValue(obj, props);
                        }
                        else
                        {
                            prop.SetValue(obj, Convert.ChangeType(parts[1], prop.PropertyType));
                        }
                    }
                    else if (field != null)
                    {
                        field.SetValue(obj, Convert.ChangeType(parts[1], field.FieldType));
                    }
                }
            }

            this.Name = obj.Name;
            this.Width = obj.Width;
            this.Height = obj.Height;
            this.Avatar = obj.Avatar;
            this.Statistics = obj.Statistics;
        }

        public void DeleteFile()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new InvalidOperationException("Name field cannot be empty or null.");
            }

            string fileName = "./users/" + Name + ".txt";
            File.Delete(fileName);
        }
    }
}
