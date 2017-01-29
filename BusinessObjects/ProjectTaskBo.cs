using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektiHaldus.Domain;
using ProjektiHaldus.ViewModels;

namespace ProjektiHaldus.BusinessObjects
{
    public class ProjectTaskBo : INotifyVM
    {
        public int ProjectTaskId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string WorkerName { get; set; }

        public string Name { get; set; }

        private DateTime _startDateTime;
        private DateTime _endDateTime;
        
        public System.DateTime StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value;
                TryToCalculateTotalTime();
            }
        }


        public System.DateTime EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value;
                TryToCalculateTotalTime();
            }
        }

        public System.TimeSpan TimeSpent { get; set; }
      

        public ProjectTaskBo(project_tasks task)
        {
            if (task != null)
            {
                ProjectTaskId = task.project_task_id;
                ProjectId = task.project_id;
                Description = task.description;
                WorkerName = task.worker_name;
                StartDateTime = task.start_date_time;
                EndDateTime = task.end_date_time;
                TimeSpent = task.time_spent;
                Name = task.name;
            }
        }

        public project_tasks ParseDomain()
        {
            return new project_tasks()
            {
                description = Description,
                worker_name =  WorkerName,
                start_date_time = StartDateTime,
                end_date_time = EndDateTime,
                time_spent = TimeSpent,
                name = Name
            };
        }



        private void TryToCalculateTotalTime()
        {
            if (StartDateTime != null && EndDateTime != null)
            {
                TimeSpent = EndDateTime - StartDateTime;
                NotifyPropertyChanged("TimeSpent");
            }
        }
    }
}
