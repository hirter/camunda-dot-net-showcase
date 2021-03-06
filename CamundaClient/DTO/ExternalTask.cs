﻿using System.Collections.Generic;

namespace CamundaClient.Dto
{
    public class ExternalTask
    {
        public string activityId { get; set; }
        public string activityInstanceId { get; set; }
        public string id { get; set; }
        public int? retries { get; set; }
        public Dictionary<string, Variable> variables { get; set; }

        public override string ToString()
        {
            return "ExternalTask [Id=" + id + ", ActivityId=" + activityId+"]";
        }
    }

}
