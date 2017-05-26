using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DPSP_UI_LG.Models
{
    public class ProjectViewModel
    {
        public Guid ProjectId { get; set; }

        [JsonProperty("odata.type")]
        public string Type { set; get; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string Client { get; set; }

        public string Manager { get; set; }

        public string Employees { get; set; }

        public string Introduction { get; set; }

        public string Content { get; set; }

        public string Conclusion { get; set; }

        public string Budget { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime? CloseDate { get; set; }

        public bool ForShare { get; set; }
    }

    public class ListProjectViewModel
    {
        public IList<ProjectViewModel> ProjectViewModels { get; set; }
    }


}
