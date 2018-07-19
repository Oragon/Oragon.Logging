using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oragon.Logging
{
    public class RabbitMQLogger : AbstractLogger
    {
        protected IConnection Connection { get; set; } //REFACTORING: Era "Template"

        public string ExchangeName { get; set; }

        public string RoutingKey { get; set; }

        public string ProjectKey { get; set; }

        protected override void SendLog(LogEntry logEntry)
        {
            logEntry.ProjectKey = this.ProjectKey;

            string serializedContent = Newtonsoft.Json.JsonConvert.SerializeObject(logEntry);
            byte[] payload = Encoding.UTF8.GetBytes(serializedContent);
            using (IModel model = this.Connection.CreateModel())
            {
                IBasicProperties props = model.CreateBasicProperties();
                props.DeliveryMode = 2;
                model.BasicPublish(this.ExchangeName, this.RoutingKey, props, payload);
            }

        }
    }
}
