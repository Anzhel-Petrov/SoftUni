using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] fields = classType.GetFields((BindingFlags)60);

            Object classInstance = Activator.CreateInstance(classType, new object[] { }); 

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classInstance.GetType().FullName}");

            foreach (FieldInfo field in fields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
