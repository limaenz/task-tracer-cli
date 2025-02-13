using System.Text;

namespace TaskTrackerCli.src.Common.Utils
{
    public static class StringArrayUtils
    {
        public static string GetTaskName(string[] parameters)
        {
            var taskName = new StringBuilder();
            bool isTaskName = false;

            foreach (var item in parameters)
            {
                if (item.StartsWith('"'))
                    isTaskName = true;

                if (!isTaskName)
                    continue;
                
                string appendValue =  parameters[^1].Equals(item)
                ? item
                : item + " ";

                taskName.Append(appendValue);
            }

            return taskName.ToString();
        }
    }
}